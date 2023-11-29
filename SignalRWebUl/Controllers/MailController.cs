using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SignalRWebUl.Dtos.MailDtos;

namespace SignalRWebUl.Controllers
{
	public class MailController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(CreateMailDto createMailDto)
		{
			MimeMessage mimeMessage = new MimeMessage();
			MailboxAddress mailboxAddressFrom = new MailboxAddress("SignalR Rezervasyon", "proje.denemelerim@gmail.com");
			mimeMessage.From.Add(mailboxAddressFrom);

			MailboxAddress mailboxAddressTo = new MailboxAddress("User", createMailDto.ReceiverMail);
			mimeMessage.To.Add(mailboxAddressTo);

			var bodyBuilder = new BodyBuilder();
			bodyBuilder.TextBody = createMailDto.Body;
			mimeMessage.Body = bodyBuilder.ToMessageBody();

			mimeMessage.Subject = createMailDto.Subject;

			SmtpClient client = new SmtpClient();
			client.ServerCertificateValidationCallback = (s, c, h, e) => true;
			client.Connect("smtp.gmail.com",587, SecureSocketOptions.Auto);
			client.Authenticate("proje.denemelerim@gmail.com", "yjwx hwys sybb lseq");

			client.Send(mimeMessage);
			client.Disconnect(true);

			return RedirectToAction("Index","Category");
		}
	}
}
