using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Entities.ViewModels
{
    public class AnswerViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Answer text is required.")]
        public string Text { get; set; }

        public bool IsCorrect { get; set; }
    }
}
