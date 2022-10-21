using Application.Models;
using Application.Repository;
using Application.ViewModels;
using Domain.Data;
using Domain.Data.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Web.WebPages;

namespace Presentation.Controllers;

#pragma warning disable CS8602
#pragma warning disable CS8604

[Route("api/[controller]")]
[ApiController]
public class ServiceController : Controller
{

    private readonly string errorView = "../Error/ErrorInfo";
    private readonly IUnitOfWork _unitOfWork;
    private readonly ApplicationDbContext _context;
    private readonly IHttpContextAccessor _httpContext;
    private readonly ILogger<ServiceController> _logger;

    public ServiceController(IUnitOfWork unit,
                             ApplicationDbContext context,
                             IHttpContextAccessor httpContext,
                             ILogger<ServiceController> logger)
    {
        _unitOfWork = unit;
        _context = context;
        _httpContext = httpContext;
        _logger = logger;
    }


    // Get All Poll Centers
    [Route("getpollcenter")]
    public async Task<ActionResult> GetPollCenter()
    {
        try
        {
            return Ok(await _unitOfWork.PollCenter.GetAllAsync());
        }
        catch (Exception err)
        {
            _logger.LogError(err.Message, err);
            return View(errorView);
        }
    }

    // GetPoll
    [Route("getpollcenterbyvillageid")]
    public async Task<ActionResult> GetPollCenterByVillageId([FromQuery] int id)
    {
        try
        {
            return Ok(await _unitOfWork.PollCenter.GetByVillageIdAsync(id));
        }
        catch (Exception err)
        {
            _logger.LogError("An error has occurred", err);
            return View(errorView);
        }
    }


    [Route("getpollcenterbyneighborhoodid")]
    public async Task<ActionResult> GetPollCenterByNeighborhoodId([FromQuery] int id)
    {
        try
        {
            return Ok(await _unitOfWork.PollCenter.GetByNeighborhoodIdAsync(id));
        }
        catch (Exception err)
        {
            _logger.LogError("An error has occurred", err);
            return View(errorView);
        }
    }


    [Route("getpollcenterbymuniid")]
    public async Task<ActionResult> GetPollCenterByMuniId([FromQuery] int id)
    {
        try
        {
            return Ok(await _unitOfWork.PollCenter.GetByMuniIdAsync(id));
        }
        catch (Exception err)
        {
            _logger.LogError("An error has occurred", err);
            return View(errorView);
        }

    }


    [Route("getpollcenterbyid")]
    public async Task<ActionResult> GetPollCenterById([FromQuery] string id)
    {
        try
        {
            return Ok(await _unitOfWork.PollCenter.GetByCenterNumberAsync(id));
        }
        catch (Exception err)
        {
            _logger.LogError("An error has occurred", err);
            return View(errorView);
        }
    }


    [HttpPost, Route("addpollcenter")]
    public async Task<ActionResult> AddPollCenter([FromBody] PollCenterVM model)
    {
        try
        {
            await _unitOfWork.PollCenter.AddAsync(model);
            return Ok();
        }
        catch (Exception err)
        {
            _logger.LogError("An error has occurred", err);
            return View(errorView);
        }
    }


    [Route("getkqzresult")]
    public async Task<ActionResult> GetKqzResult([FromQuery] int muniId)
    {
        try
        {
            return Ok(await _unitOfWork.KqzRegister.GetByMunicipalityAsync(muniId));
        }
        catch (Exception err)
        {
            _logger.LogError("An error has occurred", err);
            return View(errorView);
        }
    }


    [Route("getkqzresultbyvillage")]
    public async Task<ActionResult> GetKqzResultByVillage([FromQuery] int muniId)
    {
        try
        {
            return Ok(await _unitOfWork.KqzRegister.GetByVillageAsync(muniId));
        }
        catch (Exception err)
        {
            _logger.LogError("An error has occurred", err);
            return View(errorView);
        }
    }

    [Route("getkqzresultbyneighborhood")]
    public async Task<ActionResult> GetKqzResultByNeighborhood([FromQuery] int muniId)
    {
        try
        {
            return Ok(await _unitOfWork.KqzRegister.GetByNeigborhoodAsync(muniId));
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
            return Ok(_unitOfWork.PoliticalSubject.GetByNameAsync(name));
        }
        catch (Exception err)
        {
            _logger.LogError("An error has occurred", err);
            return View(errorView);
        }
    }


    [HttpPost, Route("addkqzresult")]
    public async Task<ActionResult> AddKqzResult([FromBody] KqzRegisterVM model)
    {
        try
        {
            await _unitOfWork.KqzRegister.AddAsync(model);
            return Ok();
        }
        catch (Exception err)
        {
            _logger.LogError("An error has occurred", err);
            return View(errorView);
        }
    }


