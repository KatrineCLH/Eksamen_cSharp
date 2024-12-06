using BLL.BLL;
using DTO.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Eksamen_Katrine
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MedarbejderBLL medarbejderBLL = new MedarbejderBLL();
        AfdelingBLL afdelingBLL = new AfdelingBLL();
        SagBLL sagBLL = new SagBLL();
        TidsregistreringBLL tidsregistreringBLL = new TidsregistreringBLL();

        public MainWindow()
        {
            InitializeComponent();

            //Populate oversigt over medarbejdere
            List<Medarbejder> medarbejdere = medarbejderBLL.GetAllMedarbejdere();
            foreach (Medarbejder m in medarbejdere)
            {
                MedarbejderOversigtLB.Items.Add(m);
            }

            //Populate oversigt over sager
            List<Sag> sager = sagBLL.GetAlleSager();
            foreach (Sag s in sager)
            {
                SagOversigtTB.Items.Add(s);
            }           

            //Populate drop-down med afdelinger
            List<Afdeling> afdelinger = afdelingBLL.GetAllAfdelinger();
            if (afdelinger != null)
            {
                TextForDDItem0 = afdelinger.Find(a => a.AfdelingsNummer == 1);
                TextForDDItem1 = afdelinger.Find(a => a.AfdelingsNummer == 2);
                TextForDDItem2 = afdelinger.Find(a => a.AfdelingsNummer == 3);
            }

            DataContext = this;
        }
        public Afdeling TextForDDItem0 { get; set; }
        public Afdeling TextForDDItem1 { get; set; }
        public Afdeling TextForDDItem2 { get; set; }

        private void TilføjBtn_Click(object sender, RoutedEventArgs e)
        {
            bool korrektInitialer = Regex.IsMatch(InitialerTB.Text, @"^[a-zA-ZæøåÆØÅ]+$");
            bool korrektCpr = Regex.IsMatch(CprTB.Text, @"^\d{6}-\d{4}$");

            if (AfdelingDD.SelectedItem != null && korrektInitialer && korrektCpr)
            {
                Medarbejder medarbejder = new Medarbejder(InitialerTB.Text, CprTB.Text, NavnTB.Text, AfdelingDD.SelectionBoxItem as Afdeling);
                string ini = medarbejderBLL.AddMedarbejder(medarbejder);
                if (medarbejder.Initial == ini)
                {
                    MedarbejderOversigtLB.Items.Add(medarbejder);
                    ClearMedarbejderFelter();
                }
            }
        }

        private void TilføjSagBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SAfdelingDD.SelectedItem != null && OverskriftTB.Text.Length > 0 && BeskrivelseTB.Text.Length > 0)
            {
                Sag sag = new Sag(OverskriftTB.Text, BeskrivelseTB.Text, (Afdeling)SAfdelingDD.SelectionBoxItem);
                int succes = sagBLL.AddSag(sag);
                if (succes != -1)
                {
                    sag.Nummer = succes;
                    SagOversigtTB.Items.Add(sag);
                    ClearSagFelter();
                }
            }
        }

        private void MedarbejderOversigtLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MedarbejderOversigtLB.SelectedItem != null)
            {
                Medarbejder selectedMedarbejder = MedarbejderOversigtLB.SelectedItem as Medarbejder;

                NavnTB.Text = selectedMedarbejder.Navn;
                InitialerTB.Text = selectedMedarbejder.Initial;
                CprTB.Text = selectedMedarbejder.Cpr;

                TidsOversigtLB.Items.Clear();

                List<Tidsregistrering> tr = tidsregistreringBLL.GetAlleTidsregistreringerForMedarbejder(selectedMedarbejder.Initial);
                foreach (Tidsregistrering t in tr)
                {
                    TidsOversigtLB.Items.Add(t.ToString());
                }
                
                FilterCB.SelectedItem = TotalFilter;
            }
        }
        private void SagOversigtTB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SagOversigtTB.SelectedItem != null)
            {
                Sag selectedSag = SagOversigtTB.SelectedItem as Sag;
                OverskriftTB.Text = selectedSag.Overskrift;
                BeskrivelseTB.Text = selectedSag.Beskrivelse;
            }
        }

        private void FilterCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MedarbejderOversigtLB.SelectedItem != null)
            {
                TidsOversigtLB.Items.Clear();

                Medarbejder selectedMedarbejder = (Medarbejder)MedarbejderOversigtLB.SelectedItem;
                List<Tidsregistrering> tr = tidsregistreringBLL.GetAlleTidsregistreringerForMedarbejder(selectedMedarbejder.Initial);

                if (tr.Count > 0)
                {
                    if (FilterCB.SelectedItem == TotalFilter)
                    {
                        foreach (Tidsregistrering t in tr)
                        {
                            TidsOversigtLB.Items.Add(t.ToString());
                        }
                    }
                    else if (FilterCB.SelectedItem == MånedFilter)
                    {
                        int currentMonth = tr.First().Start.Month;
                        int currentYear = tr.First().Start.Year;
                        double monthHours = 0;
                        string dataLine;

                        foreach (Tidsregistrering t in tr)
                        {
                            if (t.Start.Month.Equals(currentMonth) && t.Start.Year.Equals(currentYear))
                            {
                                monthHours += (t.Slut - t.Start).TotalHours;
                            }
                            else
                            {
                                dataLine = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(currentMonth) + " " + currentYear + ": " + $"{monthHours:F2}" + " timer i alt";
                                TidsOversigtLB.Items.Add(dataLine);
                                monthHours = (t.Slut - t.Start).TotalHours;
                                currentMonth = t.Start.Month;
                                currentYear = t.Start.Year;
                            }
                        }
                        dataLine = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(currentMonth) + " " + currentYear + ": " + $"{monthHours:F2}" + " timer i alt";
                        TidsOversigtLB.Items.Add(dataLine);
                    }
                    else if (FilterCB.SelectedItem == UgeFilter)
                    {
                        int ugeCounter = 0;
                        double antalTimer = 0;

                        foreach (Tidsregistrering t in tr)
                        {
                            antalTimer += (t.Slut - t.Start).TotalHours;
                            ugeCounter++;
                        }
                        TidsOversigtLB.Items.Add("Gennemsnit pr. uge: " + $"{antalTimer / ugeCounter:F2}" + " timer");
                    }
                }
            }            
        }

        private void SOpdaterBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SagOversigtTB.SelectedItem != null)
            {
                Sag selectedSag = (Sag)SagOversigtTB.SelectedItem;
                if (SAfdelingDD.SelectedItem != null && OverskriftTB.Text.Length > 0 && BeskrivelseTB.Text.Length > 0)
                {
                    Sag sag = new Sag(selectedSag.Nummer, OverskriftTB.Text, BeskrivelseTB.Text, (Afdeling)SAfdelingDD.SelectionBoxItem);
                    sagBLL.UpdateSag(sag);

                    SagOversigtTB.Items.Remove(selectedSag);
                    SagOversigtTB.Items.Add(sag);

                    ClearSagFelter();
                }
            }

        }

        private void OpdaterBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MedarbejderOversigtLB.SelectedItem != null) 
            {
                Medarbejder selectedMedarbejder = (Medarbejder)MedarbejderOversigtLB.SelectedItem;
                if (selectedMedarbejder.Initial == InitialerTB.Text)
                {
                    bool korrektInitialer = Regex.IsMatch(InitialerTB.Text, @"^[a-zA-ZæøåÆØÅ]+$");
                    bool korrektCpr = Regex.IsMatch(CprTB.Text, @"^\d{6}-\d{4}$");

                    if (AfdelingDD.SelectedItem != null && NavnTB.Text.Length > 0 && korrektInitialer && korrektCpr)
                    { 
                        Medarbejder medarbejder = new Medarbejder(InitialerTB.Text, CprTB.Text, NavnTB.Text, (Afdeling)AfdelingDD.SelectionBoxItem);
                        medarbejderBLL.UpdateMedarbejder(medarbejder);

                        MedarbejderOversigtLB.Items.Remove(selectedMedarbejder);
                        MedarbejderOversigtLB.Items.Add(medarbejder);

                        ClearMedarbejderFelter();
                    }
                }
            }
        }
        private void ClearMedarbejderFelter()
        {
            InitialerTB.Clear();
            CprTB.Clear();
            NavnTB.Clear();

            AfdelingDD.SelectedItem = null;
            TidsOversigtLB.Items.Clear();
            FilterCB.SelectedItem = null;
        }
        private void ClearSagFelter()
        {
            OverskriftTB.Clear();
            BeskrivelseTB.Clear();

            SAfdelingDD.SelectedItem = null;
        }
    }
}
