using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace ImageUpload.Controllers
{
    [ApiController]
    public class ImageController : Controller
    {
        [HttpPost]
        [Route("api/uploadimage")]
        public ActionResult UploadImage(IEnumerable<IFormFile> files)
        {
            if(files.Count() < 1)
            {
                return BadRequest("File should not empty.");
            }

            List<string> filenames = new List<string>();
            var now = DateTime.Now;
            var filePath = string.Format("/uploads/{0}/{1}/{2}",now.ToString("yyyy"),now.ToString("yyyyMM"),now.ToString("yyyyMMdd"));
            var webRootPath = Environment.CurrentDirectory;
            if(!Directory.Exists(webRootPath+filePath))
            {
                Directory.CreateDirectory(webRootPath+filePath);
            }

            try
            {
                string fileFilt = ".gif|.jpg|.jpeg|.png";
                foreach(var item in files)
                {
                    if(null != item)
                    {
                        var fileExt = Path.GetExtension(item.FileName);
                        if(null == fileExt)
                        {
                            break;
                        }
                        if(fileFilt.IndexOf(fileExt.ToLower(),StringComparison.Ordinal) <=-1)
                        {
                            break;
                        }
                        long length = item.Length;
                        if(length > 2 * 1024 * 1024)
                        {
                            break;
                        }

                        var strDateTime = DateTime.Now.ToString("yyMMddhhmmssfff");
                        var strRan = Convert.ToString(new Random().Next(100,999));
                        var saveName = strDateTime+strRan+fileExt;

                        using(FileStream fs = new FileStream(webRootPath+filePath+saveName, FileMode.CreateNew, FileAccess.Write))
                        {
                            item.CopyTo(fs);
                            fs.Flush();
                        }
                        filenames.Add(filePath+saveName);
                    }
                }
                return Ok(filenames);
            }catch(Exception ex)
            {
                return BadRequest("Upload Fails");
            }
        }
    }
}