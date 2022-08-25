﻿namespace CustomerManagement.BusinessEntities
{
    public class Address
    {
        public int AddressId { get; set; }
        public int CustomerId { get; set; } = 0;
        public string AddressLine { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressType { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
