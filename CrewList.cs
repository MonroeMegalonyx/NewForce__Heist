using System.Collections.Generic;

namespace heist
{
  public class CrewList
  {
    // Create a way to store several team members.

    private List<TeamMember> crew = new List<TeamMember>();

    public bool AddMember(TeamMember m)
    {
      crew.Add(m);
      return true;
    }

  }
}