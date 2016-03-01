using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CurrentTime : MonoBehaviour {
	public Text time;
	public GameObject p;
	bool bShowButton = true;
	public Sprite first_floor;
	public Sprite second_floor;
	public Sprite third_floor;
	public struct Events
	{
		public string eventName;
		public int h;
		public Sprite a;
		public int posX;
		public int posY;

	};

	Text s;
	void Start(){
		Events[] total = new Events[7];
		total [0].h = 21;
		total [0].eventName = "Game of Code";
		total [0].a = first_floor;
		total [0].posX = 50;
		total [0].posY = 50;
	}
	 void Update ()
	{
		System.DateTime a = System.DateTime.Now;
		int h = a.Hour;
		int m = a.Minute;
		int s = a.Second;
		time.text = h + ":" + m + ":" + s;

	}
	void createObject(){
		s = gameObject.AddComponent<Text> ();
		s.text = "Hello World";

	}
	void OnGUI ()
	{
		System.DateTime a = System.DateTime.Now;
		int h = a.Hour;
		int m = a.Minute;
		int s = a.Second;
		if (GUI.Button (new Rect (100, 100, 150, 100), "About")) 
			GUI.Label (new Rect (0, 100, 100, 100), "Nirmalendu");




		if (bShowButton) {
			if (h == h && m == m) {
				GUI.Label (new Rect (0, 100, 100, 100), "Time for new event");
				//GUI.Button (new Rect (160, 10, 150, 100), "I am b button");
				//GUI.Button (new Rect (30, 10, 150, 100), "I am b button");
				if (GUI.Button (new Rect (10, 10, 150, 100), "I am a button")) {
					p.transform.localScale += new Vector3 (3f, 3f, 3f);
					bShowButton = false;




				}
			}
		}
	}
}
