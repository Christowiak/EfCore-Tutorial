using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityFramework.Tutorial.Entities.Base
{
  public abstract class EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Creator { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Editor { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime EditorDate { get; set; }
    }
}
