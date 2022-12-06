using KOT.Models;
using KOT.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KOT.Controllers;

[ApiController]
[Route("[controller]")]
public class ChooseDicesController : ControllerBase
{
    private readonly ISelectDiceService selectDicesInstance;

    public ChooseDicesController(ISelectDiceService instance)
    {
        selectDicesInstance = instance;
    }

    [HttpPost()]
    public IActionResult Post([FromBody] ChoosenDicePayload payload)
    {
        try
        {
            var result = selectDicesInstance.SelectDices(payload);
            return Ok(result);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
}
