﻿using ClinicManagerAPI.Entities;
using ClinicManagerAPI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.UnitTest.CoreEntities
{
    public class ServiceClinicTests
    {
        [Fact]
        public void TestIfProjectStartWorks()
        {
            var serviceClinic = new ServiceClinic
            {
                IdPatient = new Patient(),
                IdService = new Service(),
                IdDoctor = new Doctor(),
                HealthInsurance = "Insurance",
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(1),
                TypeServices = TypeServiceEnum.Receita
            };

            var result = serviceClinic.IsValid();

            Assert.True(result);

        }
    }
}
