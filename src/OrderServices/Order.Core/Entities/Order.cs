﻿using OrderCore.Entities;
using System;

namespace OrderCore
{
    public class Order : Entity
    {
        public string UserName { get; set; }
        public decimal TotalPrice { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNo { get; set; }


        public string BillingAdress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }


        public string CardNumber { get; set; }
        public string ExpiryDate { get; set; }
        public string CVV { get; set; }
    }
}
