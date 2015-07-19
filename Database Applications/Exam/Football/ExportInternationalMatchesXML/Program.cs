namespace ExportInternationalMatchesXML
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Xml;

    using ListAllTeamNames;

    public class Program
    {
        public static void Main(string[] args)
        {
            var context = new FootballEntities();

            var internationalMatches = context.InternationalMatches.OrderBy(im => im.MatchDate)
                .ThenBy(im => im.HomeCountry)
                .ThenBy(im => im.AwayCountry)
                .Select(
                    im => new
                        {
                            im.MatchDate,
                            HomeCountryName = im.HomeCountry.CountryName,
                            HomeCountryCode = im.HomeCountry.CountryCode,
                            AwayCountryName = im.AwayCountry.CountryName,
                            AwayCountryCode = im.AwayCountry.CountryCode,
                            League = im.League.LeagueName,
                            im.HomeGoals,
                            im.AwayGoals
                        });

            string file = "../../international-matches.xml";
            using (XmlWriter writer = XmlWriter.Create(file))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("matches");

                foreach (var match in internationalMatches)
                {
                    writer.WriteStartElement("match");

                    if (match.MatchDate.HasValue)
                    {
                        var date = match.MatchDate.Value;

                        if (date.TimeOfDay.TotalSeconds == 0D)
                        {
                            writer.WriteAttributeString("date", date.ToString("dd-MMM-yyy", CultureInfo.InvariantCulture));
                        }
                        else
                        {
                            writer.WriteAttributeString("date-time", date.ToString("dd-MMM-yyy hh:mm", CultureInfo.InvariantCulture));
                        }
                    }

                    XmlWriteTeamTag(writer, "home", match.HomeCountryCode, match.HomeCountryName);
                    XmlWriteTeamTag(writer, "away", match.AwayCountryCode, match.AwayCountryName);
                    if (match.League != null)
                    {
                        XmlWriteLeagueTag(writer, match.League);
                    }

                    if (match.HomeGoals.HasValue && match.AwayGoals.HasValue)
                    {
                        XmlWriteScoreTag(writer, match.HomeGoals.Value, match.AwayGoals.Value);
                    }

                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        private static void XmlWriteTeamTag(XmlWriter writer, string type, string code, string name)
        {
            writer.WriteStartElement(type + "-country");
            writer.WriteAttributeString("code", code);
            writer.WriteValue(name);
            writer.WriteEndElement();
        }

        private static void XmlWriteLeagueTag(XmlWriter writer, string name)
        {
            writer.WriteStartElement("league");
            writer.WriteValue(name);
            writer.WriteEndElement();
        }

        private static void XmlWriteScoreTag(XmlWriter writer, int homeScores, int awayScores)
        {
            writer.WriteStartElement("score");
            writer.WriteValue(homeScores + "-" + awayScores);
            writer.WriteEndElement();
        }
    }




}
