using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
 
/// <summary>
///AdMobのバナー広告を表示するクラス
/// </summary>
public class ShowAdMobBanner : MonoBehaviour {
    private string adUnitId;
    private RewardedAd rewardedAd;
    private InterstitialAd interstitialAd;
    [SerializeField]
    private UnityEngine.Events.UnityEvent   m_events    = new UnityEngine.Events.UnityEvent();
    void Start () {
        string appId = "ca-app-pub-7022695364176797~9078594653";
        
        MobileAds.Initialize(appId);
        RequestBanner();
        RequestReward();
        RequestInterstitial();
    }
    private void RequestReward()
    {
    #if UNITY_ANDROID
        adUnitId = "ca-app-pub-7022695364176797/3676667112";  //テスト
    #endif
        this.rewardedAd = new RewardedAd(adUnitId);
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        AdRequest request = new AdRequest.Builder().Build();
        this.rewardedAd.LoadAd(request);
    }
    private void RequestBanner()
    {
 
        // 広告ユニットID これはテスト用
        string adUnitId = "ca-app-pub-7022695364176797/8887022961";
 
        // Create a 320x50 banner at the top of the screen.
        BannerView bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
 
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
 
        // Load the banner with the request.
        bannerView.LoadAd(request);
 
    }
    public void RequestInterstitial()
    {
#if UNITY_ANDROID
        adUnitId = "ca-app-pub-7022695364176797/7451248835";
#endif
        this.interstitialAd = new InterstitialAd(adUnitId);
        AdRequest request = new AdRequest.Builder().Build();
        interstitialAd.LoadAd(request);
        
    }
    //これを呼べば動画が流れる（例えばボタン押下時など）
    public void ShowReawrd()
    {
        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
        }
    } public void ShowInterstitial()
    {
        if (this.interstitialAd.IsLoaded()) {
            this.interstitialAd.Show();
        }
    }
    public void HandleUserEarnedReward(object sender, Reward args)
    {
        m_events.Invoke();

    }
    // Update is called once per frame
    void Update () {
		
    }
}