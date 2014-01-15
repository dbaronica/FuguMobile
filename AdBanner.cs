using UnityEngine;
using System.Collections;

namespace Fugu {

public class AdBanner : MonoBehaviour {
		
	public bool showOnTop = true;
	public string AdMobID = "";
#if UNITY_IPHONE && FUGU_ADS && P31_IAD
	void Start() {
		AdBinding.createAdBanner (!showOnTop);
	}
#endif
#if UNITY_IPHONE && FUGU_ADS && !P31_IAD
	private ADBannerView banner = null;
		
	void Start() {
		GameObject.DontDestroyOnLoad(gameObject); // keep ad alive if we load a new scene
		banner = new ADBannerView(ADBannerView.Type.Banner,showOnTop ? 
			                          ADBannerView.Layout.Top : ADBannerView.Layout.Bottom);
		ADBannerView.onBannerWasLoaded  += OnBannerLoaded;
		}

		void OnBannerLoaded()
		{
			Debug.Log("Ad banner Loaded!\n");
			banner.visible = true;
		}
#endif
#if UNITY_ANDROID && FUGU_ADS
		void Start() {
				AdMobAndroid.init(AdMobID);
				AdMobAndroid.createBanner(AdMobAndroidAd.smartBanner, showOnTop ?
					AdMobAdPlacement.TopCenter : 
					AdMobAdPlacement.BottomCenter);
		}
#endif
	
}

} // end namespace
