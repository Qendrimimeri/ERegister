using Application.Models;
using Application.Models.Services;
using Application.Repository;
using Application.ViewModels;
using AutoMapper;
using Domain.Data;
using Domain.Data.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Web.WebPages;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : Controller
    {
#pragma warning disable CS8602
#pragma warning disable CS8604

        private readonly string errorView = "../Error/ErrorInfo";
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContext;
        private readonly ILogger<ServiceController> _logger;
        private readonly IMapper _mapper;

        public ServiceController(IUnitOfWork unit,
                                 ApplicationDbContext context,
                                 IHttpContextAccessor httpContext,
                                 ILogger<ServiceController> logger,
                                 IMapper mapper)
        {
            _unitOfWork = unit;
            _context = context;
            _httpContext = httpContext;
            _logger = logger;
            _mapper = mapper;
        }


        // Get All Poll Centers
        [Route("getpollcenter")]
        public IActionResult GetPollCenter()
        {
            var users = _context.PollCenters.ToList();

            var usersViewModel = _mapper.Map<List<PollCenterVM>>(users);

            return Ok(usersViewModel);
        }
        [Route("getpollcenterbyvillageid")]
        public ActionResult GetPollCenterByVillageId([FromQuery] int id)
        {
            try
            {
                var PollCeneterByVillage = _context.PollCenters.Where(v => v.VillageId == id).FirstOrDefault();
                var PollCeneterByVillageMap = _mapper.Map<PollCenterVM>(PollCeneterByVillage);
                return Ok(PollCeneterByVillageMap);
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occurred", err);
                return View(errorView);
            }
        }


        [Route("getpollcenterbyneighborhoodid")]
        public ActionResult GetPollCenterByNeighborhoodId([FromQuery] int id)
        {
            try
            {
                var PollCenterByNeighborhood = _context.PollCenters.Where(v => v.NeighborhoodId == id).FirstOrDefault();
                var PollCenterByNeighborhoodMap = _mapper.Map<PollCenterVM>(PollCenterByNeighborhood);

                return Ok(PollCenterByNeighborhoodMap);
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occurred", err);
                return View(errorView);
            }
        }


        [Route("getpollcenterbymuniid")]
        public ActionResult GetPollCenterByMuniId([FromQuery] int id)
        {
            try
            {
                var PollCenterrByMuniId = _context.PollCenters.Where(v => v.MunicipalitydId == id).FirstOrDefault();
                var PollCenterrByMuniIdMap = _mapper.Map<PollCenterVM>(PollCenterrByMuniId);

                return Ok(PollCenterrByMuniIdMap);
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occurred", err);
                return View(errorView);
            }

        }


        [Route("getpollcenterbyid")]
        public ActionResult GetPollCenterById([FromQuery] string id)
        {
            try
            {
                var PollCenterById = _context.PollCenters.Where(v => v.CenterNumber == id);
                var PollCenterByIdMap = _mapper.Map<PollCenterVM>(PollCenterById);
                return Ok(PollCenterByIdMap);
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occurred", err);
                return View(errorView);
            }
        }


        [HttpPost, Route("addpollcenter")]
        public ActionResult AddPollCenter([FromBody] PollCenterVM model)
        {
            try
            {
                var test = _mapper.Map<PollCenter>(model);

                _context.PollCenters.Add(test);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occurred", err);
                return View(errorView);
            }
        }




        [Route("getmunis")]
        public ActionResult GetMunis()
        {
            try
            {
                var users = _context.Municipalities.OrderBy(x => x.Name).ToList();
                var usersViewModel = _mapper.Map<List<Municipality>>(users);
                return Ok(usersViewModel);
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occurred", err);
                return View(errorView);
            }
        }


        [Route("kqzresultsbymuni")]
        [AllowAnonymous]
        public async Task<ActionResult> KqzResultsbymuni([FromQuery] int? id)

        {
            try
            {
                var cities = await _unitOfWork.Municipality.GetAllMunicipalityAsync();
                var userId = GetUser();
                var isUserAdmin = User.IsInRole("KryetarIPartise");
                var municipality = _unitOfWork.Municipality.GetMuniOfUser(userId).Result;
                string[] politicalSubjects = { "AAK", "AKR", "LDK", "Nisma", "Partit minoritare jo serbe", "Partit minoritare serbe", "PDK", "VV" };

                if (isUserAdmin)
                {
                    var rezultatetZgjedhore = new Dictionary<string, Dictionary<string, KqzResultsByCity>>();
                    foreach (var city in cities)
                    {
                        var zgjedhjetNacionaleDB = _context.Kqzregisters
                            .Include(x => x.Municipality)
                            .OrderBy(x => x.PoliticialSubject)
                            .Where(x => x.ElectionType == "Zgjedhjet Nacionale" && x.Municipality.Name == city.Name)
                            .Select(x => new KqzLastYear()
                            {
                                PoliticalSubject = x.PoliticialSubject,
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
                        var zgjedhjetLokaleDB = _context.Kqzregisters
                            .Include(x => x.Municipality)
                            .OrderBy(x => x.PoliticialSubject)
                            .Where(x => x.ElectionType == "Zgjedhjet Lokale" && x.Municipality.Name == city.Name)
                            .Select(x => new KqzLastYear()
                            {
                                PoliticalSubject = x.PoliticialSubject,
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




                        var rez = _context.PollRelateds
                            .Where(x => x.Voter.Address.Municipality.Name == city.Name)
                            .OrderBy(x => x.PoliticialSubjectNational)
                            .ToList();

                        var removeDuplicated = new List<PollRelated>();

                        foreach (var user in rez.OrderByDescending(x => x.Date))
                            if (!removeDuplicated.Any(x => x.VoterId == user.VoterId))
                                removeDuplicated.Add(user);

                        var voters = new List<CurrentVoters>();
                        foreach (var user in removeDuplicated.OrderBy(x => x.PoliticialSubjectNational))

                            voters.Add(new CurrentVoters()
                            {
                                Municipality = city.Name,
                                NumberOfVotes = user.FamMembers,
                                PoliticalSubject = user.PoliticialSubjectNational
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




                        var rezLocal = _context.PollRelateds
                            .Where(x => x.Voter.Address.Municipality.Name == city.Name)
                            .OrderBy(x => x.PoliticialSubjectLocal)
                            .ToList();

                        var removeDuplicatedLocal = new List<PollRelated>();

                        foreach (var user in rezLocal.OrderByDescending(x => x.Date))
                            if (!removeDuplicatedLocal.Any(x => x.VoterId == user.VoterId))
                                removeDuplicatedLocal.Add(user);

                        var votersLocal = new List<CurrentVoters>();
                        foreach (var user in removeDuplicatedLocal.OrderBy(x => x.PoliticialSubjectLocal))

                            votersLocal.Add(new CurrentVoters()
                            {
                                Municipality = city.Name,
                                NumberOfVotes = user.FamMembers,
                                PoliticalSubject = user.PoliticialSubjectLocal
                            });

                        var grupingLocal = new Dictionary<string, int>();

                        foreach (var voter in votersLocal)
                            if (!grupingLocal.Any(x => x.Key == voter.PoliticalSubject))
                                grupingLocal.Add(voter.PoliticalSubject, voter.NumberOfVotes);
                            else if (grupingLocal.Any(x => x.Key == voter.PoliticalSubject))
                            {
                                var value = gruping.Where(x => x.Key == voter.PoliticalSubject).FirstOrDefault().Value;
                                grupingLocal[voter.PoliticalSubject] = voter.NumberOfVotes + value;
                            }




                        var nacionale = new KqzResultsByCity()
                        {
                            CityName = city.Name,
                            PoliticSubjects = politicalSubjects,
                            LastYear = zgjedhjetNacionale,
                            ThisYear = gruping
                        };

                        var lokale = new KqzResultsByCity()
                        {
                            CityName = city.Name,
                            PoliticSubjects = politicalSubjects,
                            LastYear = zgjedhjetLokale,
                            ThisYear = grupingLocal
                        };

                        var zgjedhjet = new Dictionary<string, KqzResultsByCity>
                        {
                            { "Nacionale", nacionale },
                            { "Lokale", lokale },
                        };
                        rezultatetZgjedhore.Add(city.Name, zgjedhjet);
                    }
                    return Ok(rezultatetZgjedhore.ToArray());
                }
                else
                {

                    // zgjedhjet nacionale te vitit 2021 
                    var zgjedhjetNacionaleDB = _context.Kqzregisters.OrderBy(x => x.PoliticialSubject)
                    .Where(x => x.ElectionType == "Zgjedhjet Nacionale" && x.MunicipalityId == municipality.Id).Select(x => new KqzLastYear()
                    {
                        PoliticalSubject = x.PoliticialSubject,
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
                    var zgjedhjetLokaleDB = _context.Kqzregisters.OrderBy(x => x.PoliticialSubject)
                    .Where(x => x.ElectionType == "Zgjedhjet Lokale" && x.MunicipalityId == municipality.Id).Select(x => new KqzLastYear()
                    {
                        PoliticalSubject = x.PoliticialSubject,
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


                    var rez = _context.PollRelateds.Where(x => x.Voter.Address.MunicipalityId == municipality.Id)
                                                   .OrderBy(x => x.PoliticialSubjectNational).ToList();
                    var removeDuplicated = new List<PollRelated>();

                    foreach (var user in rez.OrderByDescending(x => x.Date))
                        if (!removeDuplicated.Any(x => x.VoterId == user.VoterId))
                            removeDuplicated.Add(user);

                    var voters = new List<CurrentVoters>();
                    foreach (var user in removeDuplicated.OrderBy(x => x.PoliticialSubjectNational))

                        voters.Add(new CurrentVoters()
                        {
                            Municipality = municipality.Name,
                            NumberOfVotes = user.FamMembers,
                            PoliticalSubject = user.PoliticialSubjectNational
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




                    var rezLocal = _context.PollRelateds.Where(x => x.Voter.Address.MunicipalityId == municipality.Id)
                               .OrderBy(x => x.PoliticialSubjectLocal).ToList();
                    var removeDuplicatedLocal = new List<PollRelated>();

                    foreach (var user in rez.OrderByDescending(x => x.Date))
                        if (!removeDuplicatedLocal.Any(x => x.VoterId == user.VoterId))
                            removeDuplicatedLocal.Add(user);

                    var votersLocal = new List<CurrentVoters>();
                    foreach (var user in removeDuplicatedLocal.OrderBy(x => x.PoliticialSubjectLocal))

                        votersLocal.Add(new CurrentVoters()
                        {
                            Municipality = municipality.Name,
                            NumberOfVotes = user.FamMembers,
                            PoliticalSubject = user.PoliticialSubjectLocal
                        });

                    var grupingLocal = new Dictionary<string, int>();

                    foreach (var voter in votersLocal)
                        if (!grupingLocal.Any(x => x.Key == voter.PoliticalSubject))
                            grupingLocal.Add(voter.PoliticalSubject, voter.NumberOfVotes);
                        else if (grupingLocal.Any(x => x.Key == voter.PoliticalSubject))
                        {
                            var value = grupingLocal.Where(x => x.Key == voter.PoliticalSubject).FirstOrDefault().Value;
                            grupingLocal[voter.PoliticalSubject] = voter.NumberOfVotes + value;
                        }


                    var nacionale = new KqzResultsByCity()
                    {
                        CityName = municipality.Name,
                        PoliticSubjects = politicalSubjects,
                        LastYear = zgjedhjetNacionale,
                        ThisYear = gruping
                    };

                    var lokale = new KqzResultsByCity()
                    {
                        CityName = municipality.Name,
                        PoliticSubjects = politicalSubjects,
                        LastYear = zgjedhjetLokale,
                        ThisYear = grupingLocal
                    };

                    var zgjedhjet = new Dictionary<string, KqzResultsByCity>
                    {
                        { "Nacionale", nacionale },
                        { "Lokale", lokale },
                    };
                    return Ok(zgjedhjet);
                }
            }

            catch (Exception err)
            {
                _logger.LogError("An error has occurred", err);
                return View(errorView);
            }
        }


        [Route("getvillage")]
        public ActionResult GetVillage()
        {
            try
            {
                var users = _context.Villages.OrderBy(x => x.Name).ToList();
                var usersViewModel = _mapper.Map<List<Village>>(users);
                return Ok(usersViewModel);
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occurred", err);
                return View(errorView);
            }
        }

        //fshat
        [Route("getvillagesbymuni")]
        public async Task<ActionResult> GetVillagesByMuni([FromQuery] int muniId)
        {
            try
            {
                var userId = GetUser();
                var municipality = _unitOfWork.Municipality.GetMuniOfUser(userId).Result;
                int municipalityId;
                if (!(muniId <= 0))
                   // municipalityId = municipality.Id;
                municipalityId = muniId;

                var testing = _context.Villages.Where(v => v.MunicipalityId == muniId).ToList();
                var test = _mapper.Map<List<Village>>(testing);
                return Ok(test);
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occurred", err);
                return View(errorView);
            } 
        }


        [HttpPost, Route("addvillage")]
        public ActionResult AddVillage([FromBody] AddVillageVM model)
        {
            try
            {
                var test = _mapper.Map<Village>(model);

                _context.Villages.Add(test);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occurred", err);
                return View(errorView);
            }
        }

        //Lagje
        [Route("getneighborhoodsbymuni")]
        public async Task<ActionResult> GetNeighborhoodByMuni([FromQuery] int muniId)
        {
            try
            {
                var userId =  GetUser();
                var muni = _unitOfWork.Municipality.GetMuniOfUser(userId).Result;
                int municipalityId;
                if (!(muniId <= 0))
                 //   municipalityId = muni.Id;
                municipalityId = muniId;
                var testing = _context.Neighborhoods.Where(v => v.MunicipalityId == muniId).ToList();
                var test = _mapper.Map<List<Neighborhood>>(testing);
                return Ok(test);
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occurred", err);
                return View(errorView);
            }
        }

        [Route("getneighborhood")]
        public ActionResult GetNeighborhood()
        {
            try
            {
                var testing = _context.Neighborhoods.ToList();
                var test = _mapper.Map<List<Neighborhood>>(testing);
                return Ok(test);
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occurred", err);
                return View(errorView);
            }
        }

        [HttpPost]
        [Route("addneighborhood")]
        public ActionResult AddNeighborhood([FromBody] AddNeighborhoodVM model)
        {
            try
            {

                var test = _mapper.Map<Neighborhood>(model);

                _context.Neighborhoods.Add(test);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occurred", err);
                return View(errorView);
            }
        }


        //Lagje per fshat
        [Route("getneighborhoodsbyvillage")]
        public ActionResult GetNeighborhoodByVillage([FromQuery] int villId)
        {
            try
            {
                var testing = _context.Neighborhoods.Where(v => v.VillageId == villId).ToList();
                var test = _mapper.Map<List<Neighborhood>>(testing);
                return Ok(test);
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occurred", err);
                return View(errorView);
            }
        }


        [HttpPost, Route("addneighborhoodbyvillage")]
        public ActionResult AddNeighborhoodByVillage([FromBody] AddNeighborhoodVM model)
        {
            try
            {
                var test = _mapper.Map<Neighborhood>(model);

                _context.Neighborhoods.Add(test);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occurred", err);
                return View(errorView);
            }
        }

        //Blloku
        [Route("getblocksbymuni")]
        public ActionResult GetBlockByMuni([FromQuery] int muniId)
        {
            try
            {
                var testing = _context.Blocks.Where(v => v.MunicipalityId == muniId).ToList();
                var test = _mapper.Map<List<Block>>(testing);
                return Ok(test);
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occurred", err);
                return View(errorView);
            }
        }


        [HttpPost]
        [Route("addblock")]
        public ActionResult AddBlock([FromBody] AddBlockVM model)
        {
            try
            {
                var test = _mapper.Map<Block>(model);

                _context.Blocks.Add(test);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occurred", err);
                return View(errorView);
            }
        }

        //street by village
        [Route("getstreetbyvillage")]
        public ActionResult GetStreetByVillage([FromQuery] int villId)
        {
            try
            {
                var testing = _context.Streets.Where(v => v.VillageId == villId).ToList();
                var test = _mapper.Map<List<Street>>(testing);
                return Ok(test);
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occurred", err);
                return View(errorView);
            }
        }


        [HttpPost]
        [Route("addstreetbyvillage")]
        public ActionResult AddStreetByVillage([FromBody] AddStreetVM model)
        {
            try
            {
                _context.Streets.Add(new Street
                {
                    Name = model.StreetName,
                    VillageId = model.VillageId
                });
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occurred", err);
                return View(errorView);
            }
        }

        //street by neighborhood
        [Route("getstreetbyneighborhood")]
        public ActionResult GetStreetByNeighborhood([FromQuery] int neighId)
        {
            try
            {
                var testing = _context.Streets.Where(n => n.NeighborhoodId == neighId).ToList();
                var test = _mapper.Map<List<Street>>(testing);
                return Ok(test);
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occurred", err);
                return View(errorView);
            }
        }

        [HttpPost]
        [Route("addstreetbyneighborhood")]
        public ActionResult AddStreetByNeighborhood([FromBody] AddStreetVM model)
        {
            try
            {
                _context.Streets.Add(new Street
                {
                    Name = model.StreetName,
                    NeighborhoodId = model.NeighborhoodId
                });
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occurred", err);
                return View(errorView);
            }
        }
       // pollCenter by village
        [Route("getpollcenterbyvillage")]
        public ActionResult GetPollCenterByVillage([FromQuery] int villId)
        {
            try
             {
                var testing = _context.PollCenters.Where(v => v.VillageId == villId).ToList();
                var test = _mapper.Map<List<PollCenter>>(testing);
                return Ok(test);
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occurred", err);
                return View(errorView);
            }
        }


        [HttpPost]
        [Route("addpollcenterbyvillage")]
        public ActionResult AddPollCenterByVillage([FromBody] PollCenterVM model)
        {
            try
            {
                var test = _mapper.Map<PollCenter>(model);

                _context.PollCenters.Add(test);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occurred", err);
                return View(errorView);
            }
        }
        //pollCenter by neighborhood
        [Route("getpollcenterbyneigborhood")]
        public ActionResult GetPollCenterByNeighborhood([FromQuery] int neighId)
        {
            try
            {
                var testing = _context.PollCenters.Where(n => n.NeighborhoodId == neighId).ToList();
                var test = _mapper.Map<List<PollCenter>>(testing);
                return Ok(test);
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occurred", err);
                return View(errorView);
            }
        }

        [HttpPost]
        [Route("addpollcenterbyneighborhood")]
        public ActionResult AddPollCenterByNeighborhood([FromBody] PollCenterVM model)
        {
            try
            {
                var test = _mapper.Map<PollCenter>(model);

                _context.PollCenters.Add(test);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occurred", err);
                return View(errorView);
            }
        }


        private string GetUser()
            => _httpContext.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);


        [Route("kqzvalidation")]
        public async Task<IActionResult> KqzValidation([FromQuery] string id)
        {
            var res = await _context.Kqzregisters.Where(x => x.PollCenterId == id.AsInt()).ToListAsync();
            if (res.Select(x => x.NoOfvotes).Count() <= 0)
            {
                return Ok(new KqzValidationModel()
                {
                    Value = "Nuk ka të dhëna për këtë qendër të votimit!",
                });
            }
            else if (res.Where(x => x.ElectionType == "Zgjedhjet Lokale").Select(x => x.NoOfvotes).Count() <= 0)
            {
                return Ok(new KqzValidationModel()
                {
                    Value = "Nuk ka të dhëna për Zgjedhje Lokale!",
                });
            }
            else if (res.Where(x => x.ElectionType == "Zgjedhjet Nacionale").Select(x => x.NoOfvotes).Count() <= 0)
            {
                return Ok(new KqzValidationModel()
                {
                    Value = "Nuk ka të dhëna për Zgjedhje Nacionale!",
                });
            }
            return Ok(new KqzValidationModel()
            {
                Value = "Të dhënat janë regjistruar për këtë qendër të votimit!",
            });
        }

    }


    public class Name { public string? Text { get; set; } }

#pragma warning restore CS8602
#pragma warning restore CS8604
}