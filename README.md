RestaurantApp
Geliştirmekte olduğum RestaurantApp kullanıcıların kayıt olup siparişlerini verebileceği, restoranın ürünlerini ekleyip güncelleyebileceği bir sipariş uygulaması olması hedeflenmektedir.
Dependency Injection Design Pattern, Options Design Pattern, Repository Design Pattern gibi patternler kullanılarak ve SOLID prensipleri göz önünde tutularak, temiz kod ve geliştirilmeye açık olmasına dikkat edilmiştir.
Uygulamada kullanılan teknoloji ve kütüphaneler;

.Net Core
MSSQL
Entity Framework Core
Fluent Validation
AutoMapper
JWT
Autofac
Identity
Identity kütüphanesi kullanılarak yetkilendirme ve JWT tabanlı authentication işlemi uygulanmıştır.

Kullanıcı gerekli bilgileri girerek kayıt olabilir, User/CreateUser ile kayıt olduktan sonra Login olarak token alabilir.
Müşteri dışındaki kullanıcılar için, User/CreateUserRole ile Rol oluşturup, istenilen kullanıcıya rol atanabilir.
Login olduktan sonra alınan refresh token veritanına kaydedilir ve refresh token ile Auth/CreateTokenByRefreshToken kullanılarak token süresi bittikten sonra yeni token alınabilir, böylece kullanıcı Logout durumuna düşmez.
İstenildiği takdirde Auth/RevokeRefreshToken kullanılarak refresh token geçersiz kılınır.
Projeyi; WebApi altındaki appsettings.json dosyasında ConnectionString'i değiştirip migration ekleyerek direk çalıştırabilirsiniz.
