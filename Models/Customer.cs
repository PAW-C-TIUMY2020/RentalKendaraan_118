using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentalKendaraan_NIM.Models
{
    public partial class Customer
    {
        public int IdCustomer { get; set; }
        [Required(ErrorMessage = "Nama Costumer tidak boleh kosong")]
        public string NamaCustomer { get; set; }
        [RegularExpression("^[0-9]*$", ErrorMessage = "Hanya boleh diisi oleh angka")]
        public string Nik { get; set; }
        [Required(ErrorMessage = "Alamat wajib diisi")]
        public string Alamat { get; set; }
        [MinLength(10, ErrorMessage = "No HP Minimal 10 angka")]
        [MaxLength(13, ErrorMessage = "No HP Maximal 13 angka")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Hanya boleh diisi oleh angka")]
        [Required(ErrorMessage = "No HP wajib diisi")]
        public string NoHp { get; set; }
        [RegularExpression("^[0-9]*$", ErrorMessage = "Hanya boleh diisi oleh angka")]
        public int? IdGender { get; set; }

        public Gender Gender { get; set; }
        [Required(ErrorMessage = "Tanggal peminjaman wajib diisi wajib diisi")]
        public Peminjaman Peminjaman { get; set; }
    }
}
