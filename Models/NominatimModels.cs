namespace ProjetMVC.Models
{
    public class NominatimModels
    {
        public class NominatimResponse
        {
            public string Type { get; set; }
            public string Licence { get; set; }
            public List<NominatimFeature> Features { get; set; }
        }

        public class NominatimFeature
        {
            public string Type { get; set; }
            public NominatimProperties Properties { get; set; }
            public double[] Bbox { get; set; }
            public NominatimGeometry Geometry { get; set; }
        }

        public class NominatimProperties
        {
            public long PlaceId { get; set; }
            public string OsmType { get; set; }
            public long OsmId { get; set; }
            public int PlaceRank { get; set; }
            public string Category { get; set; }
            public string Type { get; set; }
            public double Importance { get; set; }
            public string Addresstype { get; set; }
            public string Name { get; set; }
            public string DisplayName { get; set; }
        }

        public class NominatimGeometry
        {
            public string Type { get; set; }
            public double[] Coordinates { get; set; }
        }

        public class NominatimResult
        {
            public double Lat { get; set; }
            public double Lon { get; set; }
        }
    }
}
