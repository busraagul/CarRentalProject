using Core.Entities.Concrete;
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
        public static string CarInvalid = "Geçersiz araç.";
        public static string CarImageInvalid ="Araba resmi bulunamadı. ";
        public static string AuthorizationDenied = "Yetkiniz yok.";

        //SPECİAL
        public static string DailyPriceInvalid = "Lütfen arabanın günlük fiyatını Sıfır'dan büyük bir değer giriniz";

        public static string SuccessRental = "Kiralama İşlemi gerçekleştirilmiştir.";
        public static string CarImageLimitExceeded = "En fazla 5 adet fotoğraf yüklenebilir";

        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";

    }
}
