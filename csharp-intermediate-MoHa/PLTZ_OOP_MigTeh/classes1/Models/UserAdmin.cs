using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes1.Models
{
    internal abstract class UserAdmin
    {
        public abstract string name { get; set; }
        public abstract string SaveTheWorld();

        // this is a regular method and the same behaviour will be inherited and usable in the children classes
        public string SaveTheMoon()
        {
            return $"{name} has saved the moon!";
        }

        // this is a virtual class that will be mutated, modified into the class that will call it
        public virtual string SaveMars() 
        {
            return $"{name} has saved Mars!";
        }
    }
}
