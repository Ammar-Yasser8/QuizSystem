using Quiz.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Entities.ViewModels
{
    public class QuestionViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Question text is required.")]
        public string Text { get; set; }

        public string? Image { get; set; }

        [Required(ErrorMessage = "At least one answer is required.")]
        public List<AnswerViewModel> Answers { get; set; } = new List<AnswerViewModel>();

        
    }

}
