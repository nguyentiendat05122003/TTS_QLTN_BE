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
    }


    public class UserResponse : NguoidungManager
    {

        public string TEN_DONVI { get; set; }
        public string TEN_PHONGBAN { get; set; }
        public string TEN_CHUCVU { get; set; }
        public string EMAIL { get; set; }
    }
}
