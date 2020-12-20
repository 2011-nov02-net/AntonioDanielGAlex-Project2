using System;
using YourEpic.WebAPI.Models;
namespace YourEpic.WebAPI.Mappers
{
    public class SubscriptionModelMapper
    {
        public static SubscriptionModel Map(Domain.Models.Subscription sub) {
            return new SubscriptionModel {
                Publisher = new UserModel { ID = sub.Publisher.ID},
                Subscriber = new UserModel { ID = sub.Subscriber.ID},
                HasNewContent = sub.HasNewContent
            };
        }

        public static Domain.Models.Subscription Map(SubscriptionModel model) {
            return new Domain.Models.Subscription {
                Subscriber = new Domain.Models.User {ID = model.Subscriber.ID, Name = model.Publisher.Name},
                Publisher = new Domain.Models.User { ID = model.Publisher.ID, Name = model.Publisher.Name},
                HasNewContent = model.HasNewContent
            };
        }
    }
}
