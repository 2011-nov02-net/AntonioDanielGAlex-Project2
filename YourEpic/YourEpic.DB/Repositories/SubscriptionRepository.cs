﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourEpic.Domain.Interfaces;

namespace YourEpic.DB.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly YourEpicProjectTwoDatabaseContext _context;

        public SubscriptionRepository(YourEpicProjectTwoDatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Domain.Models.Subscription> GetMySubscriptions(int userID)
        {
            return _context.Subscriptions
                .Include(s=>s.Subscriber).ThenInclude(s => s.RoleNavigation)
                .Include(w=>w.Writer).ThenInclude(r => r.RoleNavigation).Select(Mappers.SubscriptionMapper.Map).Where(s => s.Subscriber.ID==userID);
        }

        public bool SubscribeToPublisher(int subscriberID, int publisherID)
        {
            var newSubscription = new Subscription { WriterId = publisherID, SubscriberId = subscriberID, HasNewContent = true };

            _context.Add(newSubscription);

            _context.SaveChanges();

            return true;
        }

        public bool UnsubscribeFromPublisher(int subscriberID, int publisherID)
        {
            var deleteSubscription = _context.Subscriptions.Find(publisherID, subscriberID);

            _context.Remove(deleteSubscription);

            _context.SaveChanges();

            return true;
        }
    }
}
