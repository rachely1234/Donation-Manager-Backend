using DAL.Interface;
using Models.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL.DTO;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;


namespace DAL.Implementation
{
    public class DonationService : IDonation
    {
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ProjectCotext _context;


        public DonationService(ProjectCotext context, IMapper mapper, IEmailService emailService)
        {
            _context = context;
            _mapper = mapper;
            _emailService = emailService;

        }

        public async Task<DonationDTO> AcceptedDonation(DonationDTO donation)
        {
            var donationToSave = _mapper.Map<DonationDetail>(donation);
            if (donation.DonationAmount >= 10000)
            {
                _emailService.SendEmailAsync(new SendEmailModel()
                {
                    Body = donation.DonationAmount.ToString(),
                    Subject = "Tanks..",
                    ToEmail = "Example.com"
                });
            }
            return donation;
          //TODO implement save db...


        }
    }
}
