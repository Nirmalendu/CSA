using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Rating : MonoBehaviour {
	public Button current;
	public Button[] buttons;
	public Button[] parent_buttons;
	public Text[] text_c;
	public Text[] text_parent;
	public string total = "";
	public string c;
	void Start () {
		buttons = current.GetComponentsInChildren<Button> ();
		parent_buttons = current.GetComponentsInParent<Button> ();
		text_c = current.GetComponentsInChildren<Text> ();
		text_parent = current.GetComponentsInParent<Text> ();

	}
	
	public void OnClick(){
		foreach (Button butt in buttons) {
			butt.image.color = Color.red;
		}
		foreach (Button butt in parent_buttons) {
			butt.image.color = Color.grey;
		}
		foreach (Text t in text_c) {
			t.text = "0";
		}
		foreach (Text t in text_parent) {
			t.text = "0";
		}
		total = "";
		current.image.color = Color.red;
		current.GetComponentInChildren<Text> ().text="1";
		c = current.GetComponentInChildren<Text> ().text;
		foreach (Text t in text_c) {
			total = total + t.text;
		}

	}
}
