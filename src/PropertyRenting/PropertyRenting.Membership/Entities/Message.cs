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
    public class Message : IEntity<Guid>
    {
        public Guid Id { get; set; }
        [Required, MaxLength(255)]
        public string Name { get; set; }
        [Required, MaxLength(255)]
        public string Email { get; set; }
        [Required, MaxLength(255)]
        public string Subject { get; set; }
        [Required, MaxLength(2048)]
        public string Description { get; set; }

    }
}