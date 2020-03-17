using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EF6TestsApp.Entities
{
    class Departament
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

    }
}
