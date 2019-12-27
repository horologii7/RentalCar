using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    class Invoice
    {
        public double basicPayment { get; set; }
        public double tax { get; set; }
        public double totalPayment { get { return basicPayment + tax; } }

        public Invoice(double basicPayment, double tax)
        {
            this.basicPayment = basicPayment;
            this.tax = tax;
        }

    }
}
