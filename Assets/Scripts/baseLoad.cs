using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class baseLoad : MonoBehaviour {
	public GameObject LoadingScene;
	public Image LoadingBar;

	public void OnClick(){
		Application.LoadLevelAsync (1);

	}

}
