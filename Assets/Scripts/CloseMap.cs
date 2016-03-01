using UnityEngine;
using System.Collections;

public class CloseMap : MonoBehaviour {
	public GameObject p;
	public void Onclick(){
		p.transform.localScale -= new Vector3 (3f, 3f, 3f);

	}
}
