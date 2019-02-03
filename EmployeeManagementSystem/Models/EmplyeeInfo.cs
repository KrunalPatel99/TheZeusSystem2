namespace EmployeeManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmplyeeInfo")]
    public partial class EmplyeeInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EmplyeeInfo()
        {
            PayInfoes = new HashSet<PayInfo>();
        }

        [Required]
        [StringLength(50)]
        public string EmployeeName { get; set; }

        [Key]
        [StringLength(50)]
        public string EmployeeID { get; set; }

        [Required]
        [StringLength(200)]
        public string EmployeeAddress { get; set; }

        public int EmployeePhoneNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string EmployeeEmailID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EmployeeDoB { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PayInfo> PayInfoes { get; set; }
    }
}
