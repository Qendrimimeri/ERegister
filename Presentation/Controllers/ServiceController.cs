using Application.Repository;
using Application.ViewModels;
using Domain.Data;
using Domain.Data.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Serilog;

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
        //[Route("getpollcenter")]
        //public ActionResult GetPollCenter()
        //{
        //    return Ok(_context.PollCenters.ToList().Select(x => new
        //    {
        //        Id = x.Id,
        //        CenterNumber = x.CenterNumber
        //    }));
        //}

        //[Route("getpollcenterbyid")]
        //public ActionResult GetPollCenterById([FromQuery] string id)
        
        //{
        //    var qendra = _context.PollCenters.Where(v => v.CenterNumber == id)
        //        .Select(x =>
        //        new
        //        {
        //            Id = x.Id,
        //            CenterNumber = x.CenterNumber,
        //            CenterName = x.CenterName,
        //            MuniCipalityId = x.MunicipalitydId
        //        });

        //    return Ok(qendra);
        //}

        //[HttpPost]
        //[Route("addpollcenter")]
        //public ActionResult AddPollCenter([FromBody] PollCenterVM model)
        //{
        //    _context.PollCenters.Add(new PollCenter
        //    {
        //        Id = model.Id,
        //        CenterNumber = model.CenterNumber,
        //        CenterName = model.CenterName,
        //        MunicipalitydId = model.MunicipalitydId

        //    });

        //    _context.SaveChanges();

        //    return Ok();
        //}

        [Route("getkqzresult")]
        public ActionResult GetKqzResult()
        {
            try
            {
                return Ok(_context.Kqzregisters.ToList());
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[GET]GetKqzResult terminated unexpectedly");

            }
            finally
            {
                Log.CloseAndFlush();
            }
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
            try
            {
                return Ok(_context.PollRelateds.ToList());
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[GET]GetGeneralDemand terminated unexpectedly");

            }
            finally
            {
                Log.CloseAndFlush();
            }
            return Ok(_context.PollRelateds.ToList());

        }
        //add general demand 
        [HttpPost]
        [Route("addgeneraldemand")]
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
            catch(Exception ex){
                Log.Fatal(ex, "[POST]AddGeneralDemand terminated unexpectedly");

            }
            finally { Log.CloseAndFlush(); }
            return Ok();

        }
        //get help  // specific demand
        [Route("gethelp")]

        public ActionResult GetNeedHelp()
        {
            try
            {
                return Ok(_context.PollRelateds.ToList());
            }
            catch(Exception ex)
            {
                Log.Fatal(ex, "[GET]GetNeedHelp terminated unexpectedly");

            }
            finally{ Log.CloseAndFlush(); }
            return Ok(_context.PollRelateds.ToList());

        }
        //add help
        [HttpPost]
        [Route("GetNeedHelp")]   
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
            catch (Exception ex)
            {
                Log.Fatal(ex, "[POST]AddHelp terminated unexpectedly");


            }
            finally
            {
                Log.CloseAndFlush();
            }
            return Ok();

        }

        [HttpPost]
        [Route("addkqzresult")]
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
            catch(Exception ex)
            {
                Log.Fatal(ex, "[POST]AddKqzResult terminated unexpectedly");

            }
            finally { Log.CloseAndFlush(); }
            return Ok();

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
            catch (Exception ex)
            {
                Log.Fatal(ex, "[GET]GetMunis terminated unexpectedly");

            }
            finally
            {
                Log.CloseAndFlush();
            }
            return Ok();
        }


        // Get Kqz Rezults
        [Route("kqzresults")]
        public ActionResult KqzResults()
        {
            try
            {
                var rez = _context.Kqzregisters.Where(x => x.MunicipalityId == 1).Select(x => x.NoOfvotes).ToList();
                return Ok(rez);
            }
            catch(Exception ex)
            {
                Log.Fatal(ex, "[GET]KqzResults terminated unexpectedly");

            }
            finally
            {
                Log.CloseAndFlush();
            }
            return Ok();
        }


        [Route("kqzresultsbymuni")]
        public ActionResult KqzResultsbymuni()
        {
            try
            {
                var results = _context.Kqzregisters.Select(x => new KqzLastYear()
                {
                    PoliticalSubject = x.PoliticialSubject.Name,
                    NumberOfVotes = (int)x.NoOfvotes,
                }).ToList();

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

                var data = new KqzResultsByCity()
                {
                    LastYear = results,
                    ThisYear = gruping
                };

                return Ok(data);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[GET]KqzResultsbymuni terminated unexpectedly");

            }
            finally
            {
                Log.CloseAndFlush();
            }
            return Ok();
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
            catch(Exception ex)
            {
                Log.Fatal(ex, "[GET]GetVillage terminated unexpectedly");

            }
            finally { Log.CloseAndFlush(); }
            return Ok();
        }

        //fshat
        [Route("getvillagesbymuni")]
        public ActionResult GetVillagesByMuni([FromQuery] int muniId)
        {
            try
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
            catch(Exception ex)
            {
                Log.Fatal(ex, "[GET]GetVillagesByMuni terminated unexpectedly");

            }
            finally
            {
                Log.CloseAndFlush();
            }
            return Ok();
        }
        [HttpPost]
        [Route("addvillage")]
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
            catch (Exception ex)
            {
                Log.Fatal(ex, "[POST]AddVillage terminated unexpectedly");

            }
            finally
            {
                Log.CloseAndFlush();
            }
            return Ok();

        }

        //Lagje
        [Route("getneighborhoodsbymuni")]
        public ActionResult GetNeighborhoodByMuni([FromQuery] int muniId)
        {
            try
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
            catch(Exception ex)
            {
                Log.Fatal(ex, "[POST]GetNeighborhoodByMuni terminated unexpectedly");

            }
            finally
            {
                Log.CloseAndFlush();
            }
            return Ok();
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
            catch (Exception ex)
            {
                Log.Fatal(ex, "[POST]AddNeighborhood terminated unexpectedly");

            }
            finally
            {
                Log.CloseAndFlush();
            }
            return Ok();
        }
        //Lagje per fshat
        [Route("getneighborhoodsbyvillage")]
        public ActionResult GetNeighborhoodByVillage([FromQuery] int villId)
        {
            try
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
            catch(Exception ex)
            {
                Log.Fatal(ex, "[GET]GetNeighborhoodByVillage terminated unexpectedly");

            }
            finally { Log.CloseAndFlush(); }
            return Ok();
        }
        [HttpPost]
        [Route("addneighborhoodbyvillage")]
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
            catch (Exception ex)
            {
                Log.Fatal(ex, "[POST]AddNeighborhoodByVillage terminated unexpectedly");

            }
            finally
            {
                Log.CloseAndFlush();
            }
            return Ok();

        }

        //Blloku
        [Route("getblocksbymuni")]
        public ActionResult GetBlockByMuni([FromQuery] int muniId)
        {
            try
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
            catch(Exception ex)
            {
                Log.Error(ex, "[GET]GetBlockByMuni terminated unexpectedly");

            }
            finally
            {
                Log.CloseAndFlush();
            }
            return Ok();
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
            catch(Exception ex)
            {
                Log.Error(ex, "[POST]AddBlock terminated unexpectedly");

            }
            finally { Log.CloseAndFlush(); }
            return Ok();
        }

        //street by village
        [Route("getstreetbyvillage")]
        public ActionResult GetStreetByVillage([FromQuery] int villId)
        {
            try
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
            catch (Exception ex)
            {
                Log.Error(ex, "[GET]GetStreetByVillage terminated unexpectedly");

            }
            finally { Log.CloseAndFlush(); }
            return Ok();
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
            catch(Exception ex)
            {
                Log.Error(ex, "[POST]AddStreetByVillage terminated unexpectedly");

            }
            finally
            {
                Log.CloseAndFlush();
            }
            return Ok();
        }

        //street by neighborhood
        [Route("getstreetbyneighborhood")]
        public ActionResult GetStreetByNeighborhood([FromQuery] int neighId)
        {
            try
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
            catch(Exception ex)
            {
                Log.Error(ex, "[Get]GetStreetByNeighborhood terminated unexpectedly");

            }
            finally
            {
                Log.CloseAndFlush();
            }
            return Ok();

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
            catch (Exception ex)
            {
                Log.Error(ex, "[POST]AddStreetByNeighborhood terminated unexpectedly");

            }
            finally { Log.CloseAndFlush(); }
            return Ok();
        }
        //pollCenter by village
        [Route("getpollcenterbyvillage")]
        public ActionResult GetPollCenterByVillage([FromQuery] int villId)
        {
            try
            {
                var streets = _context.PollCenters.Where(v => v.VillageId == villId)
                    .Select(x =>
                    new
                    {
                        Id = x.Id,
                        Name = x.CenterNumber
                    });
                return Ok(streets);
            }
            catch(Exception ex)
            {
                Log.Error(ex, "[GET]GetPollCenterByVillage terminated unexpectedly");

            }
            finally { Log.CloseAndFlush(); }
            return Ok();
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
            catch (Exception ex)
            {
                Log.Error(ex, "[POST]AddPollCenterByVillage terminated unexpectedly");

            }
            finally
            {
                Log.CloseAndFlush();
            }
            return Ok();
        }
        //pollCenter by neighborhood
        [Route("getpollcenterbyneigborhood")]
        public ActionResult GetPollCenterByNeighborhood([FromQuery] int neighId)
        {
            try
            {
                var pollcenters = _context.PollCenters.Where(n => n.NeighborhoodId == neighId)
                    .Select(x =>
                    new
                    {
                        Id = x.Id,
                        Name = x.CenterName
                    });
                return Ok(pollcenters);
            }
            catch(Exception ex)
            {
                Log.Error(ex, "[GET]GetPollCenterByNeighborhood terminated unexpectedly");

            }
            finally
            {
                Log.CloseAndFlush();
            }
            return Ok();
        }
        [HttpPost]
        [Route("addpollcenterbyneighborhood")]
        public ActionResult AddPollCenterByNeighborhood([FromBody] PollCenterVM model)
        {
            try
            {
                _context.PollCenters.Add(new PollCenter
                {
                    CenterName = model.CenterName,
                    NeighborhoodId = model.NeighborhoodId
                });
                _context.SaveChanges();

                return Ok();
            }
            catch(Exception ex)
            {
                Log.Error(ex, "[POST]AddPollCenterByNeighborhood terminated unexpectedly");

            }
            finally { Log.CloseAndFlush(); }
            return Ok();
        }


        [HttpPost]
        [Route("addblock")]
        public ActionResult AddRole([FromBody] AddBlockVM model)
        {
            try
            {
                _context.Blocks.Add(new Block
                {
                    Name = model.BlockName
                });
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "[POST]AddRole terminated unexpectedly");

            }
            finally { Log.CloseAndFlush(); }
            return Ok();
        }
       
    }
}
