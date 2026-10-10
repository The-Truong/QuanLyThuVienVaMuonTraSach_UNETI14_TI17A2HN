namespace QuanLyThuVien_UNETI14_TI17A2HN.ViewModels
{
    /// <summary>Điều kiện Tìm kiếm + Lọc + Sắp xếp + Phân trang của danh sách sách (bind từ query string).</summary>
    public class SachQuery
    {
        public string? SearchString { get; set; }   // tên sách / tên thể loại / tên NXB
        public int? TheLoaiId { get; set; }
        public int? NhaXuatBanId { get; set; }
        public int? NamXuatBan { get; set; }
        public string? TinhTrang { get; set; }      // con | het
        public string? TrangThai { get; set; }      // hienthi | khoa
        public decimal? GiaTu { get; set; }
        public decimal? GiaDen { get; set; }
        public string? SortOrder { get; set; }      // name_desc | year | year_desc | price | price_desc | con | con_desc
        public int? PageNumber { get; set; }

        public string NextSort(string asc, string desc) => SortOrder == asc ? desc : asc;

        /// <summary>Toàn bộ điều kiện để giữ nguyên khi chuyển trang / đổi sắp xếp.</summary>
        public Dictionary<string, string> ToRoute(string? sort = null, bool overrideSort = false)
        {
            var d = new Dictionary<string, string>();
            void Add(string k, object? v) { var t = v?.ToString(); if (!string.IsNullOrEmpty(t)) d[k] = t; }
            Add("SearchString", SearchString); Add("TheLoaiId", TheLoaiId); Add("NhaXuatBanId", NhaXuatBanId);
            Add("NamXuatBan", NamXuatBan); Add("TinhTrang", TinhTrang); Add("TrangThai", TrangThai);
            if (GiaTu.HasValue) d["GiaTu"] = GiaTu.Value.ToString(System.Globalization.CultureInfo.InvariantCulture);
            if (GiaDen.HasValue) d["GiaDen"] = GiaDen.Value.ToString(System.Globalization.CultureInfo.InvariantCulture);
            Add("SortOrder", overrideSort ? sort : SortOrder);
            return d;
        }
    }
}
