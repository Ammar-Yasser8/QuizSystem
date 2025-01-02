using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Entities.Models
{
    public class UserQuiz
    {
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int QuizId { get; set; }
        public quiz Quiz { get; set; }
        public int Score { get; set; }
        public int Attemps { get; set; }  

    }
}
