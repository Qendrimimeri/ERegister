using Application.Models;
using Application.Repository;
using Application.ViewModels;
using AutoMapper;
using Domain.Data;
using Domain.Data.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
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
        //public ActionResult GetPollCenter()
        //{
        //    try
        //    {
        //        return Ok(_context.PollCenters.ToList()
        //            .Select(x => new PollCenterVM
        //        {
        //            Id = x.Id,
        //            CenterNumber = x.CenterNumber
        //        }));
        //    }
        //    catch (Exception err)
        //    {
        //        _logger.LogError("An error has occurred", err);
        //        return View(errorView);
        //    }
        //}

        // GetPoll
        [Route("getpollcenterbyvillageid")]
        public ActionResult GetPollCenterByVillageId([FromQuery] int id)
        {
            try
            {
                var PollCeneterByVillage = _context.PollCenters.Where(v => v.VillageId == id).FirstOrDefault();
                var PollCeneterByVillageMap = _mapper.Map<PollCenterVM>(PollCeneterByVillage);
                return Ok(PollCeneterByVillageMap);
            }

            //        .Select(x => new
            //    {
            //        Id = x.Id,
            //        CenterNumber = x.CenterNumber,
            //        CenterName = x.CenterName,
            //        MuniCipalityId = x.MunicipalitydId
            //    }));
            //}
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
                var testing = _context.PollCenters.Where(v => v.NeighborhoodId == id).FirstOrDefault();
                var test = _mapper.Map<PollCenterVM>(testing);
                return Ok(test);

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
                //return Ok(_context.PollCenters.Where(v => v.MunicipalitydId == id).Select(x => new
                //{
                //    Id = x.Id,
                //    CenterNumber = x.CenterNumber,
                //    CenterName = x.CenterName,
                //    MuniCipalityId = x.MunicipalitydId
                //}));

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
                return Ok(_context.PollCenters.Where(v => v.CenterNumber == id).Select(x => new
                {
                    Id = x.Id,
                    CenterNumber = x.CenterNumber,
                    CenterName = x.CenterName,
                    MuniCipalityId = x.MunicipalitydId
                }));
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
                _context.PollCenters.Add(new PollCenter
                {
                    Id = model.Id,
                    CenterNumber = model.CenterNumber,
                    CenterName = model.CenterName,
                    MunicipalitydId = model.MunicipalitydId,
                    NeighborhoodId = model.NeighborhoodId,
                    VillageId = model.VillageId

                });
                _context.SaveChanges();
                return Ok(PollCenterByIdMap);
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occurred", err);
                return View(errorView);
            }
        }


        [Route("getkqzresult")]
        public ActionResult GetKqzResult([FromQuery] int muniId)
        {
            try
            {

                var testing = _context.Kqzregisters.Where(v => v.MunicipalityId == muniId).FirstOrDefault();
                var test = _mapper.Map<KqzRegisterVM>(testing);
                return Ok(test);
                //return Ok(_context.Kqzregisters.Where(v => v.MunicipalityId == muniId).Select(x => new 
                //{
                //    Id = x.Id,
                //    NoOfVotes = x.NoOfvotes,
                //    PoliticalSubject = x.PoliticialSubjectId,
                //    Name = x.PoliticialSubject.Name


                //}));
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occurred", err);
                return View(errorView);
            }
        }


        [Route("getkqzresultbyvillage")]
        public ActionResult GetKqzResultByVillage([FromQuery] int muniId)
        {
            try
            {

                var testing = _context.Kqzregisters.Where(v => v.VillageId == muniId && v.ElectionType == "Zgjedhjet Nacionale").FirstOrDefault();
                var test = _mapper.Map<KqzRegisterVM>(testing);
                return Ok(test);
             //   return Ok(_context.Kqzregisters.Where(v => v.VillageId == muniId && v.ElectionType == "Zgjedhjet Nacionale")
             //  .Select(x =>
             //new
             //{
             //    Id = x.Id,
             //    NoOfVotes = x.NoOfvotes,
             //    PoliticalSubject = x.PoliticialSubjectId,
             //    Name = x.PoliticialSubject.Name


             //}));
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occurred", err);
                return View(errorView);
            }
        }

        [Route("getkqzresultbyneighborhood")]
        public ActionResult GetKqzResultByNeighborhood([FromQuery] int muniId)
        {
            try
            {
                return Ok(_context.Kqzregisters.Where(v => v.NeighborhoodId == muniId).Select(x => new
                {
                    Id = x.Id,
                    NoOfVotes = x.NoOfvotes,
                    PoliticalSubject = x.PoliticialSubjectId,
                    Name = x.PoliticialSubject.Name
                }));
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occurred", err);
                return View(errorView);
            }
        }


        [Route("getpoliticalsubjectbyname")]
        public ActionResult GetPoliticalSubjectByName([FromQuery] string name)
        {
            try
            {
                return Ok(_context.PoliticalSubjects.Where(v => v.Name == name));
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occurred", err);
                return View(errorView);
            }
        }


        [Route("getgeneraldemand")]
        public ActionResult GetGeneralDemand()
        {
            try
            {
                return Ok(_context.PollRelateds.ToList());
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occurred", err);
                return View(errorView);
            }
        }


        [HttpPost, Route("addgeneraldemand")]
        public ActionResult AddGeneralDemand([FromBody] GeneralDemandVM model)
        {
            try
            {
                _context.PollRelateds.Add(new PollRelated
                {
                    Id = model.Id,
                    SpecificReason = model.SpecificReason
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


        //get help  // specific demand
        [Route("gethelp")]
        public ActionResult GetNeedHelp()
        {
            try
            {
                return Ok(_context.PollRelateds.ToList());
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occurred", err);
                return View(errorView);
            }
        }

        //add help
        [HttpPost, Route("GetNeedHelp")]
        public ActionResult AddHelp([FromBody] GeneralDemandVM model)
        {
            try
            {
                _context.PollRelateds.Add(new PollRelated
                {
                    Id = model.Id,
                    SpecificDemand = model.SpecificDemand
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


        [HttpPost, Route("addkqzresult")]
        public ActionResult AddKqzResult([FromBody] KqzRegisterVM model)
        {
            try
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
                return Ok(_context.Municipalities.ToList().Select(x => new
                {
                    Id = x.Id,
                    Name = x.Name
                }));
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
                var cities = await _unitOfWork.Municipality.GetAllCities();
                var userId = await GetUser();
                var isUserAdmin = User.IsInRole("KryetarIPartise");
                var municipality = _unitOfWork.Municipality.GetMuniOfUser(userId).Result;

                if (isUserAdmin)
                {
                    var rezultatetZgjedhore = new Dictionary<string, Dictionary<string, KqzResultsByCity>>();
                    foreach (var city in cities)
                    {
                        var zgjedhjetNacionaleDB = _context.Kqzregisters
                            .Include(x => x.Municipality)
                            .OrderBy(x => x.PoliticialSubjectId)
                            .Where(x => x.ElectionType == "Zgjedhjet Nacionale" && x.Municipality.Name == city.Name)
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
                        var zgjedhjetLokaleDB = _context.Kqzregisters
                            .Include(x => x.Municipality)
                            .OrderBy(x => x.PoliticialSubjectId)
                            .Where(x => x.ElectionType == "Zgjedhjet Lokale" && x.Municipality.Name == city.Name)
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


                        var rez = _context.PollRelateds
                            .Where(x => x.User.Address.Municipality.Name == city.Name)
                            .OrderBy(x => x.PoliticialSubjectId)
                            .ToList();

                        var removeDuplicated = new List<PollRelated>();

                        foreach (var user in rez.OrderByDescending(x => x.Date))
                            if (!removeDuplicated.Any(x => x.UserId == user.UserId))
                                removeDuplicated.Add(user);

                        var voters = new List<CurrentVoters>();
                        foreach (var user in removeDuplicated.OrderBy(x => x.PoliticialSubjectId))

                            voters.Add(new CurrentVoters()
                            {
                                Municipality = city.Name,
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

                        var politicSubjects = await _context.PoliticalSubjects.Select(x => x.Name).ToListAsync();

                        var nacionale = new KqzResultsByCity()
                        {
                            CityName = city.Name,
                            PoliticSubjects = politicSubjects,
                            LastYear = zgjedhjetNacionale,
                            ThisYear = gruping
                        };

                        var lokale = new KqzResultsByCity()
                        {
                            CityName = city.Name,
                            PoliticSubjects = politicSubjects,
                            LastYear = zgjedhjetLokale,
                            ThisYear = gruping
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
                    var zgjedhjetNacionaleDB = _context.Kqzregisters.OrderBy(x => x.PoliticialSubjectId)
                    .Where(x => x.ElectionType == "Zgjedhjet Nacionale" && x.MunicipalityId == municipality.Id).Select(x => new KqzLastYear()
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
                    var zgjedhjetLokaleDB = _context.Kqzregisters.OrderBy(x => x.PoliticialSubjectId)
                    .Where(x => x.ElectionType == "Zgjedhjet Lokale" && x.MunicipalityId == municipality.Id).Select(x => new KqzLastYear()
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


                    var rez = _context.PollRelateds.Where(x => x.User.Address.MunicipalityId == municipality.Id).OrderBy(x => x.PoliticialSubjectId).ToList();
                    var removeDuplicated = new List<PollRelated>();

                    foreach (var user in rez.OrderByDescending(x => x.Date))
                        if (!removeDuplicated.Any(x => x.UserId == user.UserId))
                            removeDuplicated.Add(user);

                    var voters = new List<CurrentVoters>();
                    foreach (var user in removeDuplicated.OrderBy(x => x.PoliticialSubjectId))

                        voters.Add(new CurrentVoters()
                        {
                            Municipality = municipality.Name,
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

                    var politicSubjects = await _context.PoliticalSubjects.Select(x => x.Name).ToListAsync();

                    var nacionale = new KqzResultsByCity()
                    {
                        CityName = municipality.Name,
                        PoliticSubjects = politicSubjects,
                        LastYear = zgjedhjetNacionale,
                        ThisYear = gruping
                    };

                    var lokale = new KqzResultsByCity()
                    {
                        CityName = municipality.Name,
                        PoliticSubjects = politicSubjects,
                        LastYear = zgjedhjetLokale,
                        ThisYear = gruping
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
                return Ok(_context.Villages.ToList().Select(x => new
                {
                    Id = x.Id,
                    Name = x.Name
                }));
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
                var userId = await GetUser();
                var municipality = _unitOfWork.Municipality.GetMuniOfUser(userId).Result;
                int municipalityId;
                if (!(muniId <= 0))
                    municipalityId = municipality.Id;
                municipalityId = muniId;

                var res = await _context.Villages.Where(v => v.MunicipalityId == municipalityId).Select(x => new
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToListAsync();
                return Ok(res);
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
                _context.Villages.Add(new Village
                {
                    Name = model.VillageName,
                    MunicipalityId = model.MunicipalityId
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

        //Lagje
        [Route("getneighborhoodsbymuni")]
        public async Task<ActionResult> GetNeighborhoodByMuni([FromQuery] int muniId)
        {
            try
            {
                var userId = await GetUser();
                var muni = _unitOfWork.Municipality.GetMuniOfUser(userId).Result;
                int municipalityId;
                if (!(muniId <= 0))
                    municipalityId = muni.Id;
                municipalityId = muniId;
                var res = _context.Neighborhoods.Where(v => v.MunicipalityId == municipalityId)
                    .Select(x =>
                    new
                    {
                        Id = x.Id,
                        Name = x.Name
                    });
                return Ok(res);
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
                return Ok(_context.Neighborhoods.ToList().Select(x => new
                {
                    Id = x.Id,
                    Name = x.Name
                }));
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
                _context.Neighborhoods.Add(new Neighborhood
                {
                    Name = model.NeighborhoodName,
                    MunicipalityId = model.MunicipalityId
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


        //Lagje per fshat
        [Route("getneighborhoodsbyvillage")]
        public ActionResult GetNeighborhoodByVillage([FromQuery] int villId)
        {
            try
            {
                return Ok(_context.Neighborhoods.Where(v => v.VillageId == villId)
                .Select(x =>
                new
                {
                    Id = x.Id,
                    Name = x.Name
                }));

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
                _context.Neighborhoods.Add(new Neighborhood
                {
                    Name = model.NeighborhoodName,
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

        //Blloku
        [Route("getblocksbymuni")]
        public ActionResult GetBlockByMuni([FromQuery] int muniId)
        {
            try
            {
                return Ok(_context.Blocks.Where(v => v.MunicipalityId == muniId).Select(x => new
                {
                    Id = x.Id,
                    Name = x.Name
                }));
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
                _context.Blocks.Add(new Block
                {
                    Name = model.BlockName,
                    MunicipalityId = model.MunicipalityId
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

        //street by village
        [Route("getstreetbyvillage")]
        public ActionResult GetStreetByVillage([FromQuery] int villId)
        {
            try
            {
                return Ok(_context.Streets.Where(v => v.VillageId == villId)
                                .Select(x =>
                                new
                                {
                                    Id = x.Id,
                                    Name = x.Name
                                }));
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
                return Ok(_context.Streets.Where(n => n.NeighborhoodId == neighId).Select(x => new
                {
                    Id = x.Id,
                    Name = x.Name
                }));

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
        //pollCenter by village
        [Route("getpollcenterbyvillage")]
        public ActionResult GetPollCenterByVillage([FromQuery] int villId)
        {
            try
            {
                return Ok(_context.PollCenters.Where(v => v.VillageId == villId)
                                .Select(x =>
                                new
                                {
                                    Id = x.Id,
                                    Name = x.CenterNumber
                                }));
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
                _context.PollCenters.Add(new PollCenter
                {
                    CenterNumber = model.CenterNumber,
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
        //pollCenter by neighborhood
        [Route("getpollcenterbyneigborhood")]
        public ActionResult GetPollCenterByNeighborhood([FromQuery] int neighId)
        {
            try
            {
                return Ok(_context.PollCenters.Where(n => n.NeighborhoodId == neighId)
                               .Select(x =>
                               new
                               {
                                   Id = x.Id,
                                   Name = x.CenterNumber
                               }));

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
                _context.PollCenters.Add(new PollCenter
                {
                    CenterNumber = model.CenterNumber,
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

        [HttpPost]
        [Route("addpoliticalsubject")]
        public async Task<IActionResult> AddPoliticalSubject([FromBody] Name model)
        {
            try
            {
                var res = _context.PoliticalSubjects.Add(new PoliticalSubject
                {
                    Name = model.Text
                });
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occurred", err);
                return View(errorView);
            }
        }

        private async Task<string> GetUser()
            => _httpContext.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);


        [Route("kqzvalidation")]
        public async Task<IActionResult> KqzValidation([FromQuery] string id)
        {

            var res = await _context.Kqzregisters.Where(x => x.PollCenterId == id.AsInt()).Select(x => x.NoOfvotes).ToListAsync();
            if (res.Count <= 0)
            {
                return Ok(new KqzValidationModel()
                {
                    Value = "Nuk ka të dhëna për këtë qendër të votimit",
                });
            }
            return Ok(new KqzValidationModel()
            {
                Value = "Të dhënat janë të regjistruar për këtë qendër të votimit",
            });
        }


    }


    public class Name { public string? Text { get; set; } }

#pragma warning restore CS8602
#pragma warning restore CS8604
}

