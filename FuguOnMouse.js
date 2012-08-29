// Copyright (c) 2010-2012 Technicat, LLC. All Right Reserved,

/* convert touches to OnMouse events */
// not really necessary for Unity 4, but maybe it's useful as an example or alternative
// usage: attach to the camera
// just OnMouseDown is implemented, but OnMouseUp would be nearly identical
#if UNITY_IPHONE || UNITY_ANDROID
private var layermask:int = 0;

function Awake() {
	layermask=1<<gameObject.layer; // this is a bit of hack, should use camera visibility mask
}

function Update () {
		var hit : RaycastHit;
		for (var i = 0; i < Input.touchCount; ++i) {
			if (Input.GetTouch(i).phase == TouchPhase.Began) {
				// Construct a ray from the current touch coordinates
				var ray = camera.ScreenPointToRay (Input.GetTouch(i).position);
				// arbitrary distance - should use the camera view distance?
				if (Physics.Raycast (ray,hit,150,layermask)) {
					hit.transform.gameObject.SendMessage("OnMouseDown");
				}
			}
		}
}
#endif