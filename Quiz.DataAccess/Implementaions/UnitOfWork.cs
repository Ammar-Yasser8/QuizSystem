using Quiz.DataAccess.Data;
using Quiz.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.DataAccess.Implementaions
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly QuizSysContext _context;

        public IQuizRepository QuizRepository { get;  }

        public IQuestionsRepository QuestionsRepository { get;  }

        public IUserQuizRepository UserQuiz { get; }

        public IApplicationUserRepository ApplicationUserRepository { get; }

        public IAnswerRepository AnswerRepository { get; }


        public UnitOfWork(QuizSysContext context)
        {
            _context = context;
            QuizRepository = new QuizRepository(_context);
            QuestionsRepository = new QuestionRepository(_context);
            UserQuiz = new UserQuizRepository(_context);
            ApplicationUserRepository = new ApplicationUserRepository(_context);
            AnswerRepository = new AnswerRepository(_context);
        }
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
