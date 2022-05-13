using System.ComponentModel;

namespace DangerZoneHackerTracker
{
    public class Cheater
	{
		public ulong AccountID; 

		public int ThreatLevel;

		[DefaultValue("")]
		public string CheatList;

		[DefaultValue("")]
		public string LastKnownName;

		[DefaultValue("")]
		public string Notes;

		[DefaultValue("")]
		public string Submitter;
	}
}
