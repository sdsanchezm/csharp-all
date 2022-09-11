using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreSchool.Entities
{
    public abstract class SchoolBaseClass
    {
        
        public string UniqueId { get; set; }
        public string Name { get; set; }

        // creating the constructor here, automatically assinging the id
        public SchoolBaseClass()
        {
            UniqueId = Guid.NewGuid().ToString();
        }

        // This is another way to initialize4 without constructor, just directly in the property
        //public string UniqueId { get; set; } = Guid.NewGuid().ToString();

    }
}
