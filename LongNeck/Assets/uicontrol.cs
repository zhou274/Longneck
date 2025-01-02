


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
using StarkSDKSpace;
using TTSDK.UNBridgeLib.LitJson;
using TTSDK;

public class uicontrol : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Win,Lose,Tap,ingame;
    public bool isAdshow;
    public string clickid;
    private StarkAdManager starkAdManager;

    public static uicontrol _uicontrol;
    void Awake()
{
    _uicontrol=this;
}
    void Start()
    {
       GoogleAdMobController.Instance.Initialize();
      GoogleAdMobController.Instance.RequestBannerAd();
        Tap.SetActive(true);
        isAdshow=false;
    }
  public void retryBtn_1()
  {
    	   GoogleAdMobController.Instance.ShowInterstitialAd();

       SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }
    public void retryBtn()
  {

        ShowVideoAd("192if3b93qo6991ed0",
            (bol) => {
                if (bol)
                {

                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);


                    clickid = "";
                    getClickid();
                    apiSend("game_addiction", clickid);
                    apiSend("lt_roi", clickid);


                }
                else
                {
                    StarkSDKSpace.AndroidUIManager.ShowToast("观看完整视频才能获取奖励哦！");
                }
            },
            (it, str) => {
                Debug.LogError("Error->" + str);
                //AndroidUIManager.ShowToast("广告加载异常，请重新看广告！");
            });
        
  }
    public void NextBtn()
  {
        ShowVideoAd("192if3b93qo6991ed0",
            (bol) => {
                if (bol)
                {
                    PlayerPrefs.SetInt("LevelNum", PlayerPrefs.GetInt("LevelNum") + 1);
                    PlayerPrefs.SetInt("LevelNum_D", PlayerPrefs.GetInt("LevelNum_D") + 1);
                    if (PlayerPrefs.GetInt("LevelNum") > 4)
                    {
                        PlayerPrefs.SetInt("LevelNum", 0);
                    }
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);



                    clickid = "";
                    getClickid();
                    apiSend("game_addiction", clickid);
                    apiSend("lt_roi", clickid);


                }
                else
                {
                    StarkSDKSpace.AndroidUIManager.ShowToast("观看完整视频才能获取奖励哦！");
                }
            },
            (it, str) => {
                Debug.LogError("Error->" + str);
                //AndroidUIManager.ShowToast("广告加载异常，请重新看广告！");
            });
      
  }
  public IEnumerator WinPanel()
   {
        ShowInterstitialAd("1lcaf5895d5l1293dc",
               () => {
                   Debug.LogError("--插屏广告完成--");

               },
               (it, str) => {
                   Debug.LogError("Error->" + str);
               });
        yield return new WaitForSeconds(3.2f);
     uicontrol._uicontrol.Win.SetActive(true);
     yield return new WaitForSeconds(1.3f);
       GoogleAdMobController.Instance.ShowInterstitialAd();

   }
    public IEnumerator LosePanel()
   {
        ShowInterstitialAd("1lcaf5895d5l1293dc",
            () => {
                Debug.LogError("--插屏广告完成--");

            },
            (it, str) => {
                Debug.LogError("Error->" + str);
            });
        uicontrol._uicontrol.Lose.SetActive(true);
     yield return new WaitForSeconds(1.3f);
   
     GoogleAdMobController.Instance.ShowInterstitialAd();

   }
    public void getClickid()
    {
        var launchOpt = StarkSDK.API.GetLaunchOptionsSync();
        if (launchOpt.Query != null)
        {
            foreach (KeyValuePair<string, string> kv in launchOpt.Query)
                if (kv.Value != null)
                {
                    Debug.Log(kv.Key + "<-参数-> " + kv.Value);
                    if (kv.Key.ToString() == "clickid")
                    {
                        clickid = kv.Value.ToString();
                    }
                }
                else
                {
                    Debug.Log(kv.Key + "<-参数-> " + "null ");
                }
        }
    }

    public void apiSend(string eventname, string clickid)
    {
        TTRequest.InnerOptions options = new TTRequest.InnerOptions();
        options.Header["content-type"] = "application/json";
        options.Method = "POST";

        JsonData data1 = new JsonData();

        data1["event_type"] = eventname;
        data1["context"] = new JsonData();
        data1["context"]["ad"] = new JsonData();
        data1["context"]["ad"]["callback"] = clickid;

        Debug.Log("<-data1-> " + data1.ToJson());

        options.Data = data1.ToJson();

        TT.Request("https://analytics.oceanengine.com/api/v2/conversion", options,
           response => { Debug.Log(response); },
           response => { Debug.Log(response); });
    }


    /// <summary>
    /// </summary>
    /// <param name="adId"></param>
    /// <param name="closeCallBack"></param>
    /// <param name="errorCallBack"></param>
    public void ShowVideoAd(string adId, System.Action<bool> closeCallBack, System.Action<int, string> errorCallBack)
    {
        starkAdManager = StarkSDK.API.GetStarkAdManager();
        if (starkAdManager != null)
        {
            starkAdManager.ShowVideoAdWithId(adId, closeCallBack, errorCallBack);
        }
    }

    /// <summary>
    /// 播放插屏广告
    /// </summary>
    /// <param name="adId"></param>
    /// <param name="errorCallBack"></param>
    /// <param name="closeCallBack"></param>
    public void ShowInterstitialAd(string adId, System.Action closeCallBack, System.Action<int, string> errorCallBack)
    {
        starkAdManager = StarkSDK.API.GetStarkAdManager();
        if (starkAdManager != null)
        {
            var mInterstitialAd = starkAdManager.CreateInterstitialAd(adId, errorCallBack, closeCallBack);
            mInterstitialAd.Load();
            mInterstitialAd.Show();
        }
    }
}
