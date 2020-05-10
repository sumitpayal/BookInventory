using BookMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace BookMvc.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            IEnumerable<Bookmvcmodel> booklist;
            HttpResponseMessage response = Global.webclient.GetAsync("Book").Result;
            booklist = response.Content.ReadAsAsync<IEnumerable<Bookmvcmodel>>().Result;
            return View(booklist);
        }

        public ActionResult CreateEdit(string Title = null)
        {
            return View(new Bookmvcmodel());

        }
        [HttpPost]
        public ActionResult CreateEdit(Bookmvcmodel bm)
        {
            HttpResponseMessage response = Global.webclient.PostAsJsonAsync("Book", bm).Result;
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string Title = null)
        {
            if (Title == null)
            {
                return View(new Bookmvcmodel());
            }
            else
            {
                HttpResponseMessage response = Global.webclient.GetAsync("Book/" + Title).Result;
                return View(response.Content.ReadAsAsync<Bookmvcmodel>().Result);
            }


        }
        [HttpPost]
        public ActionResult Edit(Bookmvcmodel bm)
        {
           
                HttpResponseMessage response = Global.webclient.PutAsJsonAsync("Book/" + bm.Title, bm).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            
            return RedirectToAction("Index");
        }

        public ActionResult Delete(String Title)
        {
            HttpResponseMessage response = Global.webclient.DeleteAsync("Book/"+Title).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}