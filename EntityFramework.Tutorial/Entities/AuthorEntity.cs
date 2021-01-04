using EntityFramework.Tutorial.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityFramework.Tutorial.Entities
{
   public class AuthorEntity : EntityBase
    {
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        public int Age { get; set; }

        
        public string Address { get; set; }

        public ICollection<BookEntity> Books { get; set; }
    }
}
