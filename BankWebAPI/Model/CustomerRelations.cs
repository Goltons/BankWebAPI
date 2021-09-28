namespace BankWebAPI.Model
{
    public class CustomerRelations : BankWorker 
    {
        //müşteri ilişkileri yetkilisi yüksek işlemler için onay işlemleri yapıyor 500bin
        //tl den fazla kredi ve 100binden büyük para transferlerinde onay yapıyor
        //diğer hesap başvurusu kart başvurusu durumunda banka çalışanı onaylıyor
        //bu bütün işlemler görecek ve onay yapacak banka çalışnaı ise sadeece 100k altı transferleri ve 500k altı kredilere onay verecek
        //home componenti bu component ile3 farklı user login  route yapacak

        public int MyProperty { get; set; }
    }
}
