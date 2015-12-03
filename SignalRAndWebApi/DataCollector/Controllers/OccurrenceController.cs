using System.Web.Http;
using DataCollector.Hubs;
using Microsoft.AspNet.SignalR;

namespace DataCollector.Controllers
{
    public class OccurrenceController : ApiController
    {
        #region Public Methods

        [HttpPost]
        [Route("api/occurrence")]
        public IHttpActionResult ReportOccurrence([FromBody] int value)
        {
            GlobalHost.ConnectionManager.GetHubContext<DataDistributor>().Clients.All.ConsumeData(value);
            return Ok();
        }


        [HttpGet]
        [Route("api/occurrence/{text}")]
        public IHttpActionResult echo(string text)
        {
            return Ok(text);
        }
        #endregion Public Methods
    }
}