using UnityEngine;
using System.Collections;

public class rotateButton : MonoBehaviour {
	public GameObject g;
	public void OnCLick(){
		Debug.Log (g.transform.up);
		g.transform.up =new Vector3 (0f,0f,0f);
	}
}
