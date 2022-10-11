namespace Stack_Overflow.API.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Qsn { get; set; }
        public DateTime CreateDate { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
