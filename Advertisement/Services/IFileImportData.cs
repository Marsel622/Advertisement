namespace Advertisement.Services
{
    public interface IFileImportData
    {
        Dictionary<string, List<string>> ImportedData { get; set; }
    }

    public class FileImportData: IFileImportData
    {
        public Dictionary<string, List<string>> ImportedData { get; set; } = new();
    }
}
