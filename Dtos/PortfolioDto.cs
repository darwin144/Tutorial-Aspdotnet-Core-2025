namespace CArch_V1.Dtos
{
    public class PortfolioDto
    {
        public int Id { get; set; }

        public string? NamaProduk { get; set; }

        public string? NamaPerusahaan { get; set; }

        public string? Skill { get; set; }

        public string? Teknologi { get; set; }

        public string? Keterangan { get; set; }

        // File/Gambar disimpan sebagai byte array
        public int? LamaPengerjaan { get; set; }

    }
}
