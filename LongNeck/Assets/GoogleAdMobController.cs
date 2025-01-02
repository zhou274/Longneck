


using UnityEngine.Events;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class GoogleAdMobController : MonoBehaviour
{

    private UnityAction<bool> OnCompleteMethod;
    private bool triggerCompleteMethod;

    private BannerView bannerView;
    private BannerView bannerView1;
    private BannerView bannerRectView;
    private InterstitialAd interstitialAd;
    private RewardedAd rewardedAd;
    private RewardedInterstitialAd rewardedInterstitialAd;
  //  private float deltaTime;

    public UnityEvent OnAdLoadedEvent;
    public UnityEvent OnAdFailedToLoadEvent;
    public UnityEvent OnAdOpeningEvent;
    public UnityEvent OnAdFailedToShowEvent;
    public UnityEvent OnUserEarnedRewardEvent;
    public UnityEvent OnAdClosedEvent;
   // public bool showFpsMeter = true;
  //  public Text fpsMeter;
   // public Text statusText;
    public static GoogleAdMobController Instance { set; get; }

    #region UNITY MONOBEHAVIOR METHODS
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Start()
    {
        MobileAds.SetiOSAppPauseOnBackground(true);

        List<String> deviceIds = new List<String>() { AdRequest.TestDeviceSimulator };

        // Add some test device IDs (replace with your own device IDs).
#if UNITY_IPHONE
        deviceIds.Add("96e23e80653bb28980d3f40beb58915c");
#elif UNITY_ANDROID
        deviceIds.Add("5a5d46a2-8202-42e5-b5c0-79f8a2d76edd");
#endif
  
        // Configure TagForChildDirectedTreatment and test device IDs.
        RequestConfiguration requestConfiguration =
            new RequestConfiguration.Builder()

            .SetTagForChildDirectedTreatment(TagForChildDirectedTreatment.Unspecified)

            .SetTestDeviceIds(deviceIds).build();

        MobileAds.SetRequestConfiguration(requestConfiguration);
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize((initStatus) =>
        {
            Dictionary<string, AdapterStatus> map = initStatus.getAdapterStatusMap();
            foreach (KeyValuePair<string, AdapterStatus> keyValuePair in map)
            {
                string className = keyValuePair.Key;
                AdapterStatus status = keyValuePair.Value;
                switch (status.InitializationState)
                {
                    case AdapterState.NotReady:
                        // The adapter initialization did not complete.
                        MonoBehaviour.print("Adapter: " + className + " not ready.");
                        break;
                    case AdapterState.Ready:
                        // The adapter was successfully initialized.
                        MonoBehaviour.print("Adapter: " + className + " is initialized.");
                        break;
                }
            }
        });
    }
    public void Initialize() {
        RequestAndLoadInterstitialAd();
        RequestAndLoadRewardedAd();
        RequestRectangleBannerAd();
    }
    private void HandleInitCompleteAction(InitializationStatus initstatus)
    {
        // Callbacks from GoogleMobileAds are not guaranteed to be called on
        // main thread.
        // In this example we use MobileAdsEventExecutor to schedule these calls on
        // the next Update() loop.
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
           // statusText.text = "Initialization complete";
            RequestBannerAd();
            RequestBannerAd1();
            RequestRectangleBannerAd();
        });
    }

    private void Update()
    {
        //if (showFpsMeter)
        //{
        //    fpsMeter.gameObject.SetActive(true);
        //    deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        //    float fps = 1.0f / deltaTime;
        //    fpsMeter.text = string.Format("{0:0.} fps", fps);
        //}
        //else
        //{
        //    fpsMeter.gameObject.SetActive(false);
        //}
    }

    #endregion

    #region HELPER METHODS

    private AdRequest CreateAdRequest()
    {
        return new AdRequest.Builder()
            .AddKeyword("unity-admob-sample")
            .Build();
    }

    #endregion

    #region BANNER ADS

    public void RequestBannerAd()
    {
    //    statusText.text = "Requesting Banner Ad.";
        // These ad units are configured to always serve test ads.
#if UNITY_EDITOR
        string adUnitId = "unused";
#elif UNITY_ANDROID
        string adUnitId = "ca-app-pub-4406595947194551/2017151145";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-4406595947194551/3269734081";
#else
        string adUnitId = "unexpected_platform";
#endif
        // Clean up banner before reusing
        if (bannerView != null )
        {
            bannerView.Destroy();
        }

        // Create a 320x50 banner at top of the screen
        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.TopRight);

        // Add Event Handlers
        bannerView.OnAdLoaded += (sender, args) => OnAdLoadedEvent.Invoke();
        bannerView.OnAdFailedToLoad += (sender, args) => OnAdFailedToLoadEvent.Invoke();
        bannerView.OnAdOpening += (sender, args) => OnAdOpeningEvent.Invoke();
        bannerView.OnAdClosed += (sender, args) => OnAdClosedEvent.Invoke();

        // Load a banner ad
        bannerView.LoadAd(CreateAdRequest());
        // bannerView.Hide();
        if (PlayerPrefs.GetInt("RemoveAds") == 1)
        {
            bannerView.Destroy();
        }
    }

    public void DestroyBannerAd()
    {
        if (bannerView != null)
        {
            bannerView.Destroy();
        }
    }
    public void RequestBannerAd1()
    {
        //    statusText.text = "Requesting Banner Ad.";
        // These ad units are configured to always serve test ads.
#if UNITY_EDITOR
        string adUnitId = "unused";
#elif UNITY_ANDROID
        string adUnitId = "ca-app-pub-4406595947194551/2017151145";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-4406595947194551/3269734081";
#else
        string adUnitId = "unexpected_platform";
#endif
        // Clean up banner before reusing
        if (bannerView1 != null)
        {
            bannerView1.Destroy();
        }

        // Create a 320x50 banner at top of the screen
        bannerView1 = new BannerView(adUnitId, AdSize.Banner, AdPosition.TopLeft);

        // Add Event Handlers
        bannerView1.OnAdLoaded += (sender, args) => OnAdLoadedEvent.Invoke();
        bannerView1.OnAdFailedToLoad += (sender, args) => OnAdFailedToLoadEvent.Invoke();
        bannerView1.OnAdOpening += (sender, args) => OnAdOpeningEvent.Invoke();
        bannerView1.OnAdClosed += (sender, args) => OnAdClosedEvent.Invoke();

        // Load a banner ad
        bannerView1.LoadAd(CreateAdRequest());
        // bannerView1.Hide();
        if (PlayerPrefs.GetInt("RemoveAds") == 1)
        {
            bannerView1.Destroy();
        }
    }
    public void RequestRectangleBannerAd()
    {
        //    statusText.text = "Requesting Banner Ad.";
        // These ad units are configured to always serve test ads.
#if UNITY_EDITOR
        string adUnitId = "unused";
#elif UNITY_ANDROID
        string adUnitId = "ca-app-pub-4406595947194551/2017151145";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-4406595947194551/2764112529";
#else
        string adUnitId = "unexpected_platform";
#endif
        // Clean up banner before reusing
        if (bannerRectView != null)
        {
            bannerRectView.Destroy();
        }

        // Create a 320x50 banner at top of the screen
        bannerRectView = new BannerView(adUnitId, AdSize.MediumRectangle, AdPosition.BottomLeft);

        // Add Event Handlers
        bannerRectView.OnAdLoaded += (sender, args) => OnAdLoadedEvent.Invoke();
        bannerRectView.OnAdFailedToLoad += (sender, args) => OnAdFailedToLoadEvent.Invoke();
        bannerRectView.OnAdOpening += (sender, args) => OnAdOpeningEvent.Invoke();
        bannerRectView.OnAdClosed += (sender, args) => OnAdClosedEvent.Invoke();

        // Load a banner ad
        bannerRectView.LoadAd(CreateAdRequest());
        if (bannerRectView != null)
        {
            bannerRectView.Hide();
        }
        if (PlayerPrefs.GetInt("RemoveAds") == 1)
        {
            bannerRectView.Destroy();
        }
    }
    public void BannerRectShow() {
        if (bannerRectView != null)
        {
            bannerRectView.Show();
        }
    }
    public void BannerRectHide()
    {
        if (bannerRectView != null)
        {
            bannerRectView.Hide();
        }
    }
    #endregion

    #region INTERSTITIAL ADS

    public void RequestAndLoadInterstitialAd()
    {
      //  statusText.text = "Requesting Interstitial Ad.";
#if UNITY_EDITOR
        string adUnitId = "unused";
#elif UNITY_ANDROID
        string adUnitId = "ca-app-pub-4406595947194551/4498832497";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-4406595947194551/1859167575";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Clean up interstitial before using it
        if (interstitialAd != null)
        {
            interstitialAd.Destroy();
        }

        interstitialAd = new InterstitialAd(adUnitId);

        // Add Event Handlers
        interstitialAd.OnAdLoaded += (sender, args) => OnAdLoadedEvent.Invoke();
        interstitialAd.OnAdFailedToLoad += (sender, args) => OnAdFailedToLoadEvent.Invoke();
        interstitialAd.OnAdOpening += (sender, args) => OnAdOpeningEvent.Invoke();
        interstitialAd.OnAdClosed += (sender, args) => OnAdClosedEvent.Invoke();

        // Load an interstitial ad
        interstitialAd.LoadAd(CreateAdRequest());
    }

    public void ShowInterstitialAd()
    {
        if (interstitialAd.IsLoaded() && PlayerPrefs.GetInt("RemoveAds") != 1)
        {
            interstitialAd.Show();
            RequestAndLoadInterstitialAd();
        }
        else
        {
            RequestAndLoadInterstitialAd();
       //     statusText.text = "Interstitial ad is not ready yet";
        }
    }
    public bool IsInterstitialAdLoaded()
    {
        if (interstitialAd.IsLoaded())
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    public void DestroyInterstitialAd()
    {
        if (interstitialAd != null)
        {
            interstitialAd.Destroy();
        }
    }
    #endregion

    #region REWARDED ADS

    public void RequestAndLoadRewardedAd()
    {
      //  statusText.text = "Requesting Rewarded Ad.";
#if UNITY_EDITOR
        string adUnitId = "unused";
#elif UNITY_ANDROID
        string adUnitId = "ca-app-pub-4406595947194551/1872669157";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-4406595947194551/7017407405";
#else
        string adUnitId = "unexpected_platform";
#endif

        // create new rewarded ad instance
        rewardedAd = new RewardedAd(adUnitId);

        // Add Event Handlers
        rewardedAd.OnAdLoaded += (sender, args) => OnAdLoadedEvent.Invoke();
        rewardedAd.OnAdFailedToLoad += (sender, args) => OnAdFailedToLoadEvent.Invoke();
        rewardedAd.OnAdOpening += (sender, args) => OnAdOpeningEvent.Invoke();
        rewardedAd.OnAdFailedToShow += (sender, args) => OnAdFailedToShowEvent.Invoke();
        rewardedAd.OnAdClosed += (sender, args) => OnAdClosedEvent.Invoke();
        rewardedAd.OnUserEarnedReward += (sender, args) => OnUserEarnedRewardEvent.Invoke();

        // Create empty ad request
        rewardedAd.LoadAd(CreateAdRequest());
    }
    public void ShowRewardedAd()
    {
        if (rewardedAd != null && PlayerPrefs.GetInt("RemoveAds") != 1)
        {
          //  OnCompleteMethod = CompleteMethod;
         //   triggerCompleteMethod = true;
            rewardedAd.Show();
            RequestAndLoadRewardedAd();
        }
        else
        {
            RequestAndLoadRewardedAd();
            //   statusText.text = "Rewarded ad is not ready yet.";
        }
    }
    public void ShowRewardedAd(UnityAction<bool> CompleteMethod)
    {
        if (rewardedAd != null && PlayerPrefs.GetInt("RemoveAds") != 1)
        {
            OnCompleteMethod = CompleteMethod;
            triggerCompleteMethod = true;
            rewardedAd.Show();
            RequestAndLoadRewardedAd();
        }
        else
        {
            RequestAndLoadRewardedAd();
            //   statusText.text = "Rewarded ad is not ready yet.";
        }
    }
    public bool IsRewardVideoAvailable()
    {
        if (rewardedAd.IsLoaded())
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    public void RequestAndLoadRewardedInterstitialAd()
    {
       // statusText.text = "Requesting Rewarded Interstitial Ad.";
        // These ad units are configured to always serve test ads.
    #if UNITY_EDITOR
        string adUnitId = "unused";
#elif UNITY_ANDROID
            string adUnitId = "ca-app-pub-4406595947194551/2590854451";
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-4406595947194551/1698274330";
#else
            string adUnitId = "unexpected_platform";
#endif

        // Create an interstitial.
        RewardedInterstitialAd.LoadAd(adUnitId, CreateAdRequest(), (rewardedInterstitialAd, error) =>
        {

          if (error != null)
          {
            MobileAdsEventExecutor.ExecuteInUpdate(() => {
              //  statusText.text = "RewardedInterstitialAd load failed, error: " + error;
            });
            return;
          }

          this.rewardedInterstitialAd = rewardedInterstitialAd;
          MobileAdsEventExecutor.ExecuteInUpdate(() => {
           //   statusText.text = "RewardedInterstitialAd loaded";
          });
          // Register for ad events.
          this.rewardedInterstitialAd.OnAdDidPresentFullScreenContent += (sender, args) =>
          {
            MobileAdsEventExecutor.ExecuteInUpdate(() => {
              //  statusText.text = "Rewarded Interstitial presented.";
            });
          };
          this.rewardedInterstitialAd.OnAdDidDismissFullScreenContent += (sender, args) =>
          {
            MobileAdsEventExecutor.ExecuteInUpdate(() => {
             // statusText.text = "Rewarded Interstitial dismissed.";
            });
            this.rewardedInterstitialAd = null;
          };
          this.rewardedInterstitialAd.OnAdFailedToPresentFullScreenContent += (sender, args) =>
          {
            MobileAdsEventExecutor.ExecuteInUpdate(() => {
             //   statusText.text = "Rewarded Interstitial failed to present.";
            });
            this.rewardedInterstitialAd = null;
          };
        });
    }

    public void ShowRewardedInterstitialAd()
    {
        if (rewardedInterstitialAd != null)
        {
            rewardedInterstitialAd.Show((reward) => {
              MobileAdsEventExecutor.ExecuteInUpdate(() => {
            //      statusText.text = "User Rewarded: " + reward.Amount ;

              });
            });
        }
        else
        {
           // statusText.text = "Rewarded ad is not ready yet.";
        }
    }
    public bool IsRewardedInterstitialAdLoaded()
    {
        if (rewardedInterstitialAd != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    #endregion

    public void OnUserEarnedReward()
    {
        if (triggerCompleteMethod == true)
        {
            triggerCompleteMethod = false;
            if (OnCompleteMethod != null)
            {
                OnCompleteMethod(true);
                OnCompleteMethod = null;
            }
        }

    }
    public void OnAdFailedToLoad()
    {
        if (triggerCompleteMethod == true)
        {
            triggerCompleteMethod= false;
            if (OnCompleteMethod != null)
            {
                OnCompleteMethod(false);
                OnCompleteMethod = null;
            }
        }

    }
}
