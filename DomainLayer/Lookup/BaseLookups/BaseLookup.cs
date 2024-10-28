using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Lookup.BaseLookups
{
    public class BaseLookup
    {
        [Key]
        public int Id { get; set; }
        public int Code { get; set; }
    }
}
