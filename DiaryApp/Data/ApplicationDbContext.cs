using DiaryApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DiaryApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Initial Catalog=DiaryApp;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DiaryEntry>().HasData(
                new DiaryEntry
            {
                DiaryEntryId = 1,
                Content = "Today I started my new diary app project. I'm excited to see how it turns out!",
                Created = new DateTime(2026,04,12),
                Title= "My First Diary Entry"
                
            },new DiaryEntry
            {
                DiaryEntryId = 2,
                Content = "I had a great day today! I went for a walk in the park and enjoyed the sunshine.",
                Created = new DateTime(2026, 09, 30),
                Title = "A Sunny Day"
            }, new DiaryEntry
            {
                DiaryEntryId = 3,
                Content = "I had a tough day at work today. I'm glad to be home now and relax.",
                Created = new DateTime(2026, 01, 12),
                Title = "A Tough Day"
            }, new DiaryEntry
            {
                DiaryEntryId = 4,
                Content = "I had a wonderful day with my family. We went to the beach and had a picnic.",
                Created = new DateTime(2026, 04, 30),
                Title = "Family Day"
            }, new DiaryEntry
            {
                DiaryEntryId = 5,
                Content = "I had a wonderful day with my family. We went to the beach and had a picnic.",
                Created = new DateTime(2026, 04, 22),
                Title = "Family Day"
            }, new DiaryEntry
            {
                DiaryEntryId = 6,
                Content = "I had a productive day today. I finished all my work and even had time to read a book.",
                Created = new DateTime(2026, 04, 15),
                Title = "A Productive Day"
            });
      
        
       

        }

        public DbSet<DiaryEntry> DiaryEntries { get; set; }


    }
}

