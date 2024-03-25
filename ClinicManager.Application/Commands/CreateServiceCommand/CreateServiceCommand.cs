using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.Application.Commands.CreateServiceCommand
{
    public class CreateServiceCommand : IRequest<Unit>
    {
        public CreateServiceCommand(string name, string description, decimal value, int duration)
        {
            Name = name;
            Description = description;
            Value = value;
            Duration = duration;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public int Duration { get; set; }
    }
}
