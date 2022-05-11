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

        public KundenController(IUnitOfWork unitOfWork)
        {
            core = new Core(unitOfWork);
        }


        // GET: KundenController
        public ActionResult Index()
        {
            return View(core.UnitOfWork.GetRepository<Kunde>().GetAll());
        }

        // GET: KundenController/Details/5
        public ActionResult Details(int id)
        {
            return View(core.UnitOfWork.GetRepository<Kunde>().GetById(id));
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
                core.UnitOfWork.GetRepository<Kunde>().Add(kunde);
                core.UnitOfWork.Save();

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
            return View(core.UnitOfWork.GetRepository<Kunde>().GetById(id));
        }

        // POST: KundenController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Kunde kunde)
        {
            try
            {
                core.UnitOfWork.GetRepository<Kunde>().Update(kunde);
                core.UnitOfWork.Save();
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
            return View(core.UnitOfWork.GetRepository<Kunde>().GetById(id));
        }

        // POST: KundenController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var k = core.UnitOfWork.GetRepository<Kunde>().GetById(id);
                if (k != null)
                {
                    core.UnitOfWork.GetRepository<Kunde>().Delete(k);
                    core.UnitOfWork.Save();
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
