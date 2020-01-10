using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Castle.Windsor;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Siemens.Backend.Core.ConfigurationRepository;
using Siemens.Crosscutting.Utilities.Installer;
using Test.Poco;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [EnableQuery]
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<AcsSettingMapping>> Get()
        {
            var container = new WindsorContainer();
            container.Install(new GeneralInstaller());


            try
            {
                Mapper.CreateMap<Siemens.Backend.Core.ConfigurationModel.AcsSettingMapping, AcsSettingMapping>();

                Mapper.CreateMap<Siemens.Backend.Core.ConfigurationModel.Station, Station>()
                .ForMember(acsStation => acsStation.Id, x => x.MapFrom(turbine => turbine.Id))
                .ForMember(acsStation => acsStation.IpAddress, x => x.MapFrom(turbine => turbine.IpAddress.Address.ToString()))
                .ForMember(acsStation => acsStation.CommunicationId, x => x.MapFrom(turbine => turbine.CommunicationId))
                .ForMember(acsStation => acsStation.Enabled, x => x.MapFrom(turbine => turbine.Enabled))
                .ForMember(acsStation => acsStation.Name, x => x.MapFrom(turbine => turbine.Name));

                Mapper.CreateMap<Siemens.Backend.Core.ConfigurationModel.AcsSetting, AcsSetting>()
                .ForMember(acsStation => acsStation.Id, x => x.MapFrom(turbine => turbine.Id))
                .ForMember(acsStation => acsStation.Description, x => x.MapFrom(turbine => turbine.Description))
                .ForMember(acsStation => acsStation.IsDeleted, x => x.MapFrom(turbine => turbine.IsDeleted));

                /*Mapper.CreateMap<Station, StationD>()
                .ForMember(acsStation => acsStation.Id, x => x.MapFrom(turbine => turbine.Id))
                .ForMember(acsStation => acsStation.IpAddress, x => x.MapFrom(turbine => turbine.IpAddress.Address.ToString()))
                .ForMember(acsStation => acsStation.CommunicationId, x => x.MapFrom(turbine => turbine.CommunicationId))
                .ForMember(acsStation => acsStation.Enabled, x => x.MapFrom(turbine => turbine.Enabled))
                .ForMember(acsStation => acsStation.Name, x => x.MapFrom(turbine => turbine.Name));*/
                
                //var repo = container.Resolve<IStationRepository>();

                var repo = container.Resolve<IAcsSettingMappingRepository>();

                var res = Mapper.Map<IEnumerable<AcsSettingMapping>>(repo.GetAllAcsMapping().ToList()).ToList();

                return res;
            }
            catch (Exception e)
            {

                throw;
            }
            

            var obj1 = new KeyVal { Key = "One", Value = 1 };
            var obj2 = new KeyVal { Key = "Two", Value = 2 } ;
            var obj3 = new KeyVal { Key = "Five", Value = 5 } ;
            var obj4 = new KeyVal { Key = "Nine", Value = 9 } ;
            var obj5 = new KeyVal { Key = "HundredFive", Value = 105 } ;
            var obj6 = new KeyVal { Key = "SixtyFive", Value = 65 };

            var vals = new List<KeyVal>() { obj1 , obj2, obj3, obj4, obj5, obj6 };

            //var uow = new TestUnitOfWork();

            //var result = new StationRepository()

            //return new List<StationD>();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public class KeyVal
    {
        public string Key { get; set; }
        public int Value { get; set; }

    }

    public class StationD
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IpAddress { get; set; }
        public int CommunicationId { get; set; }
        public bool Enabled { get; set; }
    }
}
