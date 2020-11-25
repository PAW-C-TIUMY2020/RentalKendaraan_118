using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentalKendaraan_NIM.Models
{
    public partial class Peminjaman
    {
        public int IdPeminjaman { get; set; }
        [Required(ErrorMessage = "Tanggal peminjaman wajib diisi")]
        public DateTime? TglPeminjaman { get; set; }
        public int? IdKendaraan { get; set; }
        public int? IdCustomer { get; set; }
        public int? IdJaminan { get; set; }
        [Required(ErrorMessage = "Biaya wajib diisi")]
        public int? Biaya { get; set; }

        public Jaminan IdPeminjaman1 { get; set; }
        public Kendaraan IdPeminjaman2 { get; set; }
        public Pengembalian IdPeminjaman3 { get; set; }
        public Customer IdPeminjamanNavigation { get; set; }
    }
}