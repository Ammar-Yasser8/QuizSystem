using Quiz.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Entities.ViewModels
{
    public class QuizResultViewModel
    {
        public int QuizId { get; set; }
        public string QuizName { get; set; }
        public int Score { get; set; }
        public int TotalQuestions { get; set; }
        public quiz Quiz { get; set; }
    }
}
