using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlogPlatform.Models;

namespace BlogPlatform.Controllers
{
    public class PostTagsController : Controller
    {
        private readonly PostContext _context;

        public PostTagsController(PostContext context)
        {
            _context = context;
        }

        // GET: PostTags
        public async Task<IActionResult> Index()
        {
            var postContext = _context.PostsTaqs.Include(p => p.Post).Include(p => p.Tag);
            return View(await postContext.ToListAsync());
        }

        // GET: PostTags/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postTag = await _context.PostsTaqs
                .Include(p => p.Post)
                .Include(p => p.Tag)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postTag == null)
            {
                return NotFound();
            }

            return View(postTag);
        }

        // GET: PostTags/Create
        public IActionResult Create()
        {
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Id");
            ViewData["TagId"] = new SelectList(_context.Tags, "Id", "Id");
            return View();
        }

        // POST: PostTags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PostId,TagId")] PostTag postTag)
        {
            if (ModelState.IsValid)
            {
                _context.Add(postTag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Id", postTag.PostId);
            ViewData["TagId"] = new SelectList(_context.Tags, "Id", "Id", postTag.TagId);
            return View(postTag);
        }

        // GET: PostTags/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postTag = await _context.PostsTaqs.FindAsync(id);
            if (postTag == null)
            {
                return NotFound();
            }
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Id", postTag.PostId);
            ViewData["TagId"] = new SelectList(_context.Tags, "Id", "Id", postTag.TagId);
            return View(postTag);
        }

        // POST: PostTags/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PostId,TagId")] PostTag postTag)
        {
            if (id != postTag.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postTag);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostTagExists(postTag.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Id", postTag.PostId);
            ViewData["TagId"] = new SelectList(_context.Tags, "Id", "Id", postTag.TagId);
            return View(postTag);
        }

        // GET: PostTags/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postTag = await _context.PostsTaqs
                .Include(p => p.Post)
                .Include(p => p.Tag)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postTag == null)
            {
                return NotFound();
            }

            return View(postTag);
        }

        // POST: PostTags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var postTag = await _context.PostsTaqs.FindAsync(id);
            _context.PostsTaqs.Remove(postTag);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostTagExists(int id)
        {
            return _context.PostsTaqs.Any(e => e.Id == id);
        }
    }
}
