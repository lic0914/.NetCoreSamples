using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace WebApplication1.Controllers
{
    public class TestController : Controller
    {
        private IHostingEnvironment _env;
        public TestController(IHostingEnvironment hosting )
        {
            _env = hosting;
        }
        public IActionResult Index(IFormFile file)
        {
            if (file==null)
            {
                return View();
            }
            
            var serverroot = _env.ContentRootPath;
            var path = Path.Combine(serverroot, "1.jpg");
            using (var fs = new FileStream(path, FileMode.Create))
            {
                file.OpenReadStream().CopyTo(fs);
                fs.Flush();
            }

            return Content("上传成功");
        
        }
    }
}