using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quiz.DataAccess.Implementaions;
using Quiz.Entities.Interfaces;
using Quiz.Entities.Models;
using Quiz.Entities.ViewModels;
using System.Security.Claims;

namespace QuizSystem.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var quizzes = _unitOfWork.QuizRepository.GetAll();
            return View(quizzes);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new QuizViewModel
            {
                Questions = new List<QuestionViewModel>
                {
                     new QuestionViewModel
                     {
                        Answers = new List<AnswerViewModel>
                        {
                             new AnswerViewModel(),
                             new AnswerViewModel(),
                             new AnswerViewModel()
                        }
                     }
                }
            };

            return View(viewModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(QuizViewModel model, List<IFormFile> questionImages)
        {
            if (!ModelState.IsValid)
            {
                // Log validation errors (this is optional for debugging)
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }

                return View(model);
            }

            // Process images and handle the rest of the logic
            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images");

            if (!Directory.Exists(imagePath))
            {
                Directory.CreateDirectory(imagePath);
            }
            for (int i = 0; i < model.Questions.Count; i++)
            {
                var question = model.Questions[i];

                if (questionImages != null && questionImages.Count > i && questionImages[i] != null)
                {
                    var file = questionImages[i];
                    if (file.Length > 0)
                    {
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        string filePath = Path.Combine(imagePath, fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }

                        question.Image = "/Images/" + fileName; // Save the image path
                    }
                }
                // Validate answers
                if (question.Answers.Count != 4)
                {
                    ModelState.AddModelError("", $"Question {i + 1} must have exactly three answers.");
                    return View(model);
                }
                if (question.Answers.Count(a => a.IsCorrect) != 1)
                {
                    ModelState.AddModelError("", $"Question {i + 1} must have one and only one correct answer.");
                    return View(model);
                }
            }
            // Map the view model to your quiz entity
            var quiz = new quiz
            {
                Title = model.Title,
                Description = model.Description,
                Questions = model.Questions.Select(q => new Question
                {
                    Text = q.Text,
                    Image = q.Image,
                    Answers = q.Answers.Select(a => new Answer
                    {
                        Text = a.Text,
                        IsCorrect = a.IsCorrect
                    }).ToList()
                }).ToList()
            };

            // Save to database
            _unitOfWork.QuizRepository.Add(quiz);
            _unitOfWork.Complete();

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var quiz = _unitOfWork.QuizRepository.GetOne(q => q.Id == id);
            if (quiz == null)
            {
                return NotFound();
            }

            _unitOfWork.QuizRepository.Remove(quiz);
            _unitOfWork.Complete();

            return Ok();
        }
        public IActionResult TopScores(int quizId)
        {
            // Fetch the top 10 scores for a specific quiz
            var topScores = _unitOfWork.UserQuiz
                .GetAll(uq => uq.QuizId == quizId, includeEntities: "User")
                .OrderByDescending(uq => uq.Score)
                .Take(10)
                .Select(uq => new ScoreDetail
                {
                    Name = uq.User.Name ?? uq.User.UserName!, // Adjust based on your User model
                    Score = uq.Score
               
                    
                })
                .ToList();

            if (!topScores.Any())
            {
                return Content("No scores found for this quiz.");
            }

            var viewModel = new TopScoresViewModel
            {
                QuizTitle = _unitOfWork.QuizRepository
                              .GetOne(q => q.Id == quizId)?.Title ?? "Unknown Quiz",
                Scores = topScores
            };

            return View(viewModel);
        }


    }
}
