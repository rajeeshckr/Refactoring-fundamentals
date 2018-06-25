﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace PatternRefactorings.ReplaceStateConditionalWithState.Better2
{
    // Step 1: Replace Type Code with Class
    //  Finish Replace Type Code with Class Refactoring
    public class CampaignState
    {
        public static CampaignState Cancelled = new CampaignState("cancelled");
        public static CampaignState Pending = new CampaignState("pending");
        public static CampaignState Approved = new CampaignState("approved");
        public static CampaignState Active = new CampaignState("active");
        public static CampaignState Completed = new CampaignState("completed");
        private static readonly List<CampaignState> _states = new List<CampaignState>()
        {
            Cancelled,
            Pending,
            Approved,
            Active,
            Completed
        };

        public CampaignState(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public static CampaignState ForStatus(string status)
        {
            return _states.Where(s => s.Name == status).FirstOrDefault();
        }
    }

    public class Campaign
    {
        public string Name { get; set; }
        public CampaignState State { get; private set; }
        public string Advertiser { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string LastUpdatedBy { get; private set; }

        public Campaign()
        {
            State = CampaignState.Pending;
        }

        public void UpdateStatus(string newStatus, string userName)
        {
            CampaignState newState = CampaignState.ForStatus(newStatus);
            if(newState == CampaignState.Cancelled)
            {
                if (this.State == CampaignState.Cancelled)
                {
                    throw new InvalidOperationException("Can't cancel a campaign that is already cancelled.");
                }
                if (this.State == CampaignState.Completed)
                {
                    throw new InvalidOperationException("Can't cancel a campaign once it has completed.");
                }
                string message = String.Format("{0} cancelled {1} campaign {2}", userName, this.State.Name, this.Name);
                AdvertiserNotificationService.NotifyAdvertiser(this.Advertiser, message);
                this.State = newState;
                this.LastUpdatedBy = userName;
            }
            else if(newState==CampaignState.Pending)
            {
                    throw new InvalidOperationException("Campaigns are only pending when first created; their status cannot be reset to pending.");
            }
            else if (newState==CampaignState.Approved)
            {
                if (this.State == CampaignState.Approved)
                {
                    throw new InvalidOperationException("Can't approve a campaign once it has already been approved.");
                }
                if (this.State == CampaignState.Completed)
                {
                    throw new InvalidOperationException("Can't approve a campaign once it has completed.");
                }
                if (this.State == CampaignState.Active)
                {
                    throw new InvalidOperationException("Can't approve a campaign once it is active.");
                }
                string message = String.Format("{0} approved {1} campaign {2}", userName, this.State.Name, this.Name);
                AdvertiserNotificationService.NotifyAdvertiser(this.Advertiser, message);
                this.State = newState;
                this.LastUpdatedBy = userName;
            }
            else if (newState==CampaignState.Active)
            {}
            else if (newState==CampaignState.Completed)
            {}
        }

    }
    public class AdvertiserNotificationService
    {
        public static void NotifyAdvertiser(string advertiser, string message)
        {

        }
    }
}
