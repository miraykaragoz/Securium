using Microsoft.AspNetCore.Mvc;
using PasswordGenerator.Models;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using Microsoft.Data.SqlClient;

namespace PasswordGenerator.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("/PasswordGenerator")]
        public IActionResult PasswordGenerator()
        {
            return View();
        }

        [HttpPost]
        [Route("/NewsLetter")]
        public IActionResult NewsLetter(Form model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Eksik veya hatalı form.");
            }

            var body = @"
<h1>Securium'a Hoş Geldiniz!</h1>
<p>Değerli Üyemiz,</p>

<p>Securium, güçlü ve güvenli şifreler oluşturmanıza yardımcı olmak için tasarlandı. Artık çevrimiçi hesaplarınız için güvenlik endişelerini geride bırakabilirsiniz. Bizimle birlikte olduğunuz için teşekkür ederiz!</p>

<h2>Öne Çıkan Özelliklerimiz:</h2>
<ul>
    <li><strong>Güçlü Şifre Üretimi:</strong> Karmaşık ve tahmin edilmesi zor şifreler oluşturun.</li>
    <li><strong>Kullanıcı Dostu Arayüz:</strong> Hızlı ve kolay kullanım için optimize edildi.</li>
    <li><strong>Güvenlik Önlemleri:</strong> Verilerinizi korumak için en yüksek güvenlik standartlarını kullanıyoruz.</li>
</ul>

<p>Hemen başlayın ve Securium ile çevrimiçi güvenliğinizi artırın!</p>

<p>Herhangi bir sorunuz veya geri bildiriminiz varsa, lütfen bizimle iletişime geçmekten çekinmeyin.</p>

<p>Güvenli günler dileriz!</p>
<p><strong>Securium Ekibi</strong></p>
";

            var client = new SmtpClient("smtp.eu.mailgun.org", 587)
            {
                Credentials = new NetworkCredential("postmaster@bilgi.miraykaragoz.com.tr",
                    "593f12a54d7b37b22ee27df74059c35d-8a084751-a9740350"),
                EnableSsl = true
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("postmaster@bilgi.miraykaragoz.com.tr"),
                Subject = "NewsLetter'a abone oldunuz!",
                Body = body,
                IsBodyHtml = true,
            };

            mailMessage.To.Add(new MailAddress(model.Email));

            client.Send(mailMessage);

            return View("Index");
        }
    }
}