using DomainLayer.Entites.BaseEntites;

namespace DomainLayer.Entites
{
    public class Library : BaseEntity
    {
        public string Location { get; set; }

        // Many-to-Many relationship
        public ICollection<Book> Books { get; set; }
    }
}
