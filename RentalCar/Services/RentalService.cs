using Entities;
using RentalCar.Services;
using System;

namespace Services
{
    class RentalService
    {
        public double pricePerHour { get; private set; }
        public double pricePerDay { get; private set; }

        public ITaxService _taxService;
        public RentalService(double pricePerHour, double pricePerDay, ITaxService taxService)
        {
            this.pricePerHour = pricePerHour;
            this.pricePerDay = pricePerDay;
            _taxService = taxService;
        }

        public void processInvoice(CarRental carRental)
        {
            TimeSpan time = carRental.finish.Subtract(carRental.start);

            double basicPayment = 0.0;
            if (time.TotalHours <= 12.0)
                basicPayment = pricePerHour * Math.Ceiling(time.TotalHours);
            else
                basicPayment = pricePerDay * Math.Ceiling(time.TotalDays);

            double tax = _taxService.tax(basicPayment);

            carRental.invoice = new Invoice(basicPayment, tax);         
        }
    }
}
