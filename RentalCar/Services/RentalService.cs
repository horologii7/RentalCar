using Entities;
using System;

namespace Services
{
    class RentalService
    {
        public double pricePerHour { get; private set; }
        public double pricePerDay { get; private set; }

        public BrazilTaxService _brazilTaxService = new BrazilTaxService();
        public RentalService(double pricePerHour, double pricePerDay)
        {
            this.pricePerHour = pricePerHour;
            this.pricePerDay = pricePerDay;
        }

        public void processInvoice(CarRental carRental)
        {
            TimeSpan time = carRental.finish.Subtract(carRental.start);

            double basicPayment = 0.0;
            if (time.TotalHours <= 12.0)
                basicPayment = pricePerHour * Math.Ceiling(time.TotalHours);
            else
                basicPayment = pricePerDay * Math.Ceiling(time.TotalDays);

            double tax = _brazilTaxService.tax(basicPayment);

            carRental.invoice = new Invoice(basicPayment, tax);         
        }
    }
}
