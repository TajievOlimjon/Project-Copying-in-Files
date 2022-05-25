using Domain;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public  class FolderService
    {
        private IWebHostEnvironment hostEnvironment;
        public FolderService(IWebHostEnvironment hostEnvironment)
        {
            this.hostEnvironment = hostEnvironment;    

        }

        public async Task<int> CopyToFolderAsync(Folder folder)
        {
            if (! folder.file.Equals(null))
            {
                var root = hostEnvironment.WebRootPath;
                var path = Path.Combine(root, "Uploads", folder.file.FileName);
                using (var filestream = new FileStream(path, FileMode.Create))
                {
                    await folder.file.CopyToAsync(filestream);
                }
                return 1;//"Saved!!";
            }
            return 0; /*"Not Saved!!!";*/
        }
    }
}
