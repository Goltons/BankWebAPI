using System;
using System.ComponentModel.DataAnnotations;
using static BankWebAPI.Model.Enums;

namespace BankWebAPI.Model.Customer
{
    public class Card : BaseEntity
    {
        
        public Card()
        {

        }
        [Key]
        public int CardId { get; set; }
        [Required]
        public int CardPassword { get; set; }
        public double CardBalance { get; set; }
        public double CardDebt { get; set; }
        public double CardLimit { get; set; }
        [StringLength(16)]
        public string CardNumber { get; set; }
        public int CVC2 { get; set; }
        public DateTime CutOffDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastDate { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public CardType CardType { get; set; }

        /*
         *register için doğrulama js tarafında
         * cm:card ve bill bitse
         * bill için ödenecek kartın currency türü fatura ile aynı olmalı 
         * cmt:transaction ve loan
         * pz:bankaçalışanı ve mhiz
         * pzt:tasarımları ve route
          */
    }
}
