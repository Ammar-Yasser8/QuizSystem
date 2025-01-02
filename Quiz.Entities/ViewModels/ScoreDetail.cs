using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Entities.ViewModels
{
    public class ScoreDetail
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public QuizResultViewModel QuizResultViewModel { get; set; }
    }
}
