using Application.Repository;
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

        [Route("getpollcenterbyvillageid")]
        public ActionResult GetPollCenterByVillageId([FromQuery] int id)

        {
            var qendra = _context.PollCenters.Where(v => v.VillageId == id )
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

        [Route("getpollcenterbyneighborhoodid")]
        public ActionResult GetPollCenterByNeighborhoodId([FromQuery] int id)

        {
            var qendra = _context.PollCenters.Where(v => v.NeighborhoodId == id)
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

        [Route("getpollcenterbymuniid")]
        public ActionResult GetPollCenterByMuniId([FromQuery] int id)

        {
            var qendra = _context.PollCenters.Where(v => v.MunicipalitydId == id)
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

        [Route("getpoliticalsubjectbyname")]
        public ActionResult GetPoliticalSubjectByName([FromQuery] string name)

        {
            var qendra = _context.PoliticalSubjects.Where(v => v.Name == name);
                //.Select(x =>
                //new
                //{
                //    Id = x.Id,
                //    Name = x.Name,

                //}) ;

            return Ok(qendra);
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


        //[Route("getvillage")]
        //public ActionResult GetVillage()
        //{
        //    return Ok(_context.Villages.ToList().Select(x => new
        //    {
        //        Id = x.Id,
        //        Name = x.Name
        //    }));
        //}

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

  
       

       
       
    }
}
