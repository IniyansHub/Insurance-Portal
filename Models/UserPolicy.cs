using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InsurancePortal.Models
{
    [Table("UserPolicy")]
    public partial class UserPolicy
    {
        [Key]
        [Column("recordId")]
        public int RecordId { get; set; }
        [Column("policyId")]
        public int PolicyId { get; set; }
        [Column("policyUserId")]
        [StringLength(50)]
        public string PolicyUserId { get; set; } = null!;
        [Column("policyStartDate")]
        public string? PolicyStartDate { get; set; }
        [Column("policyEndDate")]
        public string? PolicyEndDate { get; set; }
        [Column("policyStatus")]
        [StringLength(10)]
        public string? PolicyStatus { get; set; }
    }
}
