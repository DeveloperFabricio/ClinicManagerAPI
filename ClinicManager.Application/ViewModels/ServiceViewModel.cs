using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.Application.ViewModels
{
    public class ServiceViewModel
    {
        public ServiceViewModel(int id, string name, decimal value)
        {
            Id = id;
            Name = name;
            Value = value;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
    }
}
