using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interstitial : MonoBehaviour
{
    void Start()
    {
        IronSource.Agent.loadInterstitial();
        IronSourceEvents.onInterstitialAdClosedEvent += InterstitialAdClosedEvent;
    }
    // Invoked when the interstitial ad closed and the user goes back to the application screen.
    void InterstitialAdClosedEvent()
    {
        IronSource.Agent.loadInterstitial();
    }

    public void interstitialplay()
    {
        IronSource.Agent.showInterstitial();
    }
}
