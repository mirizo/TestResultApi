namespace Model
{
    using Model.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DBModel : DbContext
    {
        public DBModel()
            : base("name=DBModel")
        {
            Database.SetInitializer(new DBInitializer());
        }


        public DbSet<Student> students{ get; set; }
        public DbSet<Test> tests{ get; set; }
        public DbSet<Subject> subjects { get; set; }
    }

}