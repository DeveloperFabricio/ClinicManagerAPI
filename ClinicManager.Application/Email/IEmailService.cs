using ClinicManagerAPI.Entities;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.Application.Email
{
    public interface IEmailService
    {
        Task<bool> ServiceEmail(string email, string subject, string message);
    }
}
