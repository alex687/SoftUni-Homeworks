namespace GalacticGPS
{
    public enum Planet { Mercury, Venus, Earth, Mars, Jupiter, Saturn, Uranus, Neptune }
    
    public struct Location
    {
        private double latitude;
        private double longitude;
        private Planet planet;

        public Location(double latitude, double longitude, Planet planet)
            : this()
        {
            this.latitude = latitude;
            this.longitude = longitude;
            this.planet = planet;
        }

        public override string ToString()
        {
            return latitude + ", " + longitude + " - " + this.planet.ToString();
        }
    }
}
