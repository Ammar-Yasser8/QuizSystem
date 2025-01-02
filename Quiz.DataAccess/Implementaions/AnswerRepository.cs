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
    public  class AnswerRepository : GenericRepository<Answer>, IAnswerRepository
    {
        public AnswerRepository(QuizSysContext context) : base(context)
        {
        }
    }
}
