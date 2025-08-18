using Advertisement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Advertisement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileImportController : ControllerBase
    {
        private readonly IFileImportData _fileImportData;

        public FileImportController(IFileImportData fileImportData)
        {
            _fileImportData = fileImportData;
        }

        [HttpPost ("upload")]
        public async Task Import(IFormFile file)
        {
            var FileImportData = new Dictionary<string, List<string>>();
            using(StreamReader fileReader = new StreamReader(file.OpenReadStream()))
            {
                string? textline;
                while ((textline = await fileReader.ReadLineAsync()) !=null)
                {
                    string[] splitline = textline.Split(new char[] {':'});
                    string[] splitpath = splitline[1].Split(new char[] {','});

                    FileImportData.Add(splitline[0], splitpath.ToList());
                }
            }
            _fileImportData.ImportedData = FileImportData;
        }

    }
}