    [Route("getmunis")]
    public async Task<ActionResult> GetMunis()
    {
        try
        {
            return Ok(await _unitOfWork.Municipality.GetAllMunicipalityAsync());
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
    public async Task<ActionResult> GetVillage()
    {
        try
        {
            return Ok(await _unitOfWork.Village.GetAllAsync());
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
            if (!(muniId <= 0)) municipalityId = municipality.Id;
            municipalityId = muniId;

            return Ok(await _unitOfWork.Village.GetByMunicipalityAsync(municipalityId));
        }
        catch (Exception err)
        {
            _logger.LogError("An error has occurred", err);
            return View(errorView);
        }
    }


    [HttpPost, Route("addvillage")]
    public async Task<ActionResult> AddVillage([FromBody] AddVillageVM model)
    {
        try
        {
            await _unitOfWork.Village.AddAsync(model);
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
            return Ok(await _unitOfWork.Neighborhood.GetByMunicipalityAsync(municipalityId));
        }
        catch (Exception err)
        {
            _logger.LogError("An error has occurred", err);
            return View(errorView);
        }
    }

    [Route("getneighborhood")]
    public async Task<ActionResult> GetNeighborhood()
    {
        try
        {
            return Ok(await _unitOfWork.Neighborhood.GetAllAsync());
        }
        catch (Exception err)
        {
            _logger.LogError("An error has occurred", err);
            return View(errorView);
        }
    }

    [HttpPost]
    [Route("addneighborhood")]
    public async Task<ActionResult> AddNeighborhood([FromBody] AddNeighborhoodVM model)
    {
        try
        {
            await _unitOfWork.Neighborhood.AddAsync(model);
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
    public async Task<ActionResult> GetNeighborhoodByVillage([FromQuery] int villId)
    {
        try
        {
            return Ok(await _unitOfWork.Neighborhood.GetByVillageAsync(villId));
        }
        catch (Exception err)
        {
            _logger.LogError("An error has occurred", err);
            return View(errorView);
        }
    }


    [HttpPost, Route("addneighborhoodbyvillage")]
    public async Task<ActionResult> AddNeighborhoodByVillage([FromBody] AddNeighborhoodVM model)
    {
        try
        {
            await _unitOfWork.Neighborhood.AddByVillageAsync(model);
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
            return Ok(_unitOfWork.Block.GetByMunicipalityAsync(muniId));
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
    public async Task<ActionResult> GetStreetByVillage([FromQuery] int villId)
    {
        try
        {
            return Ok(await _unitOfWork.Street.GetByVillageAsync(villId));
        }
        catch (Exception err)
        {
            _logger.LogError("An error has occurred", err);
            return View(errorView);
        }
    }


    [HttpPost]
    [Route("addstreetbyvillage")]
    public async Task<ActionResult> AddStreetByVillage([FromBody] AddStreetVM model)
    {
        try
        {
            await _unitOfWork.Street.AddByVillageAsync(model);
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
    public async Task<ActionResult> GetStreetByNeighborhood([FromQuery] int neighId)
    {
        try
        {
            return Ok(await _unitOfWork.Street.GetByNeigborhoodAsync(neighId));
        }
        catch (Exception err)
        {
            _logger.LogError("An error has occurred", err);
            return View(errorView);
        }
    }

    [HttpPost]
    [Route("addstreetbyneighborhood")]
    public async Task<ActionResult> AddStreetByNeighborhood([FromBody] AddStreetVM model)
    {
        try
        {
            await _unitOfWork.Street.AddByNeiborgoodAsync(model);
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
    public async Task<ActionResult> GetPollCenterByVillage([FromQuery] int villId)
    {
        try
        {
            return Ok(await _unitOfWork.PollCenter.GetByVillageIdAsync(villId));
        }
        catch (Exception err)
        {
            _logger.LogError("An error has occurred", err);
            return View(errorView);
        }
    }


    [HttpPost]
    [Route("addpollcenterbyvillage")]
    public async Task<ActionResult> AddPollCenterByVillage([FromBody] PollCenterVM model)
    {
        try
        {
            await _unitOfWork.PollCenter.AddByVillageAsync(model);
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
    public async Task<ActionResult> GetPollCenterByNeighborhood([FromQuery] int neighId)
    {
        try
        {
            return Ok(await _unitOfWork.PollCenter.GetByNeighborhoodIdAsync(neighId));
        }
        catch (Exception err)
        {
            _logger.LogError("An error has occurred", err);
            return View(errorView);
        }
    }

    [HttpPost]
    [Route("addpollcenterbyneighborhood")]
    public async Task<ActionResult> AddPollCenterByNeighborhood([FromBody] PollCenterVM model)
    {
        try
        {
            await _unitOfWork.PollCenter.AddByNeiborhoodAsync(model);
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
    public async Task<IActionResult> AddPoliticalSubject([FromBody] NameModel model)
    {
        try
        {
            await _unitOfWork.PoliticalSubject.AddAsync(model);
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
        var res = await _unitOfWork.KqzRegister.KqzValidationAsync(id.AsInt());
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

#pragma warning restore CS8602
#pragma warning restore CS8604

