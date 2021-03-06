using System;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using MAVN.Service.Dictionaries.Client.Api;
using MAVN.Service.Dictionaries.Client.Models.Notifications;
using MAVN.Service.Dictionaries.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace MAVN.Service.Dictionaries.Controllers
{
    [ApiController]
    [Route("api/commonInformation")]
    public class CommonInformationController : ControllerBase, ICommonInformationApi
    {
        private readonly ICommonInformationService _commonInformationService;
        private readonly IMapper _mapper;

        public CommonInformationController(ICommonInformationService commonInformationService, IMapper mapper)
        {
            _commonInformationService = commonInformationService ??
                throw new ArgumentNullException(nameof(commonInformationService));
            _mapper = mapper;
        }

        ///<inheritdoc />
        [HttpGet]
        [ProducesResponseType(typeof(CommonInformationPropertiesModel), (int)HttpStatusCode.OK)]
        public async Task<CommonInformationPropertiesModel> GetCommonInformationAsync()
        {
            var emailNotificationProperties = await _commonInformationService.GetCommonInformationAsync();

            return _mapper.Map<CommonInformationPropertiesModel>(emailNotificationProperties);
        }
    }
}
