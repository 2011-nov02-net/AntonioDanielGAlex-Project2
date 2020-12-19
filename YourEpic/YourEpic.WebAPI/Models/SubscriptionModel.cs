using System;
namespace YourEpic.WebAPI.Models
{
    public class SubscriptionModel
    {
        public UserModel Publisher { get; set; }

        public string HasNewContent { get; set; }

    }
}
