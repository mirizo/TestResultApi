using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ModelDTO
{
   public class TestDTO
    {
        public int Id { get; set; }
        public double Grade { get; set; }
        public int StudentId { get; set; }

        public string StudentName { get; set; }
        public string SubjectName { get; set; }
        public StudentDTO student { get; set; }
    }
}
