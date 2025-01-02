using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Entities.Models
{
    public class Question
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }
        public string? Image { get; set; }

        [Required]
        public ICollection<Answer> Answers { get; set; } = new List<Answer>();

        public int QuizId { get; set; }
        public quiz Quiz { get; set; }
        [NotMapped] // Temporary property, not stored in the database
        public int? SelectedAnswerId { get; set; }
    }
}
