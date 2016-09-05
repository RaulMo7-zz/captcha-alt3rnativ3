using System;
using System.Web.Http;
using Provider;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class CaptchaController : ApiController
    {

        public IHttpActionResult GetCaptcha()
        {
            ImageGenerator generator = new ImageGenerator();
            return Ok(generator.Generate());
        }

    }
}
