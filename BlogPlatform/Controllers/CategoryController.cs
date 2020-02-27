using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogPlatform.Models;
using BlogPlatform.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BlogPlatform.Controllers
{
    public class CategoryController : Controller
    {
                
     private readonly IRepository<Category> categoryRepo;

        public CategoryController(IRepository<Category> categoryRepo)
            {
                this.categoryRepo = categoryRepo;
            }
            public ViewResult Index()
            {
                var model = categoryRepo.GetAll();
                return View(model);

            }

            // GET: /Details/
            public ActionResult Details(int id)
            {
                Category model = categoryRepo.GetById(id);
                return View(model);
            }

            // GET: /Create
            public ActionResult Create()
            {
                return View();
            }

            // POST: /Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(int id, Category category)
            {
                try
                {

                    categoryRepo.Add(category);

                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }

            public ActionResult Edit(int id)
            {
                var product = categoryRepo.Find(id);
                return View(product);
            }

            // POST:/Edit/
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(Category category)
            {
                try
                {
                    // TODO: Add update logic here
                    categoryRepo.Update(category);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }


            // GET: /Delete/
            public ActionResult Delete(int id)
            {
                var category = categoryRepo.Find(id);
                return View(category);
            }

            // POST:/Delete/
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Delete(int id, Category category)
            {
                try
                {
                    categoryRepo.Delete(id);

                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }

    }
}