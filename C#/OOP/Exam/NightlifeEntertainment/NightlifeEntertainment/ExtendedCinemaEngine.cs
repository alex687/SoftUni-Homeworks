namespace NightlifeEntertainment
{
    using System;
    using System.Linq;

    public class ExtendedCinemaEngine : CinemaEngine
    {
        protected override void ExecuteInsertVenueCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "opera":
                    var opera = new OperaHall(commandWords[3], commandWords[4], int.Parse(commandWords[5]));
                    this.Venues.Add(opera);
                    break;
                case "sports_hall":
                    var sports = new SportsHall(commandWords[3], commandWords[4], int.Parse(commandWords[5]));
                    this.Venues.Add(sports);
                    break;
                case "concert_hall":
                    var concert = new ConcertHall(commandWords[3], commandWords[4], int.Parse(commandWords[5]));
                    this.Venues.Add(concert);
                    break;
                default:
                    base.ExecuteInsertVenueCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteInsertPerformanceCommand(string[] commandWords)
        {
            var venue = this.GetVenue(commandWords[5]);
            switch (commandWords[2])
            {
                case "theatre":
                    var theatre = new Theatre(commandWords[3], decimal.Parse(commandWords[4]), venue, DateTime.Parse(commandWords[6] + " " + commandWords[7]));
                    this.Performances.Add(theatre);
                    break;
                case "concert":
                    var concert = new Concert(commandWords[3], decimal.Parse(commandWords[4]), venue, DateTime.Parse(commandWords[6] + " " + commandWords[7]));
                    this.Performances.Add(concert);
                    break;
                default:
                    base.ExecuteInsertPerformanceCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteSupplyTicketsCommand(string[] commandWords)
        {
            var performance = this.GetPerformance(commandWords[3]);
            switch (commandWords[1])
            {
                case "student":
                    for (int i = 0; i < int.Parse(commandWords[4]); i++)
                    {
                        performance.AddTicket(new StudentTicket(performance));
                    }

                    break;
                case "vip":
                    for (int i = 0; i < int.Parse(commandWords[4]); i++)
                    {
                        performance.AddTicket(new VipTicket(performance));
                    }

                    break;
                default:
                    base.ExecuteSupplyTicketsCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteReportCommand(string[] commandWords)
        {
            var performance = this.GetPerformance(commandWords[1]);
            var soldTickets = performance.Tickets.Where(x => x.Status == TicketStatus.Sold);

            this.Output.AppendLine(performance.Name + ": " + soldTickets.Count() + " ticket(s), total: $" + String.Format("{0:f2}", soldTickets.Sum(x => x.Price)));
            this.Output.AppendLine("Venue: " + performance.Venue.Name + " (" + performance.Venue.Location + ")");
            this.Output.AppendLine("Start time: " + performance.StartTime);
        }

        protected override void ExecuteFindCommand(string[] commandWords)
        {
            var startDate = commandWords[2];
            var startTime = commandWords[3];
            var startDateTime = DateTime.Parse(startDate + " " + startTime);
            var phrase = commandWords[1];
            var phraseLower = commandWords[1].ToLower();

            var performances =
                this.Performances.Where(p => p.StartTime >= startDateTime && p.Name.ToLower().Contains(phraseLower))
                    .OrderBy(p => p.StartTime)
                    .ThenBy(p => p.BasePrice)
                    .ThenBy(p => p.Name)`;
            this.Output.AppendLine("Search for \"" + phrase + "\"");
            this.Output.AppendLine("Performances:");

            bool isEmpty = true;
            foreach (var performance in performances)
            {
                isEmpty = false;
                this.Output.AppendLine("-" + performance.Name);
            }
            if (isEmpty)
            {
               this.Output.AppendLine("no results");
            }


            var venues = this.Venues.Where(v => v.Name.ToLower().Contains(phraseLower)).OrderBy(v => v.Name);
            this.Output.AppendLine("Venues:");
            isEmpty = true;
            foreach (var venue in venues)
            {
                isEmpty = false;
                this.Output.AppendLine("-" + venue.Name);
                var performanceAtVenue = this.Performances.Where(p => p.StartTime >= startDateTime && p.Venue == venue)
                    .OrderBy(p => p.StartTime)
                    .ThenBy(p => p.BasePrice)
                    .ThenBy(p => p.Name);

                foreach (var performance in performanceAtVenue)
                {
                    this.Output.AppendLine("--" + performance.Name);
                }
            }
            if (isEmpty)
            {
                this.Output.AppendLine("no results");
            }
        }
    }
}
