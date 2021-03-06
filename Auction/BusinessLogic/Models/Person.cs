﻿using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Models
{
    public class Person
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Surname { get; set; }
        [Required]
        [StringLength(255)]
        public string Email { get; set; }
        [Required]
        public int Phone { get; set; }
        [Required]
        public int BankAccountNumber { get; set; }
    }
}
