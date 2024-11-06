using System;

namespace APIPCHY.Models.HTNguoiDung
{
    public class NguoidungManager
    {
        public string HO_TEN { get; set; }
        public string TEN_DANG_NHAP { get; set; }
        public int? TRANG_THAI { get; set; }
    }

    public class UserFilterRequest : NguoidungManager
    {
        public string DM_DONVI_ID { get; set; }
        public string DM_PHONGBAN_ID { get; set; }
        public string DM_CHUCVU_ID { get; set; }

        public int PageNumber { get; set; } 
        public int PageSize { get; set; }
    }


    public class UserResponse : NguoidungManager
    {
        public string TEN_DONVI { get; set; }
        public string TEN_PHONGBAN { get; set; }
        public string TEN_CHUCVU { get; set; }
        public string EMAIL { get; set; }
    }


    public class HTNguoiDungDTO : NguoidungManager
    {
        public string ID { get; set; }
        public string? TEN_DON_VI { get; set; }
        public string? TEN_PHONG_BAN { get; set; }
        public string? TEN_CHUC_VU { get; set; }
        public string DM_DONVI_ID { get; set; }
        public string DM_PHONGBAN_ID { get; set; }
        public string DM_KIEUCANBO_ID { get; set; }
        public string DM_CHUCVU_ID { get; set; }
        public string TEN_DANG_NHAP { get; set; }
        public string MAT_KHAU { get; set; }
        public string HO_TEN { get; set; }
        public string EMAIL { get; set; }
        public string LDAP { get; set; }
        public int? TRANG_THAI { get; set; }
        public DateTime? NGAY_TAO { get; set; }
        public string NGUOI_TAO { get; set; }
        public DateTime? NGAY_CAP_NHAT { get; set; }
        public string NGUOI_CAP_NHAT { get; set; }
        public string SO_DIEN_THOAI { get; set; }
        public int? GIOI_TINH { get; set; }
        public string SO_CMND { get; set; }
        public int? TRANG_THAI_DONG_BO { get; set; }
        public string DB_TAIKHOANDANGNHAP { get; set; }
        public DateTime? DB_NGAY { get; set; }
        public string DM_DONVI_LAMVIEC_ID { get; set; }
        public string HT_VAITRO_ID { get; set; }
        public string SIGN_ALIAS { get; set; }
        public string SIGN_USERNAME { get; set; }
        public string SIGN_PASSWORD { get; set; }
        public int? HRMS_TYPE { get; set; }
        public string SIGN_IMAGE { get; set; }
        public string ANHCHUKYNHAY { get; set; }
        public string ROLEID { get; set; }
        public string PHONG_BAN { get; set; }
        public string ANHDAIDIEN { get; set; }
    }
}
