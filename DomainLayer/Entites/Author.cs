using DomainLayer.Entites.BaseEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entites
{
    public class Author : BaseEntity
    {
        public string Name { get; set; }

        // One-to-One relationship
        public Biography Biography { get; set; }
    }
}
