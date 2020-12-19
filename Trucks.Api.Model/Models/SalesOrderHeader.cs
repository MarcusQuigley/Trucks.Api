using System;
using System.Collections.Generic;

namespace Trucks.Api.Model.Models
{
    public class SalesOrderHeader
    {
        public int SalesOrderHeaderId { get; set; }
        public DateTime OrderDate { get; set; }
        //  public int CustomerDetailsId { get; set; }
        public string CustomerEmail { get; set; }
        public Decimal TotalDue { get; set; }
        public DateTime ModifiedDate { get; set; }

        // public int SalesOrderDetailId { get; set; }
        public virtual ICollection<SalesOrderDetail> SalesDetails { get; set; }
    }
}
