#pragma strict
var StarsCanvas : GameObject;

function OnBecameVisible() {
	StarsCanvas.SetActive(true);
}

function OnBecameInvisible() {
	StarsCanvas.SetActive(false);
}