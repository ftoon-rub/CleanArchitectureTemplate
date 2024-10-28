using DomainLayer.Entites.BaseEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entites
{
    public class Library : BaseEntity
    {
        public string Location { get; set; }

        // Many-to-Many relationship
        public ICollection<Book> Books { get; set; }
    }
}
