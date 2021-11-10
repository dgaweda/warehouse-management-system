using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Commands.DeliveryCommands
{
    public class SetDeliveryName
    {
        private List<Delivery> _deliveries;
        private Delivery _parameter;

        public SetDeliveryName(List<Delivery> deliveries, Delivery Parameter)
        {
            _deliveries = deliveries;
            _parameter = Parameter;
            Set(_deliveries, _parameter);
        }
        public Delivery Set(List<Delivery> deliveries, Delivery Parameter)
        {
            var deliveryNumber = CountDateRepetitionInDB(deliveries, Parameter);
            Parameter.Name = $"DELIVERY/{deliveryNumber}/DATE/{Parameter.Arrival.Date.Day}/{Parameter.Arrival.Date.Month}/{Parameter.Arrival.Date.Year}";
            return Parameter;
        }

        public int CountDateRepetitionInDB(List<Delivery> deliveries, Delivery Parameter)
        {
            var deliveriesInSameDay = 1;
            deliveries.ForEach(property =>
            {
                if (property.Arrival.Date == Parameter.Arrival.Date)
                    deliveriesInSameDay++;
            });

            return deliveriesInSameDay;
        }
    }
}
