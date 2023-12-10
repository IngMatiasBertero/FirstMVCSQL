using FirstMVCSQL.Data;
using FirstMVCSQL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;

namespace FirstMVCSQL.Controllers
{
    public class ContactController : Controller
    {
        private readonly IRepositorioContactos _repositorioContactos;


        public ContactController(IRepositorioContactos repositorioContactos)
        {
            _repositorioContactos = repositorioContactos;
        }

        // GET: ContactController
        public async Task <ActionResult> Index()
        {
            var contactos = await _repositorioContactos.GetAll();

            return View(contactos);
        }

        // GET: ContactController/Details/5
        public async Task <ActionResult> Details(int id)
        {
            var contacto = await _repositorioContactos.GetDetails(id);
            return View(contacto);
        }

        // GET: ContactController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> Create(IFormCollection collection)
        {
            try
            {

                var contacto = new Contactos()
                {
                    FirstName = collection["FirstName"],
                    LastName = collection["LastName"],
                    Phone = collection["Phone"],
                    Address = collection["Address"]
                };

                await _repositorioContactos.Insert(contacto);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ContactController/Edit/5
        public async Task <ActionResult> Edit(int id)
        {
            var contacto = await _repositorioContactos.GetDetails(id);

            return View(contacto);
        }

        // POST: ContactController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> Edit(int id, IFormCollection collection)
        {
            try
            {

                var contacto = new Contactos()
                {
                    Id = int.Parse(collection["Id"]),
                    FirstName = collection["FirstName"],
                    LastName = collection["LastName"],
                    Phone = collection["Phone"],
                    Address = collection["Address"]
                };

                await _repositorioContactos.Update(contacto);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ContactController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var contacto = await _repositorioContactos.GetDetails(id);
            return View(contacto );
        }

        // POST: ContactController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {

                await _repositorioContactos.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
