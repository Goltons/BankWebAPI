using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Model.Customer
{
    public class Transfer:BaseEntity
    {
        public Transfer( )
        {
            //ibanla yapacak seçti->kart seçti daha sonra transferi yaptı
        }
        public int TransferId { get; set; }
        public double TransferAmount { get; set; }
        public double TransferFee { get; set; }
        public int   senderAccId { get; set; }
        public int receiverAccId { get; set; }
        public int senderCardId { get; set; }
        public int receiverCardId { get; set; }
        //gönderilen paradan yüzde 1 kesinti yaparak diğer hesapa aktarma yapacak
        public string SenderIBAN { get; set; }
        public string ReceiverIBAN { get; set; }
        //hesap no ile yapacaksa şube kodu ve hesap no girsin ad soyad alıcı bilgileri bunlar
        public int BranchCode { get; set; }
        public int AccountNumber { get; set; }
        public int AdditionalNumber { get; set; }
        public string TransferMessage { get; set; }
        public bool IsApproved { get; set; }
        public string Status { get; set; }
        public DateTime ApprovedDate { get; set; }
        public string ApproverTcNo { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string ReceiverName { get; set; }
        //iban veya hesap no ile transfer seçenekleri
        public string TransferType { get; set; }
    }
}
