using dm.lib.core.nuget;
using dm.lib.infrastructure.nuget;
using Leo.Guided.Buy.API.Controllers;
using Leo.Guided.Buy.Core.Entity;
using Leo.Guided.Buy.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Leo.Guided.Buy.Api.Controllers.v1
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class QuicklinkController : BaseController
    {
        private readonly IQuicklinkService _quicklinkService;

        public QuicklinkController(IGepService gepService,
                                   IQuicklinkService quicklinkService) : base(gepService)
        {
            _quicklinkService = quicklinkService;
        }

        [HttpGet("GetMasterData", Name = "GetQuicklinkMasterData")]
        public async Task<GepReturn<List<Quicklink>>> GetQuicklinkMasterData()
        {
            try
            {
                return new GepReturn<List<Quicklink>>(await _quicklinkService.GetQuicklinkMasterData());
            }
            catch (Exception ex)
            {
                LogError(GetClassName(), GetActionMethodName(), ex.Message, ex);
                return new GepReturn<List<Quicklink>>(new GepException(ex.Message, SeverityLevel.Critical, ex));
            }
        }

        [HttpPost("InsertMasterData", Name = "InsertQuicklinkMasterData")]
        public async Task<GepReturn<Quicklink>> InsertQuicklinkMasterData(Quicklink quicklink)
        {
            try
            {
                return new GepReturn<Quicklink>(await _quicklinkService.InsertQuicklinkMasterData(quicklink));
            }
            catch (Exception ex)
            {
                LogError(GetClassName(), GetActionMethodName(), ex.Message, ex);
                return new GepReturn<Quicklink>(new GepException(ex.Message, SeverityLevel.Critical, ex));
            }
        }
    }
}
