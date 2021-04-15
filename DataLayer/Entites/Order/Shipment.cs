using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entites.Order
{
    public class Shipment
    {
        [Key]
        public int ShipmmentId { get; set; }
        public byte State { get; set; }

        public DateTime? SendDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public byte HowSend { get; set; }
        public string PostalBarCode { get; set; }
        public int ShippingCost { get; set; }
        public int SumAmount { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
        public List<ShipmentDetail> ShipmentDetails { get; set; }
    }
}
