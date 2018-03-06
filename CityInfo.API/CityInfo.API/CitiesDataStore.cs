using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfo.API.Models;

namespace CityInfo.API
{
    public class CitiesDataStore
    {
        public static CitiesDataStore Current { get; } = new CitiesDataStore();
        public List<CityDto> Cities { get; set; }

        public CitiesDataStore()
        {
            Cities = new List<CityDto>()
            {
                new CityDto()
                {
                    Id = 1,
                    Name = "New York City",
                    Description = "The one with the big park.",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 1,
                            Name = "Central Park",
                            Description = "The most visited urban park in US."
                        },
                        new PointOfInterestDto()
                        {
                            Id = 2,
                            Name = "Empire stale building",
                            Description = "A 102 - story skycraper."
                        }
                    }
                },

                new CityDto()
                {
                    Id = 2,
                    Name = "Kaunas",
                    Description = "The one where two rivers meet.",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 3,
                            Name = "Kaunas castle",
                            Description = "castle near two rivers"
                        },
                        new PointOfInterestDto()
                        {
                            Id = 4,
                            Name = "Pažaislis",
                            Description = "The monastery near the lake"
                        }
                    }
                },
                new CityDto()
                {
                    Id = 3,
                    Name = "Paris",
                    Description = "The one with that big tower.",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto() {
                            Id = 5,
                            Name = "Eiffel Tower",
                            Description = "A wrought iron lattice tower on the Champ de Mars, named after engineer Gustave Eiffel." },
                        new PointOfInterestDto() {
                            Id = 6,
                            Name = "The Louvre",
                            Description = "The world's largest museum." },
                    }
                }
            };
        }
    }
}
