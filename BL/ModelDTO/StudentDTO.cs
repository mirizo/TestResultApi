using System;

namespace BL.ModelDTO
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime JoinDate { get; set; }
        public   string Subcect { get; set; }
        public double Grade { get; set; }
    }
}