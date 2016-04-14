using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GetEmailID : MonoBehaviour {
	public InputField a;
	//public static string EmailID;
	// Use this for initialization
	void Start () {
		PlayerPrefs.SetString ("EmailID",a.text);
	}

}
