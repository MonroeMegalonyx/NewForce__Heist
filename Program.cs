using System;

namespace heist
{
    class Program
    {
        static void Main(string[] args)
        {
            // Print the message "Plan Your Heist!".
            Console.WriteLine("Plan Your Heist!");

            // Prompt the user to enter a team member's name and save that name.
            Console.WriteLine("Implicate your team member for a crime now. (Enter a name)");
            string readName = Console.ReadLine();

            // Prompt the user to enter a team member's skill level and save that skill level with the name.
            Console.WriteLine($"What is {readName}'s skill level for the heist? (Enter a whole number above zero)");
            int readSkill = Convert.ToInt32(Console.ReadLine());
            //Prompt the user to enter a team member's courage factor and save that courage factor with the name.
            Console.WriteLine("That's interesting...");
            Console.WriteLine($"What is {readName}'s courage factor for the heist? (Enter a decimal between 0.0 and 2.0, I don't make the rules.)");
            float readCourage = float.Parse(Console.ReadLine());

            //Display the team member's information.
            TeamMember accomplice = new TeamMember()
            {
              Name = readName,
              SkillLevel = readSkill,
              CourageFactor = readCourage
            };
            Console.WriteLine($"Welcome aboard {accomplice.Name}");
            Console.WriteLine($"Skill level: {accomplice.SkillLevel} | Courage factor: {accomplice.CourageFactor}");


        }
    }
}
