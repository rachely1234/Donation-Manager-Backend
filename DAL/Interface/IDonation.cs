using DAL.DTO;
using Microsoft.AspNetCore.Mvc;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IDonation
    {
      
        public Task<DonationDTO> AcceptedDonation(DonationDTO donation);





    }
}
