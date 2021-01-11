using System.IO;
using System.Threading.Tasks;

namespace PrjPortfolio.Interfaces
{
    public interface IPictureService
    {
        Task<bool> DeleteImage(string fileName);
        Task<string> UploadImage(string fileName, Stream image);
    }
}
