using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreSchool.Entities
{
    class Evaluation
    {
        public string EvaluationId { get; set; }
        public string EvaluationName { get; set; }
        public Student Student { get; set; }
        public Subject Subject { get; set; }
        public float Grade { get; set; }
        private Evaluation() => EvaluationId = Guid.NewGuid().ToString();
    }
}
