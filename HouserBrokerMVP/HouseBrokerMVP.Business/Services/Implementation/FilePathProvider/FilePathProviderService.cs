namespace HouseBrokerMVP.Business.Services.FilePathProvider
{
    public abstract class FilePathProviderService(string baseUrl) : IFilePathProviderService
    {
        public string GetPropertyImageFilePath()
        {
            return baseUrl + "/Images/PropertyImage";
        }
    }
}
