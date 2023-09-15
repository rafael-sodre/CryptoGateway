using CryptoGateway.Core.Services;
using CryptoGateway.Core.Services.Interfaces;
using CryptoGateway.Domain.Model;
using CryptoGateway.Domain.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CryptoGateway.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RedisController : ControllerBase
{
    private readonly IRedisService _redisService;

    public RedisController(IRedisService redisService)
    {
        _redisService = redisService ?? throw new ArgumentNullException(nameof(redisService));
    }

    [HttpGet("{key}")]
    public IActionResult Get(string key)
    {
        return Ok( new RedisResponse(){ value = _redisService.GetValue(key) });
    }

    [HttpPost]
    public IActionResult Post([FromBody] KeyValueModel model)
    {
        _redisService.SetValue(model.Key, model.Value, TimeSpan.FromSeconds(3600));
        return Ok();
    }

    [HttpDelete("{key}")]
    public IActionResult Delete(string key)
    {
        var success = _redisService.DeleteKey(key);
        return success ? Ok() : NotFound();
    }
}