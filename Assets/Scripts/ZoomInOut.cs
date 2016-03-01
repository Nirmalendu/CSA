using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ZoomInOut : MonoBehaviour {
	public GameObject p;
	public Button b;
	public int a=1;
	public void OnClick()
	{
		if (a == 1) {
			p.transform.localScale += new Vector3 (.1f, .1f, .09f);
			b.GetComponentInChildren<Text>().text = "Return";

		} 
		else {
			p.transform.localScale -= new Vector3 (.1f, .1f, .09f);
			b.GetComponentInChildren<Text>().text = "Location";

		}
		a = a * -1;
	}
}
