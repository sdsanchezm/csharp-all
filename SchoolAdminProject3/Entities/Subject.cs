using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreSchool.Entities
{
    public class Subject
    {
        public string SubjectId { get; set; }
        public string SubjectName { get; set; }

        public Subject() => SubjectId = Guid.NewGuid().ToString();
    }
}
