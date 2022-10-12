using Stack_Overflow.API.BisinessModels;

namespace Stack_Overflow.API.Services
{
    public interface IAnswerService
    {
        Task Add(Answer answer);
        Task Remove(Answer answer);
        Task<Answer> Get(int id);
        Task Update(Answer answer);

    }
}
