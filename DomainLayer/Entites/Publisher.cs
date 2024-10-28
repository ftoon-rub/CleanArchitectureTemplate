using DomainLayer.Entites.BaseEntites;

namespace DomainLayer.Entites
{
    public class Publisher : BaseEntity
    {
        public string Name { get; set; }

        // One-to-Many relationship
        public ICollection<Book> Books { get; set; }
    }

}
