using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Business.Contants
{
    public static class Messages
    {
        public static string CategoryNotFound = "Kategori Bulunamadı";
        public static string FoodIsNull = "Lütfen geçerli bir ürün giriniz";
        public static string FoodAddedSuccess = "Ürün Başarıyla Eklendi";
        public static string FoodNotFound = "Ürün Bulunamadı";
        public static string ThereIsNoFoodInThisCategory = "Bu Kategoriye Ait Ürün Bulunamadı";
        public static string ThereIsNoFood = "Ürün Bulunamadı";
        public static string FoodUpdatedSuccessfully = "Ürün Başarıyla Güncellendi";
        public static string FoodDeletedSuccessfully = "Ürün Başarıyla Silindi";
        public static string ErrorLogin = "Kullanıcı Bulunamadı, Lütfen Email ve Şifrenizi Kontrol Ediniz";
        public static string RefreshTokenNotFound = "Refresh Token Bulunamadı";
        public static string UserIdNotFoundForRefreshToken = "User Id Bulunamadı";
        public static string TokenDeletedSuccesfully = "Token Başarıyla Silindi";
        public static string UserNameNotFound = "Kullanıcı Bulunamadı";
        public static string RoleCreatedSuccessfully = "Rol Başarıyla Oluşturuldu";
    }
}
