using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogPlatform.Models;
using BlogPlatform.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BlogPlatform.Controllers
{
    public class PostController : Controller
    {
            IRepository<Post> postRepo;

            public PostController(IRepository<Post> postRepo)
            {
                this.postRepo = postRepo;
            }
            public ViewResult Index()
            {
                var model = postRepo.GetAll();
                return View(model);
            }

            // GET: /Details/
            public ActionResult Details(int id)
            {
                var post = postRepo.GetById(id);
                return View(post);
            }

            // GET: /Create
            [HttpGet]
            public ActionResult Create()
            {
                return View();
            }

            // POST: /Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(Post post)
            {
                try
                {
                    postRepo.Add(post);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }

            public ActionResult Edit(int id)
            {
                var product = postRepo.Find(id);
                return View(product);
            }

            // POST: /Edit/
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(Post post)
            {
                try
                {
                    // TODO: Add update logic here
                    postRepo.Update(post);
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
                var post = postRepo.Find(id);
                return View(post);
            }

            // POST:/Delete/
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Delete(int id, Post post)
            {
                try
                {
                    postRepo.Delete(id);

                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }

    }
}