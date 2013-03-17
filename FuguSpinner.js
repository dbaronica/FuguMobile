#pragma strict

function Start() {
	GameObject.DontDestroyOnLoad(this.gameObject);
	StartCoroutine(StartActivityIndicator());
}

function StartActivityIndicator () {
	#if UNITY_IPHONE
	Handheld.SetActivityIndicatorStyle(iOSActivityIndicatorStyle.Gray);
	#endif
	#if UNITY_ANDROID
	Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.InversedLarge);
	#endif
	Handheld.StartActivityIndicator();
	yield;
}

function OnLevelWasLoaded() {
	Handheld.StopActivityIndicator();
	GameObject.Destroy(gameObject);
}