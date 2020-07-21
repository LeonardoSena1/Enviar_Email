using System;
using System.Net.Mail;

namespace EnviarEmail
{
    class Program
    {
        static void Main(string[] args)
        {
            EnviarEmail();
        }

        static string EnviarEmail()
        {
            SmtpClient client = new SmtpClient("smtp-mail.outlook.com");
            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            System.Net.NetworkCredential credentials =
                new System.Net.NetworkCredential("leonardo_sena1@hotmail.com", "senha");//Meu email
            client.EnableSsl = true;
            client.Credentials = credentials;
            client.TargetName = "smtp-mail.outlook.com";
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("leonardo_sena1@hotmail.com", string.Empty, System.Text.Encoding.UTF8);
                mail.To.Add(new MailAddress("leonardo.bulcao@srmidia.com.br"));//destinatario
                mail.Subject = "Teste de e-mail";//Assunto                

                mail.Body = "Teste de e-mail";//Corpo do envio
                client.Send(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }


            return string.Empty;
        }

    }
}
