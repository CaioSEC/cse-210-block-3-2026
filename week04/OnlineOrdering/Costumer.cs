using System;

namespace ProductOrdering
{
    public class Customer
    {
        // Private member variables
        private string _name;
        private Address _address; // Compounding: Address is a class type

        public Customer(string name, Address address)
        {
            _name = name;
            _address = address;
        }

        // Public getters to allow the Order class to access needed strings
        public string GetName() => _name;
        public Address GetAddress() => _address;

        // Encapsulated method that uses the internal Address object's logic
        public bool LivesInUsa()
        {
            return _address.IsInUsa();
        }
    }
}