using EntityFramework.Tutorial.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityFramework.Tutorial.Entities
{
   public class LibraryEntity : EntityBase
    {
        [Required]
        [StringLength(100)]
        public string Location { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public ICollection<BookEntity> Books { get; set; }
    }
}
