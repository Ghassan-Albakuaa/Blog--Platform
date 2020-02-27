using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogPlatform.Models;
using BlogPlatform.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BlogPlatform.Controllers
{
    public class TagController : Controller
    {

        private readonly IRepository<Tag> tagRepo;

        public TagController(IRepository<Tag> tagRepo)
        {
            this.tagRepo = tagRepo;
        }
        public ViewResult Index()
        {
            var model = tagRepo.GetAll();
            return View(model);
        }

        // GET: /Details/
        public ActionResult Details(int id)
        {
            var post = tagRepo.GetById(id);
            return View(post);
        }

        // GET: /Create
        public ActionResult Create()
        {
            return View();
        }

        // POST:/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int id, Tag tag)
        {
            try
            {
               tagRepo.Add(tag);
               return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var tag = tagRepo.Find(id);
            return View(tag);
        }

        // POST: /Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tag tag)
        {
            try
            {
                // TODO: Add update logic here
                tagRepo.Update(tag);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: product/Delete/
        public ActionResult Delete(int id)
        {
            var tag = tagRepo.Find(id);
            return View(tag);
        }

        // POST: /Delete/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Category category)
        {
            try
            {
                tagRepo.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

       



    }
}