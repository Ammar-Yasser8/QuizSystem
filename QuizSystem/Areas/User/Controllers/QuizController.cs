using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quiz.Entities.Interfaces;
using Quiz.Entities.Models;
using Quiz.Entities.ViewModels;
using QuizSystem.Areas.Admin.Controllers;
using System.Security.Claims;

[Area("User")]
public class QuizController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    public QuizController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public IActionResult Index()
    {
        var quizzes = _unitOfWork.QuizRepository.GetAll();
        return View(quizzes);  // Pass the quizzes to the view
    }
    public IActionResult Take(int id)
    {
        if (User.Identity.IsAuthenticated)
        {
            var quiz = _unitOfWork.QuizRepository
            .GetOne(q => q.Id == id, includeEntities: "Questions.Answers");

            // Debugging
            if (quiz?.Questions == null || !quiz.Questions.Any())
            {
                return Content("No questions found for this quiz.");
            }

            if (quiz == null)
            {
                return NotFound();
            }

            return View(quiz);
        }
        return RedirectToAction("Login", "Account", new { area = "Admin" });
         // Pass the quiz to the view
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    [Route("User/Quiz/SubmitQuiz")]
    public IActionResult SubmitQuiz(quiz submittedQuiz)
    {
        if (submittedQuiz == null || submittedQuiz.Questions == null)
        {
            return BadRequest("Invalid quiz submission.");
        }

        // Fetch the actual quiz from the database to compare answers
        var actualQuiz = _unitOfWork.QuizRepository.GetOne(q => q.Id == submittedQuiz.Id, includeEntities: "Questions.Answers");
        if (actualQuiz == null)
        {
            return NotFound("Quiz not found.");
        }

        int score = 0;

        // Compare submitted answers with actual answers
        foreach (var question in actualQuiz.Questions)
        {
            var submittedQuestion = submittedQuiz.Questions.FirstOrDefault(q => q.Id == question.Id);
            if (submittedQuestion != null)
            {
                var correctAnswer = question.Answers.FirstOrDefault(a => a.IsCorrect);
                if (correctAnswer != null && submittedQuestion.SelectedAnswerId == correctAnswer.Id)
                {
                    score++;
                }
            }
        }

        // Save the result in the UserQuiz table
        var userQuiz = new UserQuiz
        {
            UserId = User.FindFirstValue(ClaimTypes.NameIdentifier), // Assuming user is logged in
            QuizId = submittedQuiz.Id,
            Score = score,
            Attemps = 1 // Increment attempts if necessary
        };

        // Handle multiple attempts by user
        var existingUserQuiz = _unitOfWork.UserQuiz.GetOne(uq => uq.UserId == userQuiz.UserId && uq.QuizId == userQuiz.QuizId);
        if (existingUserQuiz != null)
        {
            existingUserQuiz.Attemps++; // Increment attempts if already exists
            _unitOfWork.UserQuiz.Update(existingUserQuiz);
        }
        else
        {
            _unitOfWork.UserQuiz.Add(userQuiz); // Add a new entry if not found
        }

        _unitOfWork.Complete();

        // Redirect to a results page
        return RedirectToAction("QuizResult", new { id = userQuiz.QuizId, score = userQuiz.Score });
    }

    public IActionResult QuizResult(int id, int score)
    {
        // Include Questions in the query
        var quiz = _unitOfWork.QuizRepository
            .GetOne(q => q.Id == id, includeEntities: "Questions");

        if (quiz == null)
        {
            return NotFound();
        }

        var result = new QuizResultViewModel
        {
            Quiz = quiz,
            Score = score,
            TotalQuestions = quiz.Questions?.Count ?? 0 // Safely handle null Questions
        };

        return View(result);
    }

}
