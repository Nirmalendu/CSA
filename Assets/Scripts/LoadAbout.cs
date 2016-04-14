using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadAbout : MonoBehaviour {
	public GameObject LoadingScene;
	public Image LoadingBar;

	public void OnClick(){
		AsyncOperation async = Application.LoadLevelAsync (4);
		//while (!async.isDone) {
		//	LoadingBar.fillAmount = async.progress * .9f;
		//}
	}


}
