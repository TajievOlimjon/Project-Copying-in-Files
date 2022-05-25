using Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
            if (!folder.file.Equals(null))
            {
                var root = hostEnvironment.WebRootPath;
                var path = Path.Combine(root, "Uploads", folder.file.FileName);
                using (var filestream = new FileStream(path, FileMode.Create))
                {
                    await folder.file.CopyToAsync(filestream);
                }
                return 1;
            }
            return 0; 
        }

        public async Task<string> CopyToListFoldersAsync(Folders folders)
        {
            if (folders.file.Count > 0)
            {
                foreach (var file in folders.file)
                {
                    var root = hostEnvironment.WebRootPath;
                    var path = Path.Combine(root, "Uploads", file.FileName);
                    using (var filestream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(filestream);

                    }


                }
                return 1.ToString();
            }
            return 0.ToString();

        }

        public async Task<string> CopyToListIFormFilesAsync(List<IFormFile> files)
        {
            if (!files.Count.Equals(null))
            {
                foreach (var file in files)
                {
                    var root = hostEnvironment.WebRootPath;
                    var path = Path.Combine(root, "Uploads", file.FileName);
                    using (var filestream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(filestream);

                    }


                }
                return 1.ToString();
            }
            return 0.ToString();

        }
    }
}
