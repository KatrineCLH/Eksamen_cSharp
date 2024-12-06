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
                if (medarbejder != null)
                {
                    return View("RegisterView", medarbejder);
                }
            }
            return View("ErrorView");
        }
        public ActionResult AddTidsregistrering(string SagDD, DateTime Start, DateTime Slut, Medarbejder medarbejder)
        {
            if (Slut != null && Start != null && Slut.CompareTo(Start) > 0)
            {
                int sagsnummer = Int32.Parse(SagDD);
                Sag sag = sagBLL.GetSag(sagsnummer);
                if (sag != null)
                {
                    Tidsregistrering tidsregistrering = new Tidsregistrering(0, Start, Slut, medarbejder, sag);
                    int result = tidsregistreringBLL.AddTidsregistrering(tidsregistrering);
                    if (result != -1)
                    {
                        return RedirectToAction("Index");
                    }
                }
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
            List<SelectListItem> ddList = new List<SelectListItem>();

            List<Sag> sager = sagBLL.GetSagerForAfdeling(afdelingsNummer);
            if (sager != null)
            {
                foreach (Sag sag in sager)
                {
                    ddList.Add(new SelectListItem { Text = sag.ToString(), Value = sag.Nummer.ToString() });
                }
            }

            return ShowDD(ddList);
        }
        [ChildActionOnly]
        public ActionResult ShowMedarbejderDD()
        {
            ViewBag.DDTitle = "MedarbejderDD";

            List<Medarbejder> medarbejdere = medarbejderBLL.GetAllMedarbejdere();
            List<SelectListItem> ddList = new List<SelectListItem>();

            foreach (Medarbejder m in medarbejdere)
            {
                ddList.Add(new SelectListItem { Text = m.ToString(), Value = m.Initial });
            }

            return ShowDD(ddList);
        }
    }
}