using DomainLayer.Entites.BaseEntites;

namespace DomainLayer.Entites
{
    public class Author : BaseEntity
    {
        public string Name { get; set; }

        // One-to-One relationship
        public Biography Biography { get; set; }
    }
}
