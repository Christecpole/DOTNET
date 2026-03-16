using System;
using System.Collections.Generic;
using System.Text;

namespace Panier.Core
{
    public sealed class ShoppingCart
    {
        /*
        public int GetItemCount() => throw new NotImplementedException();
        public void AddItem(string name, decimal price, int quantity) => throw new NotImplementedException();
        public decimal GetTotal() => throw new NotImplementedException();
        public void ApplyDiscount(decimal percentage) => throw new NotImplementedException();
        */
        
        private readonly List<CartItem> _items = new();
        private bool _discountApplied;
        private decimal _discountPercentage;

        public int GetItemCount() => _items.Count;

        public void AddItem(string name, decimal price, int quantity)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Item name cannot be null or empty.", nameof(name));

            if (price <= 0m)
                throw new ArgumentException("Item price must be greater than zero.", nameof(price));

            if (quantity <= 0)
                throw new ArgumentException("Item quantity must be greater than zero.", nameof(quantity));

            _items.Add(new CartItem(name.Trim(), price, quantity));
        }

        public decimal GetTotal()
        {
            decimal total = 0m;

            foreach (var item in _items)
                total += item.Price * item.Quantity;

            if (_discountApplied)
                total = total * (1m - (_discountPercentage / 100m));

            if (total < 0m)
                total = 0m;

            return total;
        }

        public void ApplyDiscount(decimal percentage)
        {
            if (_items.Count == 0)
                throw new InvalidOperationException("Cannot apply a discount on an empty cart.");

            if (percentage < 0m || percentage > 100m)
                throw new ArgumentOutOfRangeException(nameof(percentage), "Discount percentage must be between 0 and 100.");

            if (_discountApplied)
                throw new InvalidOperationException("A discount has already been applied.");

            _discountApplied = true;
            _discountPercentage = percentage;
        
        }
        
    }
}
