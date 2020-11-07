using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentalKendaraan_NIM.Models
{
    public partial class Pengembalian
    {
        public int IdPengembalian { get; set; }
        [Required(ErrorMessage = "Tanggal peminjaman wajib diisi")]
        public DateTime? TglPengembalian { get; set; }
        public int? IdPeminjaman { get; set; }
        public int? IdKondisi { get; set; }
        [Required(ErrorMessage = "Denda peminjaman wajib diisi")]
        public int? Denda { get; set; }

        public KondisiKendaraan KondisiKendaraan { get; set; }
        public Peminjaman Peminjaman { get; set; }
    }
}
