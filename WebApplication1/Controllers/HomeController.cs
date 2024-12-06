using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.BLL;
using DTO.Model;


namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        MedarbejderBLL medarbejderBLL = new MedarbejderBLL();
        SagBLL sagBLL = new SagBLL();
        TidsregistreringBLL tidsregistreringBLL = new TidsregistreringBLL();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register(string MedarbejderDD)
        {
            if (MedarbejderDD != null)
            {
                Medarbejder medarbejder = medarbejderBLL.GetMedarbejder(MedarbejderDD);
                return View("RegisterView", medarbejder);
            }
            else
            {
                return View("ErrorView");
            } 
        }
        public ActionResult AddTidsregistrering(string SagDD, DateTime Start, DateTime Slut, Medarbejder medarbejder)
        {
            if (Slut != null && Start != null && Slut.CompareTo(Start) > 0)
            {
                int sagsnummer = Int32.Parse(SagDD);
                Sag sag = sagBLL.GetSag(sagsnummer);

                Tidsregistrering tidsregistrering = new Tidsregistrering(0, Start, Slut, medarbejder, sag);
                tidsregistreringBLL.AddTidsregistrering(tidsregistrering);

                return RedirectToAction("Index");
            }
            return View("ErrorView");
        }
        
        private ActionResult ShowDD(List<SelectListItem> list)
        {
            return PartialView("_DDView", list);
        }
        [ChildActionOnly]
        public ActionResult ShowSagDD(int afdelingsNummer)
        {
            ViewBag.DDTitle = "SagDD";
            List<Sag> sager = sagBLL.GetSagerForAfdeling(afdelingsNummer);

            List<SelectListItem> ddList = new List<SelectListItem>();
            foreach (Sag sag in sager)
            {
                ddList.Add(new SelectListItem { Text = sag.ToString(), Value = sag.Nummer.ToString() });
            }
            return ShowDD(ddList);
        }
        [ChildActionOnly]
        public ActionResult ShowMedarbejderDD()
        {
            ViewBag.DDTitle = "MedarbejderDD";
          
            List<Medarbejder> medarbejdere = medarbejderBLL.GetAllMedarbejdere();
            List<SelectListItem> ddList = new List<SelectListItem>();

            if (medarbejdere != null)
            {
                foreach (Medarbejder m in medarbejdere)
                {
                    ddList.Add(new SelectListItem { Text = m.ToString(), Value = m.Initial });
                }
            }
            return ShowDD(ddList);
        }
    }
}