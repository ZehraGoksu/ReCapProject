using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
	public static class Messages
	{
		public static string AddedError = "Ekleme işlemi başarısız.";
		public static string AddedErrorCarName = "Araç adı en az iki karakterden oluşmalıdır!";
		public static string AddedErrorDaily = "Araç günlük fiyatı 0'dan büyük olmalıdır.";
		public static string Added = "Kayıt işlemi başarılı.";
		public static string Updated = "Güncelleme işlemi başarılı.";
		public static string Deleted = "Silme işlemi başarılı.";
		public static string Listed = "Tüm kayıtlar listelendi.";
		public static string AddedErrorCompanyName = "Şirket adı en az iki karakterden oluşmalıdır!";
		public static string AddedErrorCarId = "Araç Id numarası geçersizdir.";
		public static string CarImageLimitExceed = "Bir araç için en fazla 5 fotoğraf eklenebilir.";
		public static string AuthorizationDenied = "Yetkiniz yok.";
		public static string AccessTokenCreated = "Token oluşturuldu.";
		public static string UserAlreadyExists = "Kullanıcı mevcut";
		public static string SuccessfulLogin = "Başarılı giriş";
		public static string PasswordError = "Parola hatası!";
		public static string UserNotFound = "Kullanıcı bulunamadı!";
		public static string UserRegistered = "Kayıt oldu";
	}
}
