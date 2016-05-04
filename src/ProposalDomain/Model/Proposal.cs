
namespace ProposalDomain.Model
{
	public class Proposal
	{
		public int ProposalId { get; set; }

		public int CampaignId { get; set; }

		public int ProgramId { get; set; }

		public int CurrencyCode { get; set; }

		public string Description { get; set; }

		public string Title { get; set; }

		public int OwnerId { get; set; }

		public ProposalState ProposalState { get; set; }

		public ActivityType ActivityType { get; set; }

		public ProposalType ProposalType { get; set; }
	}
}
