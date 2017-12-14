using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chinook.Domain
{
    public class Track : Entity<int>
    {
        public string Name { get; set; }
    }
}
