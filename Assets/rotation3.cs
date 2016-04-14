using UnityEngine;
using System.Collections;

public class rotation3 : MonoBehaviour {

	int audiovar3 = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {



		if (audiovar3 == 0) {

			if (GetComponent<MeshRenderer> ().enabled) {
				AudioSource audio = GetComponent<AudioSource> ();
				audio.Play ();
				audiovar3 = 1;
			}

		}
	
	}
}
