/* Copyright (c) 2011 Technicat, LLC. All rights reserved. */

// batch gameobject hierarchy that moves together

#pragma strict

function Start () {
	StaticBatchingUtility.Combine(gameObject);
}