using System;

namespace ProductOrdering
{
    public class Address
    {
        // Private member variables
        private string _streetAddress;
        private string _city;
        private string _stateProvince;
        private string _country;

        public Address(string streetAddress, string city, string stateProvince, string country)
        {
            _streetAddress = streetAddress;
            _city = city;
            _stateProvince = stateProvince;
            _country = country;
        }

        // Method to determine if the country is the USA
        public bool IsInUsa()
        {
            // Case-insensitive comparison for reliability
            return _country.Equals("USA", StringComparison.OrdinalIgnoreCase) || 
                   _country.Equals("United States", StringComparison.OrdinalIgnoreCase);
        }

        // Method to return the full address block formatted with newlines
        public string GetFullAddress()
        {
            return $"{_streetAddress}\n{_city}, {_stateProvince}\n{_country}";
        }
    }
}