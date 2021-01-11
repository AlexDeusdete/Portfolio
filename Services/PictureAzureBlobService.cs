using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Configuration;
using PrjPortfolio.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PrjPortfolio.Services
{
    public class PictureAzureBlobService : IPictureService
    {        
        private readonly BlobServiceClient _client;
        private readonly BlobContainerClient _containerClient;

        public PictureAzureBlobService(IConfiguration configuration)
        {
            _client = new BlobServiceClient(configuration.GetConnectionString("ACS"));
            _containerClient = _client.GetBlobContainerClient("pictures");
        }

        public async Task<bool> DeleteImage(string fileName)
        {
            try
            {
                var result = await _containerClient.DeleteBlobAsync(fileName);
                return result.Status == 202;
            }
            catch
            {
                return false;
            }


        }

        public async Task<string> UploadImage(string fileName, Stream image)
        {
            BlobClient blobClient = _containerClient.GetBlobClient(fileName);
            var result = await blobClient.UploadAsync(image, new BlobHttpHeaders { ContentType = "image/png" });

            if (result.GetRawResponse().Status == 201)
                return "https://crochet.blob.core.windows.net/thumbnails/" + fileName;
            else
                return "";
        }
    }
}
