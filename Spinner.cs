using UnityEngine;
using System.Collections;

namespace Fugu {
public class Spinner : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject.DontDestroyOnLoad(this.gameObject);
		StartCoroutine(StartActivityIndicator());
	}
		
	IEnumerator StartActivityIndicator () {
		#if UNITY_IPHONE
		Handheld.SetActivityIndicatorStyle(iOSActivityIndicatorStyle.Gray);
		#endif
		#if UNITY_ANDROID
		Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.InversedLarge);
		#endif
#if UNITY_IPHONE || UNITY_ANDROID
		Handheld.StartActivityIndicator();
#endif
		yield return null;
}

	void OnLevelWasLoaded() {
#if UNITY_IPHONE || UNITY_ANDROID
		Handheld.StopActivityIndicator();
#endif
		GameObject.Destroy(gameObject);
}
	
	
}
	
}