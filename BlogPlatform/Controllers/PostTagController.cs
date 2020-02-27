using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogPlatform.Models;
using BlogPlatform.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogPlatform.Controllers
{
    public class PostTagController : Controller
    {
        private readonly IPost _ipostRepository;
        private readonly ITag _itagRepository;

        
        public PostTagController(IPost ipostRepository, ITag itagRepository)
        {
            this._ipostRepository = ipostRepository;
            this._itagRepository = itagRepository;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Post"] = new SelectList( _ipostRepository.GetAll());
            ViewData["Tag"] = new SelectList(_itagRepository.GetAll());

            return View();
        }

      
        [HttpGet]
        public ActionResult AddPostTag()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPostTag(Post post, Tag tag)
        {
            if (ModelState.IsValid)
            {
                //PostRepository.Add(post);
                //TagRepository.Add(tag);
                //PostRepository.Save();
                //TagRepository.Save();
                return RedirectToAction("Index", "Post");
            }
            return View();
        }

      
    }
}