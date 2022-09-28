using Application.Repository;
using Application.ViewModels;
using Domain.Data;
using Domain.Data.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
#pragma warning disable CS8602
#pragma warning disable CS8604

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


        [Route("kqzresultsbymuni")]
        public ActionResult KqzResultsbymuni()
        {
            // zgjedhjet nacionale te vitit 2021 
            var zgjedhjetNacionaleDB = _context.Kqzregisters.Where(x => x.ElectionType == "Zgjedhjet Nacionale")
            .Select(x => new KqzLastYear()
            {
                PoliticalSubject = x.PoliticialSubject.Name,
                NumberOfVotes = (int)x.NoOfvotes,
            }).ToList();

            var zgjedhjetNacionale = new Dictionary<string, int>();

            foreach (var voter in zgjedhjetNacionaleDB)
                if (!zgjedhjetNacionale.Any(x => x.Key == voter.PoliticalSubject))
                    zgjedhjetNacionale.Add(voter.PoliticalSubject, voter.NumberOfVotes);
                else if (zgjedhjetNacionale.Any(x => x.Key == voter.PoliticalSubject))
                {
                    var value = zgjedhjetNacionale.Where(x => x.Key == voter.PoliticalSubject).FirstOrDefault().Value;
                    zgjedhjetNacionale[voter.PoliticalSubject] = voter.NumberOfVotes + value;
                }


            // zgjedhjet Lokale te vitit 2021 
            var zgjedhjetLokaleDB = _context.Kqzregisters.Where(x => x.ElectionType == "Zgjedhjet Lokale")
            .Select(x => new KqzLastYear()
            {
                PoliticalSubject = x.PoliticialSubject.Name,
                NumberOfVotes = (int)x.NoOfvotes,
            }).ToList();

            var zgjedhjetLokale = new Dictionary<string, int>();

            foreach (var voter in zgjedhjetLokaleDB)
                if (!zgjedhjetLokale.Any(x => x.Key == voter.PoliticalSubject))
                    zgjedhjetLokale.Add(voter.PoliticalSubject, voter.NumberOfVotes);
                else if (zgjedhjetLokale.Any(x => x.Key == voter.PoliticalSubject))
                {
                    var value = zgjedhjetLokale.Where(x => x.Key == voter.PoliticalSubject).FirstOrDefault().Value;
                    zgjedhjetLokale[voter.PoliticalSubject] = voter.NumberOfVotes + value;
                }





            var rez = _context.PollRelateds.ToList();
            var removeDuplicated = new List<PollRelated>();

            foreach (var user in rez.OrderByDescending(x => x.Date))
                if (!removeDuplicated.Any(x => x.UserId == user.UserId))
                    removeDuplicated.Add(user);
            var voters = new List<CurrentVoters>();
            foreach (var user in removeDuplicated)

                voters.Add(new CurrentVoters()
                {
                    Municipality = "Prishtine",
                    NumberOfVotes = user.FamMembers,
                    PoliticalSubject = _context.PoliticalSubjects.Where(x => x.Id == user.PoliticialSubjectId)
                                                                 .FirstOrDefault().Name
                });
            var gruping = new Dictionary<string, int>();
            foreach (var voter in voters)
                if (!gruping.Any(x => x.Key == voter.PoliticalSubject))
                    gruping.Add(voter.PoliticalSubject, voter.NumberOfVotes);
                else if (gruping.Any(x => x.Key == voter.PoliticalSubject))
                {
                    var value = gruping.Where(x => x.Key == voter.PoliticalSubject).FirstOrDefault().Value;
                    gruping[voter.PoliticalSubject] = voter.NumberOfVotes + value;
                }



            var nacionale = new KqzResultsByCity()
            {
                LastYear = zgjedhjetNacionale,
                ThisYear = gruping
            };

            var lokale = new KqzResultsByCity()
            {
                LastYear = zgjedhjetLokale,
                ThisYear = gruping
            };

            var zgjedhjet = new Dictionary<string, KqzResultsByCity>
            {
                { "Nacionale", nacionale },
                { "Lokale", lokale }
            };
            return Ok(zgjedhjet);
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
#pragma warning restore CS8602
#pragma warning restore CS8604
}
