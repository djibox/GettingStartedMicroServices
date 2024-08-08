using Mango.Web.Models;
using Mango.Web.Services.IService;
using System.Text;
using newton.json;
using Newtonsoft.Json;

namespace Mango.Web.Services
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<ResponseDto?> SendAsync(RequestDto requestDto)
        {
            HttpClient client = _httpClientFactory.CreateClient("MangoAPI");
            HttpRequestMessage message = new();
            message.Headers.Add("Accept", "application/json");
            message.RequestUri = new Uri(requestDto.Url);
            if (requestDto.Data != null)
            {
                message.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, "application/json");
            }
            HttpResponseMessage?apiResponse =null;
            switch (requestDto.ApiType)
            {
                case Utility.SD.ApiType.GET:
                    message.Method = HttpMethod.Get;
                    break;
                case Utility.SD.ApiType.POST:
                    message.Method = HttpMethod.Post;
                    break;
                case Utility.SD.ApiType.PUT:
                    message.Method = HttpMethod.Put;
                    break;
                case Utility.SD.ApiType.DELETE:
                    message.Method = HttpMethod.Delete;
                    break;
            }
        }
    }
}
