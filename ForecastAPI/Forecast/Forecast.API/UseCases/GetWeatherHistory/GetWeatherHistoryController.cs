using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Forecast.API.Mapper;
using Forecast.Application.UseCases.GetHistory;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Forecast.Core.Exceptions;

namespace Forecast.API.UseCases.GetHistory
{
    [Route("api/[controller]")]
    [EnableCors("_allowedOrigins")]
    [ApiController]
    public class GetHistoryController : ControllerBase
    {
        private readonly IDataMapper _mapper;
        private readonly IMediator _mediator;
        private readonly ILogger<GetHistoryController> _logger;

        public GetHistoryController
            (IDataMapper mapper,
            IMediator mediator,
            ILogger<GetHistoryController> logger)
        {
            _mapper = mapper;
            _mediator = mediator;
            _logger = logger;
        }
        /// <summary>
        /// Get History details based on user key (auto generated)
        /// </summary>
        /// <param name="userKey"></param>
        /// <returns>Model object</returns>
        /// <exception cref="ApiException"></exception>
        [HttpGet]
        public async Task<List<GetHistoryResponse>> GetHistoryByUser(string userKey)
        {
            try { 
            _logger.LogInformation("Get Weather Forecast by City");
            var output = await _mediator.Send(new GetHistoryInput() { UserKey = userKey });
            var response = _mapper.MapGetHistoryResponse(output);
            return response;
        }
            catch (Exception ex)
            { throw new ApiException(ex.Message);
    }
}
    }
}
