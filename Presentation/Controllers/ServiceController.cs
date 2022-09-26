﻿  using Application.Repository;
using Application.ViewModels;
using Domain.Data;
using Domain.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _context;

        public ServiceController(IUnitOfWork unit, ApplicationDbContext context)
        {
            _unitOfWork = unit;
            _context = context;
        }
        //poll center
        [Route("getpollcenter")]
        public ActionResult GetPollCenter()
        {
            return Ok(_context.PollCenters.ToList().Select(x => new
            {
                Id = x.Id,
                CenterNumber = x.CenterNumber
            }));
        }

        [Route("getpollcenterbyid")]
        public ActionResult GetPollCenterById([FromQuery] string id)
        
        {
            var qendra = _context.PollCenters.Where(v => v.CenterNumber == id)
                .Select(x =>
                new
                {
                    Id = x.Id,
                    CenterNumber = x.CenterNumber,
                    CenterName = x.CenterName,
                    MuniCipalityId = x.MunicipalitydId
                });

            return Ok(qendra);
        }

        [HttpPost]
        [Route("addpollcenter")]
        public ActionResult AddPollCenter([FromBody] PollCenterVM model)
        {
            _context.PollCenters.Add(new PollCenter
            {
                Id = model.Id,
                CenterNumber = model.CenterNumber,
                CenterName = model.CenterName,
                MunicipalitydId = model.MunicipalitydId

            });

            _context.SaveChanges();

            return Ok();
        }

        [Route("getkqzresult")]
        public ActionResult GetKqzResult()
        {
            return Ok(_context.Kqzregisters.ToList());
            //.Select(x => new
            //{
            //    Id = x.Id,
            //    Date = x.DataCreated
          
            //}));
        }
        
        /// get specific reason 
       
        [Route("getgeneraldemand")]

        public ActionResult GetGeneralDemand()
        {
            return Ok(_context.PollRelateds.ToList());
        }
        //add general demand 
        [HttpPost]
        [Route("addgeneraldemand")]
        public ActionResult AddGeneralDemand([FromBody] GeneralDemandVM model)
        {
            _context.PollRelateds.Add(new PollRelated
            {
                Id = model.Id,
                SpecificReason = model.SpecificReason
            });

            _context.SaveChanges();

            return Ok();
        }
        //get help  // specific demand
        [Route("gethelp")]

        public ActionResult GetNeedHelp()
        {
            return Ok(_context.PollRelateds.ToList());
        }
        //add help
        [HttpPost]
        [Route("GetNeedHelp")]   
        public ActionResult AddHelp([FromBody] GeneralDemandVM model)
        {
            _context.PollRelateds.Add(new PollRelated
            {
                Id = model.Id,
                SpecificDemand = model.SpecificDemand
            });

            _context.SaveChanges();

            return Ok();
        }

        [HttpPost]
        [Route("addkqzresult")]
        public ActionResult AddKqzResult([FromBody] KqzRegisterVM model)
        {
            _context.Kqzregisters.Add(new Kqzregister
            {
                Id = model.Id,
                PoliticialSubjectId = model.PoliticialSubjectId,
                MunicipalityId = model.MunicipalityId,
                NoOfvotes = model.NoOfvotes,
                PollCenterId = model.PollCenterId,
                DataCreated = model.DataCreated,
                VillageId = model.VillageId,
                NeighborhoodId = model.NeighborhoodId,
                ElectionType = model.ElectionType
            });

            _context.SaveChanges();

            return Ok();
        }

        [Route("getmunis")]
        public ActionResult GetMunis()
        {
            return Ok(_context.Municipalities.ToList().Select(x => new
            {
                Id = x.Id,
                Name = x.Name
            }));
        }


        [Route("getvillage")]
        public ActionResult GetVillage()
        {
            return Ok(_context.Villages.ToList().Select(x => new
            {
                Id = x.Id,
                Name = x.Name
            }));
        }

        //fshat
        [Route("getvillagesbymuni")]
        public ActionResult GetVillagesByMuni([FromQuery] int muniId)
        {
            var villages = _context.Villages.Where(v => v.MunicipalityId == muniId)
                .Select(x =>
                new
                {
                    Id = x.Id,
                    Name = x.Name
                });

            return Ok(villages);
        }
        [HttpPost]
        [Route("addvillage")]
        public ActionResult AddVillage([FromBody] AddVillageVM model)
        {
            _context.Villages.Add(new Village
            {
                Name = model.VillageName,
                MunicipalityId = model.MunicipalityId
            });

            _context.SaveChanges();

            return Ok();
        }

        //Lagje
        [Route("getneighborhoodsbymuni")]
        public ActionResult GetNeighborhoodByMuni([FromQuery] int muniId)
        {
            var neighborhoods = _context.Neighborhoods.Where(v => v.MunicipalityId == muniId)
                .Select(x =>
                new
                {
                    Id = x.Id,
                    Name = x.Name
                });

            return Ok(neighborhoods);
        }
        [HttpPost]
        [Route("addneighborhood")]
        public ActionResult AddNeighborhood([FromBody] AddNeighborhoodVM model)
        {
            _context.Neighborhoods.Add(new Neighborhood
            {
                Name = model.NeighborhoodName,
                MunicipalityId = model.MunicipalityId
            });
            _context.SaveChanges();

            return Ok();
        }
        //Lagje per fshat
        [Route("getneighborhoodsbyvillage")]
        public ActionResult GetNeighborhoodByVillage([FromQuery] int villId)
        {
            var neighborhoods = _context.Neighborhoods.Where(v => v.VillageId == villId)
                .Select(x =>
                new
                {
                    Id = x.Id,
                    Name = x.Name
                });
            return Ok(neighborhoods);
        }
        [HttpPost]
        [Route("addneighborhoodbyvillage")]
        public ActionResult AddNeighborhoodByVillage([FromBody] AddNeighborhoodVM model)
        {
            _context.Neighborhoods.Add(new Neighborhood
            {
                Name = model.NeighborhoodName,
                VillageId = model.VillageId
            });
            _context.SaveChanges();

            return Ok();
        }

        //Blloku
        [Route("getblocksbymuni")]
        public ActionResult GetBlockByMuni([FromQuery] int muniId)
        {
            var blocks = _context.Blocks.Where(v => v.MunicipalityId == muniId)
                .Select(x =>
                new
                {
                    Id = x.Id,
                    Name = x.Name
                });

            return Ok(blocks);
        }
        [HttpPost]
        [Route("addblock")]
        public ActionResult AddBlock([FromBody] AddBlockVM model)
        {
            _context.Blocks.Add(new Block
            {
                Name = model.BlockName,
                MunicipalityId = model.MunicipalityId
            });
            _context.SaveChanges();

            return Ok();
        }

        //street by village
        [Route("getstreetbyvillage")]
        public ActionResult GetStreetByVillage([FromQuery] int villId)
        {
            var streets = _context.Streets.Where(v => v.VillageId == villId)
                .Select(x =>
                new
                {
                    Id = x.Id,
                    Name = x.Name
                });
            return Ok(streets);
        }
        [HttpPost]
        [Route("addstreetbyvillage")]
        public ActionResult AddStreetByVillage([FromBody] AddStreetVM model)
        {
            _context.Streets.Add(new Street
            {
                Name = model.StreetName,
                VillageId = model.VillageId
            });
            _context.SaveChanges();

            return Ok();
        }

        //street by neighborhood
        [Route("getstreetbyneighborhood")]
        public ActionResult GetStreetByNeighborhood([FromQuery] int neighId)
        {
            var streets = _context.Streets.Where(n => n.NeighborhoodId == neighId)
                .Select(x =>
                new
                {
                    Id = x.Id,
                    Name = x.Name
                });
            return Ok(streets);
        }
        [HttpPost]
        [Route("addstreetbyneighborhood")]
        public ActionResult AddStreetByNeighborhood([FromBody] AddStreetVM model)
        {
            _context.Streets.Add(new Street
            {
                Name = model.StreetName,
                NeighborhoodId = model.NeighborhoodId
            });
            _context.SaveChanges();

            return Ok();
        }
        //pollCenter by village
        [Route("getpollcenterbyvillage")]
        public ActionResult GetPollCenterByVillage([FromQuery] int villId)
        {
            var streets = _context.PollCenters.Where(v => v.VillageId == villId)
                .Select(x =>
                new
                {
                    Id = x.Id,
                    Name = x.CenterName
                });
            return Ok(streets);
        }
        [HttpPost]
        [Route("addpollcenterbyvillage")]
        public ActionResult AddPollCenterByVillage([FromBody] PollCenterVM model)
        {
            _context.PollCenters.Add(new PollCenter
            {
                CenterName = model.CenterName,
                VillageId = model.VillageId
            });
            _context.SaveChanges();

            return Ok();
        }


        [HttpPost]
        [Route("addblock")]
        public ActionResult AddRole([FromBody] AddBlockVM model)
        {
            _context.Blocks.Add(new Block
            {
                Name = model.BlockName
            });
            _context.SaveChanges();

            return Ok();
        }
       
    }
}
