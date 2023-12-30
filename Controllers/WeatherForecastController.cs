using Microsoft.AspNetCore.Mvc;
using MySqlSampleConnection.Model;
using MySqlSampleConnection.UserDbContext;

namespace MySqlSampleConnection.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
       private readonly MyUserDbContext _db;


            public WeatherForecastController(MyUserDbContext db) {


            _db = db;
        }


        

       

        [HttpGet(Name = "GetWeatherForecast")]
        public List<User> Get()
        {
            var list = _db.user.ToList();

            return list;

        }
    }
}