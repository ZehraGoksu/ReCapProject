# ReCapProject
## Araç Kiralama Projesi - Backend

Katmanlı mimari yapısı kullarak oluşturulmuş olan online bir araç kiralama projesinin backend kısmıdır. C# dilinde geliştirilen bu proje katmanları şu şekildedir;

  * Business : İş katmanıdır.Yetki kontrolleri vb. yazıldığı katmandır.
  * Core : Projenin temelini oluşturan katmandır. Genel kapsamlı operasyonlardan oluşmaktadır.
  * DataAccess : Veritabanı bağlantılarının oluşturulduğu katmandır.
  * Entities : Veritabanındaki tablolara nesne olarak erişimi sağlamak için yazılan katmandır.
  * WebAPI : Restful API katmanıdır. 

## Aşamalar
 * Proje için öncelikli olarak katmanlı mimari yapısı oluşturuldu.
 * Veritabanında gerekli tablolar oluşturuldu.(brands - carImages - cars - colors - customers - rentals - users)
 * Veri listemele, silme, ekleme ve güncelleme işlemeri her bir nesne için belirtildi ve gerekli şartlar eklendi.
 * WebAPI katmanını oluşturuldu ve tüm servislerin Api karşılığını yazılarak Postman'de test edildi.
 * Araçlar için görsel eklendi ve görseller ile ilgili verilen şartlar yazıldı.
 * Frontend projesine başlandı ve gerekli işlemler için backend üzerinde değişiklikler gerçekleştirildi.

