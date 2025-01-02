using Quiz.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Entities.ViewModels
{
    public class QuizViewModel
    {
        [Required(ErrorMessage = "Quiz title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "At least one question is required.")]
        public List<QuestionViewModel> Questions { get; set; } = new List<QuestionViewModel>();
        
    }
}
