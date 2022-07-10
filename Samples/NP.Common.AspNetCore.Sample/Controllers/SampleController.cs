using Microsoft.AspNetCore.Mvc;
using NP.Common.AspNetCore.Extensions;
using NP.Common.Extensions;
using NP.Common.Responses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NP.Common.AspNetCore.Sample.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SampleController : ControllerBase
	{
		// GET: api/<SampleController>
		[HttpGet]
		public IActionResult Get()
		{
			return new SuccessResponse<string[]>("Get",new string[] { "value1", "value2" }.AsMaybe()).ToActionResult(HttpContext.RequestServices);
		}

		// GET api/<SampleController>/5
		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			return new SuccessResponse<string>($"value for {id}").ToActionResult(HttpContext.RequestServices);
		}

		// POST api/<SampleController>
		[HttpPost]
		public IActionResult Post([FromBody] SampleValue value)
		{
			return new ErrorResponse("Not Implemented").ToActionResult(HttpContext.RequestServices);
		}

		// PUT api/<SampleController>/5
		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] SampleValue value)
		{
			return new SuccessResponse<string>($"Updated: {id}, with: {value}").ToActionResult(HttpContext.RequestServices);
		}

		// DELETE api/<SampleController>/5
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			return new BadInputResponse($"Cannot Delete: {id}").ToActionResult(HttpContext.RequestServices);
		}
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="Value"></param>
	public record SampleValue(string Value);
}