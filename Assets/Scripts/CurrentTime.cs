using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CurrentTime : MonoBehaviour {
	public Text time;
	public GameObject p0;
	public GameObject p1;
	public GameObject p2;
	public GameObject p3;
	public GameObject p4;
	public GameObject p5;
	public GameObject p6;

	public GameObject[] locations = new GameObject[7];
	//public Image di;
	bool bShowButton = true;

	public GUISkin skin;
	public struct Events
	{
		public string eventName;
		public int h;

	};
	Events[] total = new Events[7];

	Text s;


	void Start(){
		total [0].h = 9;
		total [0].eventName = "Technical Talk by Mr. Sree Hari Nagarulu (Microsoft IDC)<117>";
	
		locations [0] = p0;

		locations [1] = p1;
		locations [2] = p2;
		locations [3] = p3;
		locations [4] = p4;
		locations [5] = p5;
		locations [6] = p6;

		//
		total [1].h = 10;
		total [1].eventName = "Tech quiz prelims<254>";

		//
		total [2].h = 11;
		total [2].eventName = "Keynote Speech by Dr. Shivkumar Kalyanaraman (IBM Research - India)<117>";

		//
		total [3].h = 12;
		total [3].eventName = "Tech quiz finals<254>";

		//
		total [4].h = 13;
		total [4].eventName = "Title Sponsor talk by media.net<117>";

		//
		total [5].h = 14;
		total [5].eventName = "Keynote Speech by Dr. S. K. Shivakumar (Former Director, ISAC)<117>";

		//
		total [6].h = 15;
		total [6].eventName = "LAN party<Litec>";

		//


		//di.sprite = first_floor;

	}
	 void Update ()
	{
		System.DateTime a = System.DateTime.Now;
		int h = a.Hour;
		int m = a.Minute;
		int s = a.Second;
		time.text = h + ":" + m + ":" + s;

	}

	void OnGUI ()
	{
		System.DateTime a = System.DateTime.Now;
		int h = a.Hour;


	 	if (bShowButton) {
			for (int i = 0; i <= 6; i++) {
				if (h == total[i].h ) {
					GUI.skin = skin;

					GUI.Label (new Rect (Screen.width/2, Screen.height/8, 100, 100), total[i].eventName);
					//GUI.Button (new Rect (160, 10, 150, 100), "I am b button");
					//GUI.Button (new Rect (30, 10, 150, 100), "I am b button");

					if (GUI.Button (new Rect (Screen.width/2, Screen.height/3, 150, 80), "Show Location")) {
						//GUI.Label (new Rect (Screen.width/2, Screen.height/8, 100, 100), "hi");

						locations[i].SetActive (true);
						locations[i].transform.localScale += new Vector3 (3f, 3f, 3f);
						bShowButton = false;
						//p.GetComponent<SpriteRenderer>().sprite = total[i].a;
						//p.GetComponentInChildren<Image> ().rectTransform.anchoredPosition = new Vector2 (total [i].posX, total [i].posY);




					}
				}
			}
		}
	}
}
