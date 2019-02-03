namespace EmployeeManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PayInfo")]
    public partial class PayInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PayStubId { get; set; }

        [Required]
        [StringLength(50)]
        public string EmployeeID { get; set; }

        public decimal Pay { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Month { get; set; }

        public virtual EmplyeeInfo EmplyeeInfo { get; set; }
    }
}
