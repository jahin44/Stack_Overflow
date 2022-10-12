namespace Stack_Overflow.API.BisinessModels
{
    public class Answer
    {
        public int Id { get; set; }
        public DateTime InsertDate { get; set; }
        public int QuestionId { get; set; }
        public string? Ans { get; set; }
    }
}
