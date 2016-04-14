using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnterEmailID : MonoBehaviour {

	public GameObject LoadingScene;
	//public GameObject CurrentPanel;

	//public Image LoadingBar;

	public void LoadLevel ()
	{
		gameObject.SetActive (false);
		LoadingScene.SetActive (true);
		//CurrentPanel.SetActive (false);

		//StartCoroutine (LevelCoroutine ());
	}
	/*IEnumerator LevelCoroutine ()
	{
		AsyncOperation async = Application.LoadLevelAsync (1);

		while (!async.isDone) {
			LoadingBar.fillAmount = async.progress * .9f;
			yield return null;
		}
		//yield return null;

	}*/
}