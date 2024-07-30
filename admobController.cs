//this file is for google admob "rewarded ad" integration.
//dont forget to add your admob ap id in the unity editor too.
//Attach this file to your entry scene. 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class admobController : MonoBehaviour
{
    public static string rewardedAdID = "Your App Ad ID";  //Find in the admob panel
    public bool userIsRewarded = false;                    //Control the user is watched the ad and reward or not.
    public static int adCounter;                           //you can use this variable to show ad when its reached to target number. 

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        startMobileAdsSDK();
    }

    //use only enterance of app.
    public void startMobileAdsSDK(){
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {
            SceneManager.LoadScene("mainMenu");
            LoadRewardedAd();
        });
    }

    private RewardedAd _rewardedAd;
    public void LoadRewardedAd(){
        // Clean up the old ad before loading a new one.
        if (_rewardedAd != null)
        {
            _rewardedAd.Destroy();
            _rewardedAd = null;
        }

        // create our request used to load the ad.
        var adRequest = new AdRequest();

        // send the request to load the ad.
        RewardedAd.Load(rewardedAdID, adRequest,
          (RewardedAd ad, LoadAdError error) =>
          {
              // if error is not null, the load request failed.
              if (error != null || ad == null)
              {
                  Debug.LogError("Rewarded ad failed to load an ad with error : " + error);
                  return;
              }
              Debug.Log("Rewarded ad loaded with response : " + ad.GetResponseInfo());
              _rewardedAd = ad;
              RegisterEventHandlers(_rewardedAd);
          });
    }

    public void ShowRewardedAd()
    {
        if (_rewardedAd != null && _rewardedAd.CanShowAd())
        {
            _rewardedAd.Show((Reward reward) =>
            {
                // TODO: Reward the user.
                userIsRewarded = true;
            });
        }
    }

    private void RegisterEventHandlers(RewardedAd ad)
    {
        // Raised when the ad is estimated to have earned money.
        ad.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log("we get money from this ad");
        };
        // Raised when an impression is recorded for an ad.
        ad.OnAdImpressionRecorded += () =>
        {
            Debug.Log("Rewarded ad recorded an impression.");
        };
        // Raised when a click is recorded for an ad.
        ad.OnAdClicked += () =>
        {
            Debug.Log("Rewarded ad was clicked.");
        };
        // Raised when an ad opened full screen content.
        ad.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Rewarded ad full screen content opened.");
        };
        // Raised when the ad closed full screen content.
        ad.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Rewarded ad full screen content closed.");
            LoadRewardedAd();
        };
        // Raised when the ad failed to open full screen content.
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Rewarded ad failed to open full screen content with error : " + error);
            LoadRewardedAd();
        };
    }
}
