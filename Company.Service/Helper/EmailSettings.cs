using System.Net;
using System.Net.Mail;

namespace Company.Service.Helper
{
	public class EmailSettings
	{
		public static void SendEmail(Email input) {
			var client = new SmtpClient("smtp.gmail.com",587);
			client.EnableSsl = true;
			client.Credentials = new NetworkCredential("mohamed.fadl.0798@gmail.com", "tjikhnbvbuecnsbq");
			client.Send("mohamed.fadl.0798@gmail.com", input.To, input.Subject, input.Body);
		
		}
	}
}
