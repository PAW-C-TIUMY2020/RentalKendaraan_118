using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentalKendaraan_NIM.Models
{
    public partial class KondisiKendaraan
    {
        public int IdKondisi { get; set; }
        [Required(ErrorMessage = "Nama Kondisi wajib diisi")]
        public string NamaKondisi { get; set; }

        public Pengembalian IdKondisiNavigation { get; set; }
    }
}
