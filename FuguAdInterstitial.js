private var ad:ADInterstitialAd;

function Start() {
	if (iPhone.generation == iPhoneGeneration.iPad1Gen || iPhone.generation == iPhoneGeneration.iPad2Gen || iPhone.generation == iPhoneGeneration.iPad3Gen) {
		ad = new ADInterstitialAd();
		while (!ad.loaded) yield;
		ad.Present();
	}
}