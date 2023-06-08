using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using project_intro.Contracts;
using project_intro.Exceptions;
using project_intro.Filters;
using project_intro.Models;
using project_intro.Models.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_intro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[ServiceFilter(typeof(ICourseApiExceptionFilter))]
    public class ConfigController : ControllerBase
    {
        private IConfiguration _c;
        private RedisConfiguration _redisConfiguration;

        public ConfigController(IOptionsSnapshot<RedisConfiguration> redisConfiguration, IConfiguration c)
        {
            // IOptionsMonitor:
            // redisConfiguration.CurrentValue
            // redisConfiguration.OnChange(OnRedisConfigChanged);
            _c = c;
            _redisConfiguration = redisConfiguration.Value;
        }


        // command args : 
        // project-intro.exe Redis:UserName="LUP"
        [HttpGet]
        public ActionResult<RedisConfiguration> GetRedisConfig()
        {
            return Ok(_redisConfiguration);
        }

        [HttpGet("wow")]
        public ActionResult GetRedisConfig1()
        {
            return Ok(FromTo(typeof(Product), typeof(ProductDTO)));
        }

        private string FromTo(Type from , Type to)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"CreateMap<{from.Name}, {to.Name}>()");
            var allSourceProperties = from.GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
            foreach (var item in allSourceProperties.Select(x=>x.Name))
            {
                sb.AppendLine($".ForMember(x=> x.{item}, opt => opt.MapFrom(src => src.{item}))");
            }
            sb.Append(";");
            return sb.ToString();

            //
            //   .ForCtorParam("Name", opt => opt.MapFrom(src => src.ProductName))
            //   .ForCtorParam("Price", opt => opt.MapFrom(src => src.ProductPrice))
            //   .ForCtorParam("Id", opt => opt.MapFrom(src => src.ProductId));
        }



    }      
}



