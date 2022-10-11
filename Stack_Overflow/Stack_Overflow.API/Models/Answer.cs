namespace Stack_Overflow.API.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public DateTime InsertDate { get; set; }
        public int QuestionId { get; set; }
        public string? Ans { get; set; }
        public Question? Question { get; set; }

    }
}
