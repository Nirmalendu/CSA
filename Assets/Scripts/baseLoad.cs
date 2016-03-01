using UnityEngine;
using System.Collections;
public class baseLoad : MonoBehaviour {
	public void OnClick(){
		Debug.Log ("Clicked");
		Application.LoadLevel (1);
	}
}