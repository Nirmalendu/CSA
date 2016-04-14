using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CSAMap : MonoBehaviour {
	public GameObject LoadingScene;
	public Image LoadingBar;

	public void OnClick(){
		Application.LoadLevelAsync (3);

	}

}
