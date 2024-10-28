using DomainLayer.Entites.BaseEntites;

namespace DomainLayer.Entites
{
    public class Biography : BaseEntity
    {
        public string Details { get; set; }

        // One-to-One relationship
        public long AuthorId { get; set; }
        public Author Author { get; set; }
    }

}
