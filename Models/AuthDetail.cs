using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InsurancePortal.Models
{
    [Table("AuthDetail")]
    public partial class AuthDetail
    {
        [Key]
        [Column("email")]
        [StringLength(50)]
        public string Email { get; set; } = null!;
        [Column("password")]
        [StringLength(60)]
        public string Password { get; set; } = null!;
        [Column("isAdmin")]
        public sbyte IsAdmin { get; set; }
    }
}
