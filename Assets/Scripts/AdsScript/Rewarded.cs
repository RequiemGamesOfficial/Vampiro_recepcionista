using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rewarded : MonoBehaviour
{
    public string appkey;
    
    void Start()
    {
        IronSource.Agent.shouldTrackNetworkState(true);
        IronSourceEvents.onRewardedVideoAvailabilityChangedEvent += RewardedVideoAvailabilityChangedEvent;
        IronSourceEvents.onRewardedVideoAdClosedEvent += RewardedVideoAdClosedEvent;
    }

    public void rewarded()
    {
        IronSource.Agent.showRewardedVideo();
    }

    void RewardedVideoAdClosedEvent()
    {
        IronSource.Agent.init(appkey, IronSourceAdUnits.REWARDED_VIDEO);
        IronSource.Agent.shouldTrackNetworkState(true);
    }

    void RewardedVideoAvailabilityChangedEvent(bool available)
    {
        //Change the in-app 'Traffic Driver' state according to availability.
        bool rewardedVideoAvailability = available;

    }
}
