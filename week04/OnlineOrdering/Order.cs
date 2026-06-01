using System;
using System.Collections.Generic;

namespace ProductOrdering
{
    public class Order
    {
        // Private member variables
        private List<Product> _products;
        private Customer _customer;

        public Order(Customer customer)
        {
            _customer = customer;
            _products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        // Calculates order final cost including dynamically assessed shipping rates
        public double CalculateTotalCost()
        {
            double total = 0;

            foreach (Product product in _products)
            {
                total += product.GetTotalCost();
            }

            // Determine shipping cost based on encapsulation rules
            double shippingCost = _customer.LivesInUsa() ? 5.00 : 35.00;
            
            return total + shippingCost;
        }

        // Generates the packing label format
        public string GetPackingLabel()
        {
            string label = "--- PACKING LABEL ---\n";
            foreach (Product product in _products)
            {
                label += $"Item: {product.GetName()} | ID: {product.GetProductId()}\n";
            }
            return label;
        }

        // Generates the shipping label format
        public string GetShippingLabel()
        {
            string label = "--- SHIPPING LABEL ---\n";
            label += $"Recipient: {_customer.GetName()}\n";
            label += _customer.GetAddress().GetFullAddress() + "\n";
            return label;
        }
    }
}