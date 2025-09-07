using System.Text.Json;
using System.Text;

namespace ProjetMVC.Services
{
    public class GeocodingService
    {
        private readonly HttpClient _httpClient;

        public GeocodingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GeoCoordinates> ValidateAndGeocodeAddressAsync(string address)
        {
            var baseUrl = "https://nominatim.openstreetmap.org/search";
            var url = $"{baseUrl}?q={Uri.EscapeDataString(address)}&format=geojson";

            // Ajout User-Agent (sinon cause erreur 403)
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("PARTAGe");

            try
            {
                // Envoi de la requête et récupération de la réponse JSON
                using var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var responseStream = await response.Content.ReadAsStreamAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var nominatimResponse = await JsonSerializer.DeserializeAsync<NominatimResponse>(responseStream, options);

                if (nominatimResponse != null && nominatimResponse.Features != null && nominatimResponse.Features.Count > 0)
                {
                    var firstFeature = nominatimResponse.Features[0];
                    var coordinates = firstFeature.Geometry?.Coordinates;
                    if (coordinates != null && coordinates.Length >= 2)
                    {
                        return new GeoCoordinates { Latitude = coordinates[1], Longitude = coordinates[0] };
                    }
                }
            }
            catch (Exception)
            {
            }

            return null;
        }
    }

}

public class NominatimResponse
{
    public List<Feature> Features { get; set; }
}

public class Feature
{
    public GeoGeometry Geometry { get; set; }
}

public class GeoGeometry
{
    public double[] Coordinates { get; set; }
}

public class GeoCoordinates
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}



public class Coordinates
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}
