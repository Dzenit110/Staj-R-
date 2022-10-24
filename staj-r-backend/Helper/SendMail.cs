using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;

namespace staj_r_backend.Helper
{
    public class SendMail
    {
        public static async Task<bool> sendMail(string to, string caption, string message)
        {
            try
            {
                bool isBroken = false;
                var client = new SmtpClient("smtp-mail.outlook.com", 587)
                {
                    Credentials = new NetworkCredential("staj.r@outlook.com", "staj&R2022"),
                    EnableSsl = true
                };
                await Task.Run(() =>
                {
                    try
                    {
                        client.Send(new MailMessage("staj.r@outlook.com", to)
                        {
                            Subject = caption,
                            Body = message,
                            IsBodyHtml = true,
                            BodyEncoding = System.Text.Encoding.UTF8,
                        });
                    }
                    catch
                    {
                        isBroken = true;
                    }
                });
                if (isBroken)
                {
                    throw new Exception("Email cannot send");
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}



