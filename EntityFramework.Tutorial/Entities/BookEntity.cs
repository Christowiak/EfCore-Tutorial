using EntityFramework.Tutorial.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityFramework.Tutorial.Entities
{ 
   public class BookEntity : EntityBase
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(250)]
        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public bool IsNew { get; set; }

        [Required] 
        public AuthorEntity Author { get; set; }

        public int AuthorId { get; set; }
     
        [Required]
        public LibraryEntity Library { get; set; }

        public int LibraryId { get; set; }
    }
}
