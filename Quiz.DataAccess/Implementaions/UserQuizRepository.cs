using Quiz.DataAccess.Data;
using Quiz.Entities.Interfaces;
using Quiz.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.DataAccess.Implementaions
{
    public class UserQuizRepository :GenericRepository<UserQuiz>, IUserQuizRepository
    {
        public UserQuizRepository(QuizSysContext context) : base(context)
        {
        }
    }
}
