using System.Collections.Generic;
using System.Linq;

namespace heist
{
  public class CrewList
  {
    // Create a way to store several team members.

    private List<TeamMember> crew = new List<TeamMember>();

    // Add a new team member to the crew
    public bool AddMember(TeamMember m)
    {
      crew.Add(m);
      return true;
    }

    // Count how many team members are in on the job
    public int CountMembers()
    {
      return crew.Count();
    }

    // Printout the crew member's information
    public List<TeamMember> GetCrew()
    {
      return crew;
    }

  }
}