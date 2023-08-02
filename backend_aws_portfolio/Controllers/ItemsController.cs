using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using dotenv.net;

namespace backend_aws_portfolio.Controllers
{
         [ApiController]
        [Route("api/[controller]")]
        public class ItemsController : ControllerBase
        {
            // GET: api/<ItemsController>
            [HttpGet]
            public IEnumerable<string> Get()
            {
                return new string[] { "value1", "value2" };
            }

            // GET api/<ItemsController>/5
            [HttpGet("pdf")]
            public IActionResult GetPdf()
            {
                DotEnv.Load(); // // Loads the environment variables from .env
                               //var s3PdfUrl = "https://porfolio-truong.s3.amazonaws.com/Truong_Resume.pdf";
                string s3PdfUrl = System.Environment.GetEnvironmentVariable("PDF_URL");
                return Ok(s3PdfUrl);
            }

            // POST api/<ItemsController>
            [HttpPost]
            public void Post([FromBody] string value)
            {
            }

            // PUT api/<ItemsController>/5
            [HttpPut("{id}")]
            public void Put(int id, [FromBody] string value)
            {
            }

            // DELETE api/<ItemsController>/5
            [HttpDelete("{id}")]
            public void Delete(int id)
            {
            }
        }
    
}
    

