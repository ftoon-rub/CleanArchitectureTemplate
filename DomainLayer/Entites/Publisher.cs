using DomainLayer.Entites.BaseEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entites
{
    public class Publisher : BaseEntity
    {
        public string Name { get; set; }

        // One-to-Many relationship
        public ICollection<Book> Books { get; set; }
    }

}
