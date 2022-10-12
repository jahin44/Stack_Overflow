
using Stack_Overflow.API.BisinessModels;
using EO = Stack_Overflow.API.Models;

namespace Stack_Overflow.API.Services
{
    public interface IQuestionService
    {
        Task Add(Question question);
        Task Remove(Question question);
        Task<Question> Get(int id);
        Task<List<EO.Question>> GetAll();
        Task Update(Question question);
    }

}
