using PropertyRenting.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyRenting.Membership.Entities
{
    public class Category : IEntity<Guid>
    {
        public Guid Id { get; set; }
        [Required, MaxLength(255)]
        public string CategoryName { get; set; }
        public IList<Product> Products { get; set; }
    }
}