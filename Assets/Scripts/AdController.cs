using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;

public class AdController : MonoBehaviour {

    public static AdController instance = null;
    private string store_id = "3005352";
    private string video_ad = "video";
    private string rewarded_video_ad = "rewardedVideo";
    private string banner_ad = "bannerAd";

    // Use this for initialization
    void Start () {
        Monetization.Initialize(store_id, false);
	}

    void Awake()
    {
        if (instance != null)
        {
            DestroyObject(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }

    // Update is called once per frame
    public void ShowAd () {
        // is the video ad ready to be played
        if (Monetization.IsReady(video_ad))
        {
            ShowAdPlacementContent ad = null;
            ad = Monetization.GetPlacementContent(video_ad) as ShowAdPlacementContent;

            if(ad != null)
            {
                ad.Show();
            }
        }
    }
}
