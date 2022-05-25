using Domain;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FolderController : ControllerBase
    {
        private FolderService folderService;

        public FolderController( FolderService folderService)
        {
           
            this.folderService = folderService;
        }

        [HttpPost("CopyToFolderAsync")]
        public async Task<int> CopyToFolderAsync([FromForm]Folder folder)
        {
            return await folderService.CopyToFolderAsync(folder);
        }

        [HttpPost("CopyToListFoldersAsync")]
        public async Task<string> CopyToListFoldersAsync([FromForm] Folders folders)
        {
            return await folderService.CopyToListFoldersAsync(folders);
        }

        [HttpPost("CopyToListIFormFilesAsync")]
        public async Task<string> CopyToListIFormFilesAsync([FromForm] List<IFormFile> file)
        {
            return await folderService.CopyToListIFormFilesAsync(file);
        }

    }
}
