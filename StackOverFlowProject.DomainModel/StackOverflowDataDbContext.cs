using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace StackOverFlowProject.DomainModel
{
    public class StackOverflowDataDbContext :DbContext
    {
        public StackOverflowDataDbContext():base("StackOverflowDatabaseDbContext") { }        

        public DbSet<Answer> Answers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Question> Quetions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vote> Votes { get; set; }
    }
}
