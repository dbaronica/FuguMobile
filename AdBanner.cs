using UnityEngine;
using System.Collections;

namespace Fugu {

public class AdBanner : MonoBehaviour {
		
	public bool showOnTop = true;
	public string AdMobID = "";
#if P31_IAD
	void Start() {
		AdBinding.createAdBanner (!showOnTop);
	}
#endif
#if UNITY_IPHONE && FUGU_ADS && !P31_IAD
	private ADBannerView banner = null;
		
	IEnumerator Start() {
		GameObject.DontDestroyOnLoad(gameObject); // keep ad alive if we load a new scene
		banner = new ADBannerView();
		banner.autoSize = true;
		banner.autoPosition = showOnTop ? ADPosition.Top : ADPosition.Bottom;
		while (!banner.loaded && banner.error == null) {
			yield return null;
		}
		if (banner.error == null) {
			banner.Show();
		} else {
			banner = null;
		}
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
