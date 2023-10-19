using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contants
{
    public static class Messages
    {
        public static string CategoryAdded = "Kategori Başarıyla Eklendi";
        public static string CategoryDeleted = "Kategori Başarıyla Silindi";
        public static string CategoryUpdated = "Kategori Başarıyla Güncellendi";


        public static string ProductAdded = "Ürün Başarıyla Eklendi";
        public static string ProductDeleted = "Ürün Başarıyla Silindi";
        public static string ProductUpdated = "Ürün Başarıyla Güncellendi";


        public static string UserAdded = "Kullanıcı Başarıyla Eklendi";
        public static string UserDeleted = "Kullanıcı Başarıyla Silindi";
        public static string UserUpdated = "Kullanıcı Başarıyla Güncellendi";

        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre Hatalı";

        public static string SuccessfulLogin = "Giriş Başarılı";
        public static string UserAlreadyExists = "Kullanıcı zaten sistemde mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";

        public static string AccessTokenCreated = "Access Token Başarıyla oluşturuldu";

        public static string CartUpdated = "Sepet Başarıyla Güncellendi";
        public static string CartDeleted = "Sepet Başarıyla Silindi";
        public static string CartAdded = "Sepet Başarıyla Eklendi";

        public static string ProductNotFound = "Ürün bulunamadı";
        public static string ProductNotExistsStock = "Ürün stokta yok";

        public static string UserIsPoor = "bu adamın parası yetmedi";

        public static string UrunGirilmedi = "ürün giriniz";

        public static string GecersizId = "Bu olanları kaldıramadığım gibi, int sayı tipide kaldıramıyor..Lütfen 2147483647'den kücük bir sayı giriniz.";
        public static string ProductAlreadyExists = "Ürün zaten aynı kategori içerisinde mevcut";

        public static string Buisimdeurunvar = "var olan bir isim ile değiştiremezsiniz";
        public static string idgiriniz = "geçerli bir id giriniz";
        public static string namebosolamaz = "ProductName alanı boş olamaz";

        public static string CategoryNotFound = "category bulunamadı";

        public static string Buisimdecategoryvar = "aynı isimde category bulunmakta";

        public static string CategoryAlreadyExists = "category zaten var";

        public static string CartNotFound = "Bulunumadı";
    }
}
