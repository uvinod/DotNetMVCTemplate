using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chinook.Domain
{
    public class Entity<TIdentity>
    {
        public TIdentity Id { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
