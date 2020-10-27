using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Token.Models
{
    public class User
    {
        public User()
        {
            UserID = Guid.NewGuid();
        }
        
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public Guid UserID { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Fmaily { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Password { get; set; }
    }

    
}