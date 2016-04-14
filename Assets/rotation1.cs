using UnityEngine;
using System.Collections;

public class rotation1 : MonoBehaviour {

	int audiovar1 = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0,-20*Time.deltaTime,0);

		if (audiovar1 == 0) {

			if (GetComponent<MeshRenderer> ().enabled) {
				AudioSource audio = GetComponent<AudioSource> ();
				audio.Play ();
				audiovar1 = 1;
			}

		}
	}
}
