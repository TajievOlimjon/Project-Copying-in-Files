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


    }
}
