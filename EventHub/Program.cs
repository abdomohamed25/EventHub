namespace EventHub
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new EventHubContext())
            {
                context.Database.EnsureCreated();

                Console.WriteLine(
                    "EventHub Database Created Successfully!");

                Console.WriteLine("Database Tables:");

                Console.WriteLine("1. EventOrganizers");
                Console.WriteLine("2. OrganizerProfiles");
                Console.WriteLine("3. Events");
                Console.WriteLine("4. Attendees");
                Console.WriteLine("5. Badges");
            }

            Console.ReadKey();
        

        }
    }
}
