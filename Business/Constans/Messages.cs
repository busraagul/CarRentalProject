using Entities.Concerete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constans
{
    public static class Messages
    {
        //CRUD
        public static string Added = "Ekleme işlemi gerçekleştirildi";
        public static string Deleted = "Silme işlemi gerçekleştirildi";
        public static string Updated = "Güncellenme işlemi gerçekleştirildi";
        public static string Listed = "Listeleme işlemi gerçekleştirildi";

        //CHECK
        public static string NameInvalid = "Marka ismi geçersiz";
        internal static string MaintenanceTime = "Sistem Bakımda";

        //SPECİAL
        public static string DailyPriceInvalid = "Lütfen arabanın günlük fiyatını Sıfır'dan büyük bir değer giriniz";

        public static string SuccessRental = "Kiralama İşlemi gerçekleştirilmiştir.";
    }
}
