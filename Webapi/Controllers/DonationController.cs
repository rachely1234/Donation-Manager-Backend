using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DAL.Interface;
//using DAL.Data;
using Models.Model;
using Microsoft.AspNetCore.Components.Authorization;
using System.Reflection.Metadata.Ecma335;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DAL.DTO;

namespace Webapi.Controllers

{
  
    [Route("api/[controller]")]
    [ApiController]
    public class DonationController : ControllerBase
    {
        private readonly IDonation _donation;

        public DonationController(IDonation donation)
        {
            _donation = donation;
        }

        [HttpPost]
        public async Task<ActionResult<DonationDTO>> PostDonation (DonationDTO donation)
        {
            if (donation == null)
            {
                return BadRequest("Donation details are required.");
            }

            try
            {
                // שמירה למסד הנתונים באמצעות הפונקציה האסינכרונית PutDonation
                var ans = await _donation.AcceptedDonation(donation);

                if (ans != null)
                {
                    return Ok("Donation saved successfully.");
                }
                else
                {
                    return BadRequest("Failed to save donation.");
                }
            }
            catch (DbUpdateException ex)
            {
                // טיפול בשגיאה בעדכון למסד הנתונים
                return StatusCode(500, $"Error saving donation: {ex.Message}");
            }
        }










    }
}
