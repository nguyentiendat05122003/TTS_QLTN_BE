using System;

namespace APIPCHY.Models.ChiTietYCTN
{
    public class ChiTietYCTN
    {
        public int ID { get; set; }

        public string MA_CHI_TIET_TN { get; set; }
        public string MA_TBTN { get; set; }
        public int SO_LUONG { get; set; }
        public string MA_LOAI_BB { get; set; }
        public string MA_YCTN { get; set; }
        public string FILE_UPLOAD { get; set; }
        public DateTime NGAY_TT_TN { get; set; }
        public DateTime NGAY_TAO { get; set; }
        public string NGUOI_TAO { get; set; }
        public DateTime NGAY_SUA { get; set; }
        public string NGUOI_SUA { get; set; }
        public string LANTHU { get; set; }
    }
}
