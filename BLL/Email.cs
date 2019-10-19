using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using Entity;

namespace BLL
{
    public class Email
    {
        public MailMessage CrearEmail(string correo) {
            Attachment data = new Attachment(@"sarasoft3.pdf");
            MailMessage Email = new MailMessage();
            Email.To.Add(correo);
            Email.From = new MailAddress("luismanueldiazsequea@gmail.com");
            Email.Subject = "Registro de usuario" + DateTime.Now.ToString("dd/mmm/yyy hh:mm:ss");
            Email.Body = $"Factura de venta. Tienda SARA";
            Email.IsBodyHtml = true;
            Email.Priority = MailPriority.Normal;
            Email.Attachments.Add(data);
            return Email;
        }
        public SmtpClient ConfigurarSMTP() {
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("luismanueldiazsequea@gmail.com", "lumadise");

            return smtp;
        }
        public string EnviarEmail(string correo) {
            string resultado = string.Empty;
            try {
                SmtpClient smtp = ConfigurarSMTP();
                MailMessage email = CrearEmail(correo);
                smtp.Send(email);
                email.Dispose();
                resultado = "Correo electrónico enviado";
            } catch (Exception e) {
                resultado = "Error al enviar correo electrónico" + e.Message;
            }
            return resultado;
        }
    }
}