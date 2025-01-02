using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Entities.ViewModels
{
    public class TopScoresViewModel
    {
        public string QuizTitle { get; set; }
        public List<ScoreDetail> Scores { get; set; }
    }
}
