using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Forecast.API.Mapper;
using Forecast.Application.UseCases.GetForecast;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Forecast.Core.Exceptions;
using System;

namespace Forecast.API.UseCases.GetForecast
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("_allowedOrigins")]

    public class GetForecastController : ControllerBase
    {
        private readonly IDataMapper _mapper;
        private readonly IMediator _mediator;
        private readonly ILogger<GetForecastController> _logger;

        public GetForecastController
            (IDataMapper mapper,
            IMediator mediator,
            ILogger<GetForecastController> logger)
        {
            _mapper = mapper;
            _mediator = mediator;
            _logger = logger;
        }
        /// <summary>
        /// Get Forecast details based on city
        /// </summary>
        /// <param name="city">City name</param>
        /// <param name="userKey">(auto-generated): To store history based on user</param>
        /// <returns></returns>
        /// <exception cref="ApiException"></exception>
        [HttpGet("GetForecastByCity")]
        public async Task<GetForecastResponse> GetForecastByCity(string city, string userKey)
        {
            try
            {
                _logger.LogInformation("Get Weather Forecast by City");
                var output = await _mediator.Send(new GetForecastInput() { City = city, UserKey = userKey });
                var response = _mapper.MapGetForecastResponse(output);
                return response;
            }
            catch (Exception ex)
            { throw new ApiException(ex.Message); }
        }
        /// <summary>
        /// Get Forecast details based on zipcode
        /// </summary>
        /// <param name="zipCode">Zipcode</param>
        /// <param name="userKey">(auto-generated): To store history based on user</param>
        /// <returns></returns>
        /// <exception cref="ApiException"></exception>
        [HttpGet("GetForecastByZipCode")]
        public async Task<GetForecastResponse> GetForecastByZipCode(string zipCode, string userKey)
        {
            try
            {
                _logger.LogInformation("Get Weather Forecast by Pin Code");
                var output = await _mediator.Send(new GetForecastInput() { ZipCode = zipCode, UserKey = userKey });
                var response = _mapper.MapGetForecastResponse(output);
                return response;
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message);
            }
        }
    }
}
