using KOF.Models;
using Microsoft.AspNetCore.Mvc;

namespace KOF.Controllers;

[ApiController]
[Route("[controller]")]
public class PowerCardController : ControllerBase
{
    public List<PowerCard>? _powerCards;
    private readonly PowerCardController _instance;

    public PowerCardController()
    {
        _instance = this;
    }

    [HttpGet(Name = "GetPowerCard")]
    public IEnumerable<PowerCard> Get()
    {
        /*Future fetch to db when id is passed

        if (id != null)
        {
            return _powerCards!.Select(card => card).Where(card => card.id == id).ToArray();
        }
        */
        return _powerCards!.Select(card => card).ToArray();
    }

    [HttpPost(Name = "PostPowerCard")]
    public IActionResult Post([FromForm] string name, int cost, int type)
    {
        var card = new PowerCard(name, cost, type);
        /*Future insert to db when id is passed

        if (input!= null)
        {
            insert
        }
        */
        return Ok(card);
    }
}
