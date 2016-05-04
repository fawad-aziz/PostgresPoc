using ProposalDomain.Model;
using System.Collections.Generic;

namespace ProposalDomain
{
	public interface IProposalDataAccess
	{
		void AddProposal(Proposal proposal);

		void UpdateProposal(Proposal proposal);

		IEnumerable<Proposal> GetProposals();
	}
}
