using ClinicManagerAPI.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ClinicManager.UnitTests.CoreEntities
{
    public class PatientTests
    {
        [Fact]
        public void TestIfProjectStartWorks()
        {
            var patient = new Patient
            {
                Name = "John",
                Surname = "Doe",
                DateOfBirth = new System.DateTime(1990, 1, 1),
                PhoneNumber = "123456789",
                Email = "john@example.com",
                Cpf = "12345678900",
                BloodType = "O+",
                Height = 175,
                Weight = 70,
                Address = "123 Main St"
            };

            var result = patient.IsValid();

            Assert.IsTrue(result);
        }
        
    }
}
