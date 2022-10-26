using APICapstoneProject.Models;
using APICapstoneProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace APICapstoneProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : Controller
    {
        private readonly IMailService mailService;
        public MailController(IMailService mailService)
        {
            this.mailService = mailService;
        }
        [HttpPost("send")]
        public async Task<IActionResult> SendMail(MailRequest request)
        {
            try
            {
                await mailService.SendEmailAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }

        }


        
    }
}
