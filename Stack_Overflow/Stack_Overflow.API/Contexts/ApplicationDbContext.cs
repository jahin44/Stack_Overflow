using Microsoft.EntityFrameworkCore;
using Stack_Overflow.API.Models;

namespace Stack_Overflow.API.Contexts
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        private readonly string _connectionString;

        public ApplicationDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(
                    _connectionString);
            }

            base.OnConfiguring(dbContextOptionsBuilder);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // one to many relationship
            modelBuilder.Entity<Question>()
                .HasKey(Q => Q.Id);
            modelBuilder.Entity<Answer>()
                .HasKey(ed => ed.Id);
            modelBuilder.Entity<Vote>()
                .HasKey(V => V.Id);
            

            modelBuilder.Entity<Answer>()
               .HasOne(ed => ed.Question)
               .WithMany(Q => Q.Answers)
               .HasForeignKey(ed => ed.QuestionId);

            modelBuilder.Entity<Answer>()
               .HasOne<Vote>(s => s.Vote)
               .WithOne(ad => ad.Answer)
               .HasForeignKey<Vote>(ad => ad.AnswerId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Vote> Votes { get; set; }
        


    }
}
