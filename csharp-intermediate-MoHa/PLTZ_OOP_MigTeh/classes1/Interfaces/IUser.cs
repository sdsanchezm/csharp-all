using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes1.Interfaces
{
    internal interface IUser
    {
        int userid { get; set; }
        string name { get; set; }
        string SecretIdentityUsername { get; set; }

        string GetAllInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"=========");
            sb.AppendLine($"userid: {userid}");
            sb.AppendLine($"secret Identity: {SecretIdentityUsername}");
            sb.AppendLine($"name: {name}");
            sb.AppendLine($"===================");

            return sb.ToString();
        }

    }
}
