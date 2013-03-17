/* Copyright (c) 2011 Technicat, LLC. All Rights Reserved */

#pragma strict

#if UNITY_IPHONE
static function IsFirstGenIPhone() {
	return iPhone.generation == iPhoneGeneration.iPhone ||
		iPhone.generation == iPhoneGeneration.iPodTouch1Gen;
}

static function IsSecondGenIPhone() {
	return	iPhone.generation == iPhoneGeneration.iPhone3G ||
		iPhone.generation == iPhoneGeneration.iPodTouch2Gen;
}

static function IsThirdGenIPhone() {
	return	iPhone.generation == iPhoneGeneration.iPhone3GS ||
		iPhone.generation == iPhoneGeneration.iPodTouch3Gen;
}

static function IsFourthGenIPhone() {
	return	iPhone.generation == iPhoneGeneration.iPhone4 ||
		iPhone.generation == iPhoneGeneration.iPodTouch4Gen;
}

static function IsFirstGenIPad() {
	return	iPhone.generation == iPhoneGeneration.iPad1Gen;
}

static function IsSecondGenIPad() {
	return	iPhone.generation == iPhoneGeneration.iPad2Gen;
}

static function IsThirdGenIPad() {
	return	iPhone.generation == iPhoneGeneration.iPad3Gen;
}
#endif








