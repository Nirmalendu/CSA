using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour {

	public GameObject LoadingScene;
	public GameObject CurrentPanel;
	public Image LoadingBar;
	public void LoadLevel ()
	{
		StartCoroutine (LevelCoroutine ());
	}
	IEnumerator LevelCoroutine ()
	{
		LoadingScene.SetActive (true);
		CurrentPanel.SetActive (false);

		/*AsyncOperation async = Application.LoadLevelAsync (level);

		while (!async.isDone) {
			LoadingBar.fillAmount = async.progress * .9f;
			yield return null;
		}*/
		yield return null;

	}
}