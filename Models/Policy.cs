using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InsurancePortal.Models
{
    [Table("Policy")]
    public partial class Policy
    {
        [Key]
        [Column("policyId")]
        public int PolicyId { get; set; }
        [Column("policyName")]
        [StringLength(50)]
        public string PolicyName { get; set; } = null!;
        [Column("policyType")]
        [StringLength(30)]
        public string PolicyType { get; set; } = null!;
        [Column("policyValidity")]
        public sbyte PolicyValidity { get; set; }
        [Column("policyPrice", TypeName = "double(10,2)")]
        public double PolicyPrice { get; set; }
        [Column("policyDescription", TypeName = "mediumtext")]
        public string? PolicyDescription { get; set; }
    }
}
