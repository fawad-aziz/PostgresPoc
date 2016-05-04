using ProposalDomain;
using ProposalDomain.Model;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace ProposalPostgresProvider
{
	public class ProposalPostgreSqlDataAccess : IProposalDataAccess
	{
		private readonly PostgreSqlContext context;

		private readonly ILogger logger;

		public ProposalPostgreSqlDataAccess(PostgreSqlContext context, ILoggerFactory loggerFactory)
		{
			this.context = context;
			this.logger = loggerFactory.CreateLogger("ProposalPostgreSqlDataAccess");
		}

		public void AddProposal(Proposal proposal)
		{
			this.context.Proposals.Add(proposal);
			this.context.SaveChanges();
			this.logger.LogInformation("Proposal saved.");
		}

		public IEnumerable<Proposal> GetProposals()
		{
			return this.context.Proposals;
		}

		public void UpdateProposal(Proposal proposal)
		{
			this.context.Proposals.Update(proposal);
			this.context.SaveChanges();
			this.logger.LogInformation("Proposal updated.");
		}
	}
}