using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using SimpleJSON;

public class Rating : MonoBehaviour {
	public Button current;
	public Button[] buttons;
	public Button[] parent_buttons;
	public Text[] text_c;
	public Text[] text_parent;
	public string total = "";
	public string aa = "";
	private int count=0;

	public string c;
	void Start () {
		buttons = current.GetComponentsInChildren<Button> ();
		parent_buttons = current.GetComponentsInParent<Button> ();
		text_c = current.GetComponentsInChildren<Text> ();
		text_parent = current.GetComponentsInParent<Text> ();

	}

	public void OnClick(){
		count = count + 1;
		if (count <= 3) {
			foreach (Button butt in buttons) {
				butt.image.color = Color.yellow;
				butt.GetComponentInChildren<Text> ().text = "0";

			}
			foreach (Button butt in parent_buttons) {
				butt.image.color = Color.grey;
				butt.GetComponentInChildren<Text> ().text = "0";
			}
			/*foreach (Text t in text_c) {
			t.text = "0";
		}
		foreach (Text t in text_parent) {
			t.text = "0";
		}*/

			current.image.color = Color.yellow;
			current.GetComponentInChildren<Text> ().text = "1";
			c = current.GetComponentInChildren<Text> ().text;
			/*foreach (Text t in text_c) {
			total = total + t.text;
		}
		Debug.Log (total);*/

			foreach (Button butt in buttons) {

				total = total + butt.GetComponentInChildren<Text> ().text;

			}
			//print (total);
			if (total.Length > 6) {
				total = total.Substring (0, 5);
			}
			char[] ar = total.ToCharArray ();
			int ratng = 1;

			for (int d = 1; d < ar.Length; d++) {

				if (ar [d] != 1)
					ratng = ratng + 1;
				else
					break;

			}

			var name = current.transform.root.name;
			var uid = PlayerPrefs.GetInt ("UserID");
			print (ratng);
			string url = "http://10.192.27.22:8000/fn/"+name+"/rate/"+uid+"/"+ratng+"/";
			WWW www = new WWW(url);
			while (!www.isDone) {
				var x = 1 + 1;
			}
			Debug.Log(www.text);
			//We can get the total rating if you want


		}

	}
}