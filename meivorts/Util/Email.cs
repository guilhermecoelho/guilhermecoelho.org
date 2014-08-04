using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace meivorts.Util
{
    /// <summary>
    /// Configura e envia email
    /// </summary>
    public class Email
    {
        MailMessage clsEmail = new MailMessage();


        public void configuraEmail()
        {
            //remetente
            clsEmail.From = new MailAddress("guilhermecoelho2@gmail.com");

            //destinatario
            clsEmail.To.Add("guilhermecoelho2@gmail.com");

            //propriedades email
            clsEmail.Priority = MailPriority.Normal;

            //ativa modo html
            clsEmail.IsBodyHtml = true;

            //assunto email
            clsEmail.Subject = "teste";

            //mensagem
            clsEmail.Body = "<p>testando</p> Funcionou?";

            //codificação do assunto do email para que os caracteres acentuados serem reconhecidos.
            clsEmail.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1");

            //codificação do corpo do emailpara que os caracteres acentuados serem reconhecidos.
            clsEmail.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");

            //cria o objeto responsável pelo envio do email
            SmtpClient clsSmtp = new SmtpClient();

            //endereco smpt
            clsSmtp.Host = "smtp.gmail.com";
            clsSmtp.Port = 465;
            clsSmtp.EnableSsl = true;
            clsSmtp.Credentials = new NetworkCredential("guilhermecoelho2", "c0elhito05*");
        }

    }
}