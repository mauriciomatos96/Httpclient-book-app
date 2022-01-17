using BookAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;

namespace BookApp.Controllers
{
    public class BooksController : Controller
    {
        public HttpClient Client { get; set; }

        public BooksController()
        {
            Client = new HttpClient();
        }

        // GET: BooksController
        public async Task<ActionResult> Index()
        {
            try
            {
                string responseBody = await Client.GetStringAsync("https://localhost:44321/api/books");
                List<BookModel> books = JsonConvert.DeserializeObject<List<BookModel>>(responseBody);
                return View(books);
            }
            catch (Exception)
            {
                ViewData["Error"] = "Ocurrio un error inesperado, por favor intente mas tarde.";
                return View(new List<BookModel>());
            }

        }

        // GET: BooksController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BooksController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BooksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(BookModel book)
        {
            try
            {
                string jsonModel = JsonConvert.SerializeObject(book);
                HttpContent httpContent = new StringContent(jsonModel, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await Client.PostAsync("https://localhost:44321/api/books", httpContent);

                //TODO:
                //1. Evaluar que el API retorne el Status code correcto.
                //2. Redireccionar a la vista de detalle o a la lista principal.
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: BooksController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BooksController/Edit/5
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

        // GET: BooksController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BooksController/Delete/5
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
