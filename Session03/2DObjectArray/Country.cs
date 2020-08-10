using _2DObjectArrayLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2DObjectArray
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
        protected override void SetPropertyTitleDictionary()
        {
            PropertyTitleDictionary = new Dictionary<string, string> {
                { "Name", "Country Name"},
                // { "Population", "Population" },
                { "GDP", "GDP"}
            };
        }

        public override string ToString()
        {
            return String.Format("{0, 10}\tPopulation: {1, 5} mil\tGDP: ${2, 10} mil\t", Name, Population, GDP);
        }
    }
}
