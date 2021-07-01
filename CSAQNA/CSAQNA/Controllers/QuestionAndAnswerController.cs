using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CSAQNA.Data;
using CSAQNA.Models;

namespace CSAQNA.Controllers
{
    public class QuestionAndAnswerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuestionAndAnswerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: QuestionAndAnswers
        public async Task<IActionResult> Index()
        {
            return View(await _context.QuestionAndAnswer.ToListAsync());
        }

        // GET: QuestionAndAnswers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionAndAnswer = await _context.QuestionAndAnswer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (questionAndAnswer == null)
            {
                return NotFound();
            }

            return View(questionAndAnswer);
        }

        // GET: QuestionAndAnswers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: QuestionAndAnswers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Question,Answer,subject")] QuestionAndAnswer questionAndAnswer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(questionAndAnswer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(questionAndAnswer);
        }

        // GET: QuestionAndAnswers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionAndAnswer = await _context.QuestionAndAnswer.FindAsync(id);
            if (questionAndAnswer == null)
            {
                return NotFound();
            }
            return View(questionAndAnswer);
        }

        // POST: QuestionAndAnswers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Question,Answer,subject")] QuestionAndAnswer questionAndAnswer)
        {
            if (id != questionAndAnswer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(questionAndAnswer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionAndAnswerExists(questionAndAnswer.Id))
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
            return View(questionAndAnswer);
        }

        // GET: QuestionAndAnswers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionAndAnswer = await _context.QuestionAndAnswer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (questionAndAnswer == null)
            {
                return NotFound();
            }

            return View(questionAndAnswer);
        }

        // POST: QuestionAndAnswers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var questionAndAnswer = await _context.QuestionAndAnswer.FindAsync(id);
            _context.QuestionAndAnswer.Remove(questionAndAnswer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionAndAnswerExists(int id)
        {
            return _context.QuestionAndAnswer.Any(e => e.Id == id);
        }
    }
}
