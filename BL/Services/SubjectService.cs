using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.ModelDTO;
using Model;

namespace BL.Services
{
    public interface ISubjectService
    {
        List<string> GetAllSubject();
        int GetSubjectIdByName(string subjectName);
    }
    public class SubjectService : ISubjectService
    {
        public List<string> GetAllSubject()
        {
            var subjects = new List<string>();
            using (var ctx = new DBModel())
            {
                subjects = ctx.subjects.Select(x => x.Name).ToList();
            }
            return subjects;

        }

        public int GetSubjectIdByName(string subjectName)
        {
            using (var ctx = new DBModel())
            {
                return ctx.subjects.Where(x => x.Name == subjectName).Select(x => x.Id).FirstOrDefault();
             }
        }
    }
}
