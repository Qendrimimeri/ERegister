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

        [Route("getmunis")]
        public ActionResult GetMunis()
        {
            return Ok(_context.Municipalities.ToList().Select(x => new
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

        //Blloku
        [Route("getstreetbymuni")]
        public ActionResult GetStreetByMuni([FromQuery] int muniId)
        {
            var streets = _context.Streets.Where(v => v.MunicipalityId == muniId)
                .Select(x =>
                new
                {
                    Id = x.Id,
                    Name = x.Name
                });

            return Ok(streets);
        }
        [HttpPost]
        [Route("addstreet")]
        public ActionResult AddStreet([FromBody] AddStreetVM model)
        {
            _context.Streets.Add(new Street
            {
                Name = model.StreetName,
                MunicipalityId = model.MunicipalityId
            });
            _context.SaveChanges();

            return Ok();
        }

        //[Route("getqendravotimitbyvillage")]
        //public ActionResult GetQendraVotimitbyVillage([FromQuery] int villId)
        //{
        //    var qendraVotimit = _context.QendraVotimits.Where(v => v.VillageId == villId)
        //        .Select(x =>
        //        new
        //        {
        //            Id = x.Id,
        //            Name = x.Name
        //        });

        //    return Ok(qendraVotimit);
        //}

        //[HttpPost]
        //[Route("addqendravotimit")]
        //public ActionResult AddQendraVotimit([FromBody] AddQendraVotimitViewModel model)
        //{
        //    _context.QendraVotimits.Add(new QendraVotimit
        //    {
        //        Name = model.QendraVotimitName,
        //        VillageId = model.VillageId
        //    });
        //    _context.SaveChanges();
        //    return Ok();
        //}
    }
}
