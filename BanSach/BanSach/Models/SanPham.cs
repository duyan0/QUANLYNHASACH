﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Text;
using BanSach.DesignPatterns.PrototypePattern;

namespace BanSach.Models
{
    public class SanPham : IPrototype<SanPham>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            this.DonHangCT = new HashSet<DonHangCT>();
        }

        public int IDsp { get; set; }

        [DisplayName("Tên Sản Phẩm")]
        [Required(ErrorMessage = "Tên sản phẩm không được để trống.")]
        [StringLength(200, ErrorMessage = "Tên sản phẩm không được vượt quá 200 ký tự.")]
        public string TenSP { get; set; }

        [DisplayName("Mô Tả")]
        [StringLength(1000, ErrorMessage = "Mô tả không được vượt quá 1000 ký tự.")]
        public string MoTa { get; set; }

        [DisplayName("ID Thể Loại")]
        [Required(ErrorMessage = "Thể loại không được để trống.")]
        public int IDtl { get; set; }

        [DisplayName("Giá Bán")]
        [Required(ErrorMessage = "Giá bán không được để trống.")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá bán phải lớn hơn hoặc bằng 0.")]
        public decimal GiaBan { get; set; }

        [DisplayName("Hình Ảnh")]
        [Required(ErrorMessage = "Hình ảnh không được để trống.")]
        [StringLength(250, ErrorMessage = "Đường dẫn hình ảnh không được vượt quá 250 ký tự.")]
        public string HinhAnh { get; set; }

        [DisplayName("ID Tác Giả")]
        [Required(ErrorMessage = "Tác giả không được để trống.")]
        public int IDtg { get; set; }

        [DisplayName("ID Nhà Xuất Bản")]
        [Required(ErrorMessage = "Nhà xuất bản không được để trống.")]
        public int IDnxb { get; set; }

        [DisplayName("ID Khuyến Mãi")]
        public int IDkm { get; set; }

        [DisplayName("Số Lượng")]
        [Required(ErrorMessage = "Số lượng không được để trống.")]
        [Range(0, int.MaxValue, ErrorMessage = "Số lượng phải lớn hơn hoặc bằng 0.")]
        public int SoLuong { get; set; }

        [DisplayName("Trạng Thái Sách")]
        [StringLength(100, ErrorMessage = "Trạng thái sách không được vượt quá 100 ký tự.")]
        public string TrangThaiSach { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHangCT> DonHangCT { get; set; }
        public virtual KhuyenMai KhuyenMai { get; set; }
        public virtual NhaXuatBan NhaXuatBan { get; set; }
        public virtual TacGia TacGia { get; set; }
        public virtual TheLoai TheLoai { get; set; }
        public SanPham Clone()
        {
            return new SanPham
            {
                IDsp = this.IDsp, 
                TenSP = this.TenSP,
                MoTa = this.MoTa,
                IDtl = this.IDtl,
                GiaBan = this.GiaBan,
                HinhAnh = this.HinhAnh,
                IDtg = this.IDtg,
                IDnxb = this.IDnxb,
                IDkm = this.IDkm,
                SoLuong = this.SoLuong,
                TrangThaiSach = this.TrangThaiSach
            };
        }
    }
}