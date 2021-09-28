using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static BankWebAPI.Model.Enums;

namespace BankWebAPI.Model.Customer
{
    public class Card : BaseEntity
    {
        
        public Card()
        {}
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
        public string Status { get; set; }
        public DateTime ApprovedDate { get; set; }
        public string ApproverTcNo { get; set; }

        public DateTime LastDate { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        //Kredi kartı veya Debit kart olacak şekilde 2 seçenek
        public CardType CardType { get; set; }

        /*
         * sl:transaction ve transfer history işlem durumu
         * çrş:bankaçalışanı ve mhiz
         * perş:tasarımları ve route
         * cum:
         * cmt:
         * pz:
         * pzt
          */
    }
}
