using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentalKendaraan_NIM.Models
{
    public partial class Kendaraan
    {
        public int IdKendaraan { get; set; }
        [Required(ErrorMessage = "Nama Kendaraan tidak boleh kosong")]
        public string NamaKendaraan { get; set; }
        [MinLength(1, ErrorMessage = "No Polisi Minimal 1 angka")]
        [MaxLength(4, ErrorMessage = "No Polisi Maximal 4 angka")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Hanya boleh diisi oleh angka")]
        [Required(ErrorMessage = "No Polisi wajib diisi")]
        public string NoPolisi { get; set; }
        [MinLength(1, ErrorMessage = "No STNK Minimal 1 angka")]
        [MaxLength(4, ErrorMessage = "No STNK Maximal 4 angka")]
        public string NoStnk { get; set; }
        public int? IdJenisKendaraan { get; set; }
        public string Ketersediaan { get; set; }

        public JenisKendaraan IdKendaraanNavigation { get; set; }
        public Peminjaman Peminjaman { get; set; }
    }
}
