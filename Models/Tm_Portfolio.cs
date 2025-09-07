using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Security.Principal;

namespace CArch_V1.Models
{
    public class Tm_Portfolio
    {
            public int Id { get; set; }

            public string? NamaProduk { get; set; }

            public string? NamaPerusahaan { get; set; }

            public string? Skill { get; set; }

            public string? Teknologi { get; set; }

            public string? Keterangan { get; set; }

            // File/Gambar disimpan sebagai byte array
            public byte[]? Gambar { get; set; }

            public int? LamaPengerjaan { get; set; }

            public DateTime CreateDate { get; set; }

    }
}
