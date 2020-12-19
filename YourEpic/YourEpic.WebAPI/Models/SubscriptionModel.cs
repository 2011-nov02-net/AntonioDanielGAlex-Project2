using System;
namespace YourEpic.WebAPI.Models
{
    public class SubscriptionModel
    {
        public UserModel Publisher { get; set; }

        public bool HasNewContent { get; set; }

    }
}
