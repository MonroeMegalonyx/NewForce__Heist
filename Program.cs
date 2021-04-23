using System;
using System.Collections.Generic;
using System.Linq;

namespace heist
{
  class Program
  {
    static void Main(string[] args)
    {
      // Print the message "Plan Your Heist!".
      Console.WriteLine("Plan Your Heist!");

      // Make an empty crew list
      CrewList manifest = new CrewList();

      // Refactor to collect several team members' information and stop collecting team members when a blank name is entered.
      bool askUser = true;
      while (askUser == true)
      {
        // Prompt the user to enter a team member's name and save that name.
        Console.WriteLine("Implicate your team member for a crime now. (Enter a name)");
        string readName = Console.ReadLine();

        // Exit if blank and set askUser to false
        if (readName != "")
        {
          // Prompt the user to enter a team member's skill level and save that skill level with the name.
          Console.WriteLine($"What is {readName}'s skill level for the heist? (Enter a whole number above zero)");
          int readSkill = Convert.ToInt32(Console.ReadLine());
          //Prompt the user to enter a team member's courage factor and save that courage factor with the name.
          Console.WriteLine("That's interesting...");
          Console.WriteLine($"What is {readName}'s courage factor for the heist? (Enter a decimal between 0.0 and 2.0, I don't make the rules.)");
          float readCourage = float.Parse(Console.ReadLine());
          // Save the entered information as an accomplice
          TeamMember accomplice = new TeamMember()
          {
            Name = readName,
            SkillLevel = readSkill,
            CourageFactor = readCourage
          };
          // Add the current accomplice to the crew list
          manifest.AddMember(accomplice);
        }
        else
        {
          askUser = false;
        }
      }

      // Display a message containing the number of members of the team.
      int manifestCount = manifest.CountMembers();
      Console.WriteLine($"Great team. You have {manifestCount} people on the crew");

      // Make a copy of the crew list from the manifest to use
      List<TeamMember> crewListCopy = manifest.GetCrew();

      /* Stop displaying team member's information in Phase 3
      // Display each team member's information.      
      foreach (TeamMember x in crewListCopy)
      {
        Console.WriteLine($"Welcome aboard {x.Name}");
        Console.WriteLine($"Skill level: {x.SkillLevel} | Courage factor: {x.CourageFactor}");
      }
      */

      // Create a new bank and store a value for the bank's difficulty level. Set this value to 100.
      Bank localBranch = new Bank(){ DifficultyLevel = 100};

      // Sum the skill levels of the team. Save that number.
      // Make a list of just the skill values to add
      List<int> skillIndex = new List<int>(){};
      foreach (TeamMember x in crewListCopy)
      {
        skillIndex.Add(x.SkillLevel);
      }

      int teamSkillLevel = skillIndex.Sum();
      
      // Compare the number with the bank's difficulty level. If the team's skill level is greater than or equal to the bank's difficulty level, Display a success message, otherwise display a failure message.
      if (teamSkillLevel >= localBranch.DifficultyLevel)
      {
        Console.WriteLine("SUCCESS $$$");
      }
      else 
      {
        Console.WriteLine("Think really hard about if you want to do this");
      }

    }
  }
}
