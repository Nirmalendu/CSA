using UnityEngine;
using System.Collections;

public class rotation2 : MonoBehaviour {

	int audiovar2 = 0;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.Rotate(0,-20*Time.deltaTime,0);

		if (audiovar2 == 0) {

			if (GetComponent<MeshRenderer> ().enabled) {
				AudioSource audio = GetComponent<AudioSource> ();
				audio.Play ();
				audiovar2 = 1;
			}

		}
	
	}
}
