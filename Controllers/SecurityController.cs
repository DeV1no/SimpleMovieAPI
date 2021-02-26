using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Services;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("api/security")]
    public class SecurityController : ControllerBase
    {
        private readonly IDataProtector _protector;
        private readonly HashService hashService;

        public SecurityController(IDataProtectionProvider protectionProvider, HashService hashService)
        {
            this.hashService = hashService;
            _protector = protectionProvider.CreateProtector("value_secret_and_unique");
        }

        [HttpGet]
        public IActionResult Get()
        {
            string plainText = "Danial Shokouhmanesh";
            string encryptedText = _protector.Protect(plainText);
            string decryptedText = _protector.Unprotect(encryptedText);

            return Ok(new {plainText, encryptedText, decryptedText});
        }

        [HttpGet("TimeBound")]
        public async Task<ActionResult> GetTimeBound()
        {
            var protextorTimeBound = _protector.ToTimeLimitedDataProtector();
            string plainText = "Danial Shokouhmanesh";
            string encryptedText = protextorTimeBound.Protect(plainText, lifetime: TimeSpan.FromSeconds(5));
            await Task.Delay(6000);
            string decryptedText = protextorTimeBound.Unprotect(encryptedText);
            return Ok(new {plainText, encryptedText, decryptedText});
        }

        [HttpGet("hash")]
        public IActionResult GetHash()
        {
            var plainText = "Danial Shokouhmanesh";
            var hashResult = hashService.Hash(plainText);
            var hashResult2 = hashService.Hash(plainText);
            return Ok(new {plainText, hashResult, hashResult2}); 
        }
    }
}