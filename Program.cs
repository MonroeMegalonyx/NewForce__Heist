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
      Console.WriteLine("########################################");
      Console.WriteLine("########### Plan Your Heist! ###########");
      Console.WriteLine("########################################");

      // At the beginning of the program, prompt the user to enter the difficulty level of the bank.
      Console.WriteLine();
      Console.WriteLine("How difficult is the bank to rob? (Enter an integer)");
      int bankLevel = Convert.ToInt32(Console.ReadLine());

      // Make an empty crew list
      CrewList manifest = new CrewList();

      // Refactor to collect several team members' information and stop collecting team members when a blank name is entered.
      bool askUser = true;
      while (askUser == true)
      {
        // Prompt the user to enter a team member's name and save that name.
        Console.WriteLine();
        Console.WriteLine("Implicate your team member for a crime now. (Enter a name, or leave blank to move to next step)");
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
      Console.WriteLine();
      Console.WriteLine($"Great team. You have {manifestCount} people on the crew");
      Console.WriteLine();

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

      // Sum the skill levels of the team. Save that number.
      // Make a list of just the skill values to add
      List<int> skillIndex = new List<int>() { };
      foreach (TeamMember x in crewListCopy)
      {
        skillIndex.Add(x.SkillLevel);
      }

      int teamSkillLevel = skillIndex.Sum();

      // Update to run the scenario multiple times with different luck.
      // Prompt user to enter the number of trial runs the program should perform.
      Console.WriteLine();
      Console.WriteLine("########################################");
      Console.WriteLine("How many trials do you want to run? (Enter a number)");
      int trials = Convert.ToInt32(Console.ReadLine());

      // Make an index to count how many successes and failures there are
      List<int> heistSuccess = new List<int>() { };
      List<int> heistFailure = new List<int>() { };

      for (int i = 0; i < trials; i++)
      {
        // Create a new bank and store a value for the bank's difficulty level. Set this value to 100.
        // Update to create a random number between -10 and 10 for the heist's luck value
        int heistLuck = new Random().Next(-10, 10);
        Bank localBranch = new Bank() { DifficultyLevel = bankLevel + heistLuck };

        // Compare the team skill with the bank's difficulty level. If the team's skill level is greater than or equal to the bank's difficulty level, Display a success message, otherwise display a failure message.

        /* 
        In Phase 6 change report to show count of successes and failures

        Before displaying the success or failure message, display a report that shows:
          - The team's combined skill level
          - The bank's difficulty level
        */
        if (teamSkillLevel >= localBranch.DifficultyLevel)
        {
          // Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
          // Console.WriteLine($"The team's combined skill is {teamSkillLevel}");
          // Console.WriteLine($"Bad new for the bank though, the bank's difficult is only {localBranch.DifficultyLevel}");
          // Console.WriteLine("The heist will be a success");
          heistSuccess.Add(1);
        }
        else
        {
          // Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
          // Console.WriteLine($"The team's combined skill is {teamSkillLevel}");
          // Console.WriteLine($"Bad new for the you though, the bank's difficult is {localBranch.DifficultyLevel}");
          // Console.WriteLine("So think really hard about if you want to do this");
          heistFailure.Add(1);
        }
      }
      // At the end of the program, display a report showing the number of successful runs and the number of failed runs.
      Console.WriteLine();
      Console.WriteLine($"Thanks for playing, the heist succeeded {heistSuccess.Sum()} times, and ended in failure {heistFailure.Sum()} times");
    }
  }
}
