namespace Webbanhang.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonHang")]
    public partial class DonHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonHang()
        {
            ChiTietDonHang = new HashSet<ChiTietDonHang>();
        }

        [Key]
        public int MaDH { get; set; }

        public bool? ThanhToan { get; set; }

        public bool? GiaoHang { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayGiao { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDat { get; set; }

        public int? MaTK { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHang { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
