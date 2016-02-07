using UnityEngine;
using System;
using System.Collections;
using GoogleMobileAds;
using GoogleMobileAds.Api;

/* ~~~~~~~~~~ Class Info ~~~~~~~~~~
 *  - Sets the ads based on what platform game is running on.
 *  - Ads include banner and interstiail.
 *  
 *  --
 *  ~ Code by Jordan Marx ~ (2016)
 */

public class Ads : MonoBehaviour {

    // Ad that takes up whole page
    private InterstitialAd interstitial;

    // Banner ad on bottom of screen
    private BannerView bannerView;

    void Start()
    {
        // Create a 250x250 banner.
        AdSize adSize = new AdSize(250, 250);
        bannerView = new BannerView(
                "ca-app-pub-8082064498416450/8145076128", adSize, AdPosition.Bottom);

        // Register for ad events.
        bannerView.AdLoaded += HandleAdLoaded;
        bannerView.AdFailedToLoad += HandleAdFailedToLoad;
        bannerView.AdOpened += HandleAdOpened;
        bannerView.AdClosing += HandleAdClosing;
        bannerView.AdClosed += HandleAdClosed;
        bannerView.AdLeftApplication += HandleAdLeftApplication;

        // Request
        AdRequest request = new AdRequest.Builder()
        .AddTestDevice(AdRequest.TestDeviceSimulator)       // Simulator.
        .AddTestDevice("3BD361B306BE5D37")  // My test device.
        .Build();

        // Load the banner
        bannerView.LoadAd(request);

        // Request the interstitial
        RequestInterstitial();
    }


    /*
     * Requests the banner depending on what platform you are on.
     * Currently I have no apple ID.
     */
    private void RequestBanner()
    {
        #if UNITY_ANDROID
        string adUnitId = "ca-app-pub-8082064498416450/8145076128";
        #elif UNITY_IPHONE
            string adUnitId = "INSERT_IOS_BANNER_AD_UNIT_ID_HERE";
        #else
            string adUnitId = "unexpected_platform";
        #endif

        // Create a banner at the top of the screen.
        BannerView bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);


        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        bannerView.LoadAd(request);
    }


    /*
     * Requests an interstitial ad depending on what platform you are on.
     * Currently I have no apple ID.
     */
    private void RequestInterstitial()
    {
        #if UNITY_ANDROID
        string adUnitId = "ca-app-pub-8082064498416450/8923805325";
        #elif UNITY_IPHONE
                string adUnitId = "INSERT_IOS_INTERSTITIAL_AD_UNIT_ID_HERE";
        #else
                string adUnitId = "unexpected_platform";
        #endif

        // Initialize an InterstitialAd.
        interstitial = new InterstitialAd(adUnitId);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder()
        .AddTestDevice(AdRequest.TestDeviceSimulator)
        .AddTestDevice("3BD361B306BE5D37")  // My test device.
        .Build();

        // Load the interstitial with the request.
        interstitial.LoadAd(request);
        
    }


    /*
     * When it is game over then display the interstitial.
     * If it is not loaded yet then it won't display anything.
     */
    private void GameOver()
    {
        // Make sure it is loaded
        if (interstitial.IsLoaded())
        {
            // Show it
            interstitial.Show();
        }
    }

    /*
     * Hides the banner ad.
     */
    public void HideAd()
    {
        bannerView.Hide();
    }

    /*
     * Shows the banner ad.
     */
    public void ShowAd()
    {
        bannerView.Show();
    }


    // Handle banner ad loaded
    public void HandleAdLoaded(object sender, EventArgs args)
    {
        print("HandleAdLoaded event received.");
    }

    // Handle banner ad failed to load
    public void HandleAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        print("HandleFailedToReceiveAd event received with message: " + args.Message);
    }

    // Handle banner ad opened
    public void HandleAdOpened(object sender, EventArgs args)
    {
        print("HandleAdOpened event received");
    }

    // Handle banner ad closing
    void HandleAdClosing(object sender, EventArgs args)
    {
        print("HandleAdClosing event received");
    }

    // Handle banner ad closed
    public void HandleAdClosed(object sender, EventArgs args)
    {
        print("HandleAdClosed event received");
    }

    // Handle banner ad left application
    public void HandleAdLeftApplication(object sender, EventArgs args)
    {
        print("HandleAdLeftApplication event received");
    }


    // Handle interstitial ad loaded
    public void HandleInterstitialLoaded(object sender, EventArgs args)
    {
        print("HandleInterstitialLoaded event received.");
    }

    // Handle interstitial ad failed to load
    public void HandleInterstitialFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        print("HandleInterstitialFailedToLoad event received with message: " + args.Message);
    }

    // Handle interstitial ad opened
    public void HandleInterstitialOpened(object sender, EventArgs args)
    {
        print("HandleInterstitialOpened event received");
    }

    // Handle interstitial ad closing
    void HandleInterstitialClosing(object sender, EventArgs args)
    {
        print("HandleInterstitialClosing event received");
    }

    // Handle interstitial closed
    public void HandleInterstitialClosed(object sender, EventArgs args)
    {
        print("HandleInterstitialClosed event received");
    }

    // Handle interstitial left application
    public void HandleInterstitialLeftApplication(object sender, EventArgs args)
    {
        print("HandleInterstitialLeftApplication event received");
    }
    
}
