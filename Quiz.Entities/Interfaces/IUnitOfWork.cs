using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Entities.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IQuizRepository QuizRepository { get; }
        IQuestionsRepository QuestionsRepository { get; }
        IUserQuizRepository UserQuiz { get; }
        IApplicationUserRepository ApplicationUserRepository { get; }
        IAnswerRepository AnswerRepository { get; }
        int Complete();
    }
}
