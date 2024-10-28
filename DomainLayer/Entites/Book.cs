using DomainLayer.Entites.BaseEntites;
using DomainLayer.Enum;
using DomainLayer.Lookup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entites
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public long PublisherId { get; set; }

        // One-to-Many relationship
        public Publisher Publisher { get; set; }

        // Many-to-Many relationship
        public ICollection<Library> Libraries { get; set; }
        
        // Foreign Key to Genre
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
