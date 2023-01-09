using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InsurancePortal.Models
{
    [Table("UserDetail")]
    public partial class UserDetail
    {
        [Key]
        [Column("email")]
        [StringLength(50)]
        public string Email { get; set; } = null!;
        [Column("firstName")]
        [StringLength(50)]
        public string FirstName { get; set; } = null!;
        [Column("lastName")]
        [StringLength(50)]
        public string LastName { get; set; } = null!;
        [Column("gender")]
        [StringLength(10)]
        public string Gender { get; set; } = null!;
        [Column("address")]
        [StringLength(255)]
        public string Address { get; set; } = null!;
        [Column("mobileNumber")]
        public long MobileNumber { get; set; }
        [Column("dob")]
        public DateOnly Dob { get; set; }
    }
}
