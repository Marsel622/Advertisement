using Advertisement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Advertisement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchAdController : ControllerBase
    {
        private readonly IFileImportData _fileImportData;

        public SearchAdController(IFileImportData fileImportData)
        {
            _fileImportData = fileImportData;
        }

        [HttpGet("Ad")]
        public async Task <IActionResult> GetAd(string Ad)
        {
            List<string> fitsplatform = new List<string>();
            Ad = Ad.ToLower();
            foreach(var platform in _fileImportData.ImportedData)
            {
                foreach (var ads in platform.Value) 
                {
                    if (Ad.Contains(ads))
                    {
                        fitsplatform.Add(platform.Key);
                    }
                }
            }

            return Ok(fitsplatform);
        }
    }
}
