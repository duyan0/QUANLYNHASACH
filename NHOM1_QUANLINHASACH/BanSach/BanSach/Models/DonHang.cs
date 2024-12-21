﻿namespace BanSach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public partial class DonHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonHang()
        {
            this.DonHangCT = new HashSet<DonHangCT>();
        }

        public int IDdh { get; set; }
        public DateTime? NgayDatHang { get; set; }
        public Nullable<int> IDkh { get; set; }
        public string DiaChi { get; set; }
        public DateTime? NgayNhanHang { get; set; }
        public string TrangThai { get; set; } = "Chờ xử lý";

        public Nullable<int> TongSoLuong { get; set; }
        public Nullable<decimal> TongTien { get; set; }

        public virtual KhachHang KhachHang { get; set; }
        public virtual ICollection<DonHangCT> DonHangCT { get; set; }

        // Tính tổng số tiền cho đơn hàng (tổng tiền của tất cả các chi tiết đơn hàng)
        public decimal GetTongSoTien()
        {
            return DonHangCT != null
                ? DonHangCT.Sum(ct => (ct.SoLuong ?? 0) * (decimal)(ct.Gia ?? 0))
                : 0;
        }

        // Phương thức này tính tổng tiền cho đơn hàng
        public decimal Total_DH
        {
            get
            {
                return DonHangCT != null
                    ? DonHangCT.Sum(ct => (ct.SoLuong ?? 0) * (decimal)(ct.Gia ?? 0))
                    : 0;
            }
        }
    }
}