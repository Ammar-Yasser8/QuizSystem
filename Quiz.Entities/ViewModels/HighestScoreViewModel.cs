using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Entities.ViewModels
{
    public class HighestScoreViewModel
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public string QuizName { get; set; }
        public QuizResultViewModel QuizResultViewModel { get; set; }
    }
}
