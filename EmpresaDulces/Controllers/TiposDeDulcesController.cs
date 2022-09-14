using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmpresaDulces.Controllers
{
    public class TiposDeDulcesController : Controller
    {
        // GET: TiposDeDulcesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TiposDeDulcesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TiposDeDulcesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TiposDeDulcesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TiposDeDulcesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TiposDeDulcesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TiposDeDulcesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TiposDeDulcesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
