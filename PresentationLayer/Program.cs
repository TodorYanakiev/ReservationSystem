using BusinessLogic.Services.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayerConsole;

class Program
{
    static async void Main(string[] args)
    {
        var smtpSettings = new SmtpSettings();

        var emailService = new EmailService(smtpSettings);
        await emailService.SendEmailAsync("todormaster25@gmail.com", "Test Subject", "Hello from .NET 8!");
        Console.WriteLine("okwwwwwwwwwwwww");

    }
}