using Microsoft.EntityFrameworkCore;
using EO = Stack_Overflow.API.Models;
using BO= Stack_Overflow.API.BisinessModels;
using Stack_Overflow.API.Contexts;

namespace Stack_Overflow.API.Services
{
    public class QuestionService : IQuestionService
    {
        
        private readonly ApplicationDbContext _dbContext;
        protected readonly DbSet<EO.Question> _dbSet;

        public QuestionService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<EO.Question>();
        }

        public async Task Add(BO.Question question)
        {

            if (question == null)
            {
                throw new FileNotFoundException("Answer Can not null");

            }
            EO.Question _question = new EO.Question();
            _question.Id = question.Id;
            _question.Qsn = question.Qsn;
            _question.CreateDate = question.CreateDate;

            await _dbSet.AddAsync(_question);
            await _dbContext.SaveChangesAsync();

        }

        public async Task<BO.Question> Get(int id)
        {
            if(id == 0)
            {
                throw new FileNotFoundException(" Can not null");

            }
            var question = await _dbSet.FindAsync(id);
            BO.Question _question = new BO.Question();
            _question.Id = question.Id;
            _question.Qsn=question.Qsn;
            _question.CreateDate=question.CreateDate;
            return _question;
        }

        public async Task Remove(BO.Question question)
        {
            if (question == null)
            {
                throw new FileNotFoundException(" Can not null");

            }
            EO.Question _question = new EO.Question();
            _question.Id = question.Id;
            _question.Qsn = question.Qsn;
            _question.CreateDate = question.CreateDate;
            _dbSet.Remove(_question);

            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(BO.Question question)
        {
             if(question == null)
            {
                throw new FileNotFoundException("Answer Can not null");

            }
            
            var result =_dbSet.SingleOrDefault(b => b.Id == question.Id);
            if (result != null)
            {
                result.Qsn =  question.Qsn;
                result.CreateDate = question.CreateDate;
                await _dbContext.SaveChangesAsync();
            }

           

        }

        public async Task<List<EO.Question>> GetAll()
        {
            return await _dbSet.ToListAsync();
            
        }
    }
}
