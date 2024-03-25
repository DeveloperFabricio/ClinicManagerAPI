using ClinicManager.Application.Calendary;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.Application.BackgroundServices
{
    public class EventNotificationService : BackgroundService
    {
        private readonly IConfiguration _configuration;

        public EventNotificationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var today = DateTime.Today;
                var yesterday = today.AddDays(-1);

                var calendarService = new GoogleCalendarService(_configuration);
                var events = await calendarService.GetEventsOnDateAsync(yesterday, stoppingToken);

                if (events != null && events.Any())
                {
                    foreach (var evt in events)
                    {
                        await SendNotificationAsync(evt.Summary, evt.Description, stoppingToken);
                    }
                }

               
                await Task.Delay(TimeSpan.FromHours(24), stoppingToken);
            }
        }

        private async Task SendNotificationAsync(string subject, string message, CancellationToken cancellationToken)
        {
            try
            {
                
                using (SmtpClient client = new SmtpClient())
                {
                    
                    client.Host = "seu.servidor.smtp";
                    client.Port = 587;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("fabricio@gmail.com", "2525");
                    client.EnableSsl = true;

                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress("fabricio@gmail.com");
                    mailMessage.To.Add("fabricio@gmail.com");
                    mailMessage.Subject = subject;
                    mailMessage.Body = message;
                    mailMessage.IsBodyHtml = true;

                    await client.SendMailAsync(mailMessage);
                }

                Console.WriteLine("Notificação enviada com sucesso!");
            }
            catch (Exception)
            {
                Console.WriteLine($"Erro ao enviar notificação!");
            }
        }
    }
}


