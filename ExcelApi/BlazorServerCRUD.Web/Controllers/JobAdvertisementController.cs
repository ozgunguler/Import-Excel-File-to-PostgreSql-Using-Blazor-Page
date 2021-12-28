using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using BlazorServerCRUD.Web.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;

namespace BlazorServerCRUD.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobAdvertisementController : ControllerBase
    {
        private IWebHostEnvironment _hostingEnvironment;

        public JobAdvertisementController(IWebHostEnvironment hostingEnvironment)
        {
               _hostingEnvironment = hostingEnvironment; 
        }
        
        [HttpPost("[action]")]

        public void Save(IList<IFormFile> UploadFiles)
        {
            long size = 0;
            try
            {
                foreach(var file in UploadFiles)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.TrimStart('\"').TrimEnd('\"');
                    fileName =_hostingEnvironment.ContentRootPath + $@"\wwwroot\files\{fileName}";
                    size += file.Length;

                    if(!System.IO.File.Exists(fileName))
                    {
                        using(FileStream fileStream = System.IO.File.Create(fileName))
                        {
                            file.CopyTo(fileStream);
                            fileStream.Flush();
                        }
                    }
                    else{

                        using (FileStream fileStream = System.IO.File.Open(fileName, FileMode.Append)){
                            file.CopyTo(fileStream);
                            fileStream.Flush();

                        }
                    }
                }
            }
            catch (Exception e)
            {
                Response.Clear();
                Response.StatusCode = 204;
                Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "File failed to upload";
                Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = e.Message;
            }
        }


       [HttpPost("[action]")]

        public void Remove(IList<IFormFile> UploadFiles)
        {
            try
            {
                var fileName = _hostingEnvironment.ContentRootPath + $@"\wwwroot\files\{UploadFiles[0].FileName}";
                if(System.IO.File.Exists(fileName))
                {
                    System.IO.File.Delete(fileName);
                }
            
            }
            catch (Exception e)
            {
                Response.Clear();
                Response.StatusCode = 204;
                Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "File removed succesfully";
                Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = e.Message;
            }
        } 
    }
}   