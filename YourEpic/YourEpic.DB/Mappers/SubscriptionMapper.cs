using System;
using System.Collections.Generic;
using System.Text;

namespace YourEpic.DB.Mappers
{
    public static class SubscriptionMapper
    {
        public static Subscription Map(Domain.Models.Subscription model) {
            return new Subscription {
                SubscriberId = model.Subscriber.ID,
                WriterId = model.Publisher.ID,
                HasNewContent = model.HasNewContent
            };
        }

        public static Domain.Models.Subscription Map(Subscription entity) {
            return new Domain.Models.Subscription { 
                Subscriber = UserMapper.Map(entity.Subscriber),
                Publisher = UserMapper.Map(entity.Writer),
                HasNewContent = (bool)entity.HasNewContent
            };
        }
    }
}
