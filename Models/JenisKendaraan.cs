using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentalKendaraan_NIM.Models
{
    public partial class JenisKendaraan
    {
        public int IdJenisKendaraan { get; set; }
        [Required(ErrorMessage = "Nama jenis kendaraan wajib diisi")]
        public string NamaJenisKendaraan { get; set; }

        public Kendaraan Kendaraan { get; set; }
    }
}