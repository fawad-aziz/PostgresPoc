using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using ProposalDomain;
using ProposalDomain.Model;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace PostgresPoc.Controllers
{
	[Route("api/[controller]")]
    public class ProposalController : Controller
    {
		private readonly IProposalDataAccess dataAccessProvider;

		public ProposalController(IProposalDataAccess proposalDataAccess)
		{
			this.dataAccessProvider = proposalDataAccess;
		}

		// GET: api/values
		[HttpGet]
        public IEnumerable<Proposal> Get()
		{
			return this.dataAccessProvider.GetProposals();
		}

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
