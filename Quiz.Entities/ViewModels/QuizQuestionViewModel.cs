using Quiz.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Entities.ViewModels
{
    public class QuizQuestionViewModel
    {
        public int QuizId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Question CurrentQuestion { get; set; }
        public int QuestionIndex { get; set; }
        public int TotalQuestions { get; set; }
        public Question Question { get; set; }
        public quiz Quiz { get; set; }  

    }
}
