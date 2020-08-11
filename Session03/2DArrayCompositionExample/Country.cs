using System;
using System.Collections.Generic;
using _2DArrayCompositionArchitecture;

namespace _2DArrayCompositionExample
{
    public class Country : BaseComparableClass
    {
        public string Name { get; set; }
        public int Population { get; set; }
        public int GDP { get; set; }

        public Country(string name, int population, int gdp)
        {
            Name = name;
            Population = population;
            GDP = gdp;
        }
        protected override void SetPropertyTitleMappingDictionary()
        {
            //By using nameof() we don't have to use "Magic Strings" which makes it more robust.  
            //If we want to change the name of a property we can and dont have to worry about changing the string here!
            PropertyTitleDictionary = new Dictionary<string, string> {
                { nameof(Name), "Country Name"},
                { nameof(Population), "Population" },
                { nameof(GDP), "GDP"}
            };
        }

        public override string ToString()
        {
            return String.Format("{0, 10}\tPopulation: {1, 5} mil\tGDP: ${2, 10} mil\t", Name, Population, GDP);
        }
    }
}
