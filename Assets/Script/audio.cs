using UnityEngine;
using System.Collections;

public class audio : MonoBehaviour {

	int audiovar = 0;

	// Use this for initialization
	void Start () {

	 
	
	}
	
	// Update is called once per frame
	void Update () {

		if (audiovar == 0) {

			if (GetComponent<MeshRenderer> ().enabled) {
				AudioSource audios1 = GetComponent<AudioSource> ();
				audios1.Play ();
				audiovar = 1;
			}

            else
            {
                AudioSource audios1 = GetComponent<AudioSource>();
                audios1.Stop ();
                audiovar = 0;
            }

		}


			

		
	
	}
}
