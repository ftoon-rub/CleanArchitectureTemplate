using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entites.BaseEntites
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            CreatedDateTime = DateTime.Now;
        }
        [Key]
        public long Id { get; set; }
        public DateTime CreatedDateTime { get; set; }

    }
}
