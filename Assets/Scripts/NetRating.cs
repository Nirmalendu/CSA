using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NetRating : MonoBehaviour {
	public Button b;
	Button[] ar;
	string total = "";
	// Use this for initialization
	void Start () {
		ar = b.GetComponentsInChildren<Button> ();
	}
	
	// Update is called once per frame
	void Update () {
		foreach (Button butt in ar) {
			
			total = total + butt.GetComponentInChildren<Text> ().text;
		}
		print (total);
	}
}
