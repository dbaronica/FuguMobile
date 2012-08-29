// if for some reason you don't want to use Unity's auto-rotation
// only handles portrait, but easy to extend to landscape

private var orientation:DeviceOrientation;

function Start () {
		gameObject.DontDestroyOnLoad(gameObject);
		AdjustOrientation();
}

function Update () {
	if (orientation != Input.deviceOrientation) {
		AdjustOrientation();
	}
}

function AdjustOrientation() {
	orientation = Input.deviceOrientation;
	switch (orientation) {
	case DeviceOrientation.Portrait:
		if (Screen.orientation != ScreenOrientation.Portrait) {
			Screen.orientation = ScreenOrientation.Portrait;
			}
		break;
	case DeviceOrientation.PortraitUpsideDown:
		if (Screen.orientation != ScreenOrientation.PortraitUpsideDown) {
			Screen.orientation = ScreenOrientation.PortraitUpsideDown;
			}
		break;
	}
}