using System;

namespace ProductOrdering
{
    public class Product
    {
        // Private member variables
        private string _name;
        private string _productId;
        private double _price;
        private int _quantity;

        public Product(string name, string productId, double price, int quantity)
        {
            _name = name;
            _productId = productId;
            _price = price;
            _quantity = quantity;
        }

        // Getters for properties needed in label generation
        public string GetName() => _name;
        public string GetProductId() => _productId;

        // Method to calculate total cost for this product line item
        public double GetTotalCost()
        {
            return _price * _quantity;
        }
    }
}