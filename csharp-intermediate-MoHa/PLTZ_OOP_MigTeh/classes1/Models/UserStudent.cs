using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes1.Models
{
    internal class UserStudent : UserGeneral
    {

        public string StudentActivity(string action)
        {
            return $"{name} has completed: {action}";
        }
    }
}

