using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Data;
using Server.Persistence;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdultController : ControllerBase
    {
        private IFileService _fileService;

        public AdultController(IFileService fileService)
        {
            _fileService = fileService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IList<Adult>>> GetAdultList()
        {
            try
            {
                IList<Adult> adultList = _fileService.ReadData<Adult>("");
                return Ok(adultList);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult<IList<Adult>>> AddAdultList([FromBody] IList<Adult> adultList)
        {
            try
            {
                _fileService.SaveChanges(adultList);
                return Created(@"/adult", adultList);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}