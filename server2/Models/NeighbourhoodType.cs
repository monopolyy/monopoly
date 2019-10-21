using System;
using System.Collections.Generic;

namespace server2.Models
{
    public partial class NeighbourhoodType
    {
        public NeighbourhoodType()
        {
            Streets = new HashSet<Streets>();
        }

        public int IdNeighbourhoodType { get; set; }
        public string Name { get; set; }

        public ICollection<Streets> Streets { get; set; }
    }
}
