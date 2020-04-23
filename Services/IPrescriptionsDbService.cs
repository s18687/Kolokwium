using Kolokwium.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Services
{
    public interface IPrescriptionsDbService
    {
        public Prescriptions GetPerscription(int IdPrescription);
        public NewPrescriptions CreatePerscription(NewPrescriptions newPer);
    }
}
