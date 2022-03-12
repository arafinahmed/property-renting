using PropertyRenting.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyRenting.Membership.Entities
{
    public class Product : IEntity<Guid>
    {
        public Guid Id { get; set; }
        [Required, MaxLength(255)]
        public string ProductName { get; set; }
        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        [Required, MaxLength(255)]
        public string Description { get; set; }
        [Required, MaxLength(255)]
        public string ImageUrl { get; set; }
        public int Price { get; set; }
    }
}