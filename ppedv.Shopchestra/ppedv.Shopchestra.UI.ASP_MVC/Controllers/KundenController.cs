using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ppedv.Shopchestra.Logic;
using ppedv.Shopchestra.Model;
using ppedv.Shopchestra.Model.Contracts;

namespace ppedv.Shopchestra.UI.ASP_MVC.Controllers
{
    public class KundenController : Controller
    {
        //Core core = new Core(new Data.EfCore.EfRepository());
        Core core;

        public KundenController(IRepository repo)
        {
            core = new Core(repo);
        }


        // GET: KundenController
        public ActionResult Index()
        {

            return View(core.Repository.GetAll<Kunde>());
        }

        // GET: KundenController/Details/5
        public ActionResult Details(int id)
        {
            return View(core.Repository.GetById<Kunde>(id));
        }

        // GET: KundenController/Create
        public ActionResult Create()
        {
            return View(new Kunde() { Name = "NEU" });
        }

        // POST: KundenController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Kunde kunde)
        {
            try
            {
                core.Repository.Add(kunde);
                core.Repository.Save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: KundenController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(core.Repository.GetById<Kunde>(id));
        }

        // POST: KundenController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Kunde kunde)
        {
            try
            {
                core.Repository.Update(kunde);
                core.Repository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: KundenController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(core.Repository.GetById<Kunde>(id));
        }

        // POST: KundenController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var k = core.Repository.GetById<Kunde>(id);
                if (k != null)
                {
                    core.Repository.Delete(k);
                    core.Repository.Save();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
