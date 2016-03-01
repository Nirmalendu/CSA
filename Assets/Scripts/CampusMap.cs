using UnityEngine;
using System.Collections;
public class CampusMap : MonoBehaviour {
	public void OnClick(){
		Debug.Log ("Clicked");
		Application.LoadLevel (2);
	}
}