using System;
using System.Web.Http;
using Provider;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class CaptchaController : ApiController
    {
        [Route("api/captcha/generate")]
        public IHttpActionResult GetCaptcha()
        {
            ImageGenerator generator = new ImageGenerator();
            return Ok(generator.Generate());
        }

        [Route("api/captcha/validate")]
        [HttpGet]
        public IHttpActionResult Validate()
        {
            return Ok(true);
        }

    }
}
