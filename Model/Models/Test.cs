using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class Test
    {
        [Key]
        public int Id { get; set; }

        public double Grade { get; set; }
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Student student { get; set; }

        public int SubjectId { get; set; }
        [ForeignKey("SubjectId")]
        public Subject subject { get; set; }
    }
}
