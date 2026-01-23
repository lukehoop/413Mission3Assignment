using System;
using System.Collections.Generic;
using System.Text;

namespace _413Mission3Assignment
{
    public class FoodItem
    {
        // initialize variables
        public string Name = "";
        public string Category = "";
        public int Quantity = 0;
        public DateTime ExpirationDate;


        // constructor
        public FoodItem(string name, string category, int quantity, DateTime expirationDate)
        {
            this.Name = name;
            this.Category = category;
            this.Quantity = quantity;
            this.ExpirationDate = expirationDate;
        }
    }
}
