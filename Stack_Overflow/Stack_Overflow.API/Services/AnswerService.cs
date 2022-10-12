using Microsoft.EntityFrameworkCore;
using Stack_Overflow.API.BisinessModels;
using EO = Stack_Overflow.API.Models;
using Stack_Overflow.API.Contexts;

namespace Stack_Overflow.API.Services
{
    public class AnswerService: IAnswerService
    {
        private readonly ApplicationDbContext _dbContext;
        protected readonly DbSet<EO.Answer> _dbSet;

        public AnswerService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<EO.Answer>();
        }

        public async Task Add(Answer answer)
        {
            if (answer == null)
            {
                throw new FileNotFoundException("Answer Can not null");
            }

            EO.Answer _answer = new EO.Answer();
            _answer.Id = answer.Id;
            _answer.Ans = answer.Ans;
            _answer.QuestionId = answer.QuestionId;
            _answer.InsertDate = answer.InsertDate;

            await _dbSet.AddAsync(_answer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Remove(Answer answer)
        {
            if (answer == null)
            {
                throw new FileNotFoundException(" Can not null");

            }
            EO.Answer _answer = new EO.Answer();
            _answer.Id = answer.Id;
            _answer.Ans = answer.Ans;
            _answer.QuestionId = answer.QuestionId;
            _answer.InsertDate = answer.InsertDate;
            _dbSet.Remove(_answer);

            await _dbContext.SaveChangesAsync();
        }

        public Task<Answer> Get(int id)
        {
            //if (id == 0)
            //{
            //    throw new FileNotFoundException(" Can not null");

            //}
            //var result = from Answer in _dbSet
            //where Answer.QuestionId = id
            //select new { Answer.Id, Answer.ans };

            //if (result != null)
            //{
            //    result.Qsn = question.Qsn;
            //    result.CreateDate = question.CreateDate;
            //    await _dbContext.SaveChangesAsync();
            //}
            //var question = await _dbSet.FindAsync(id);
            //BO.Answer _answer = new BO.Answer();
            //_answer.Id = answer.Id;
            //_answer.Ans = answer.Ans;
            //_answer.QuestionId = answer.QuestionId;
            //_answer.InsertDate = answer.InsertDate;
            //return _question;
            throw new NotImplementedException();

        }

        public Task Update(Answer answer)
        {
            throw new NotImplementedException();
        }
    }
}
