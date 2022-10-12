namespace Stack_Overflow.API.Models
{
    public class Vote
    {
        public int Id { get; set; }
        public DateTime InsertDate { get; set; }
        public int AnswerId { get; set; }
        public int TotalVote { get; set; }
        public Answer? Answer { get; set; }
    }
}
