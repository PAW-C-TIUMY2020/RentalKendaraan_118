using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentalKendaraan_NIM.Models
{
    public partial class Jaminan
    {
        public int IdJaminan { get; set; }
        [Required(ErrorMessage = "Nama jaminan wajib diisi")]
        public string NamaJaminan { get; set; }

        public Peminjaman Peminjaman { get; set; }
    }
}
