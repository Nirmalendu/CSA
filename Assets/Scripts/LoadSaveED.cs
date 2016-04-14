using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadSaveED : MonoBehaviour {

	public GameObject LoadingScene;
	public GameObject CurrentPanel;
	public Image LoadingBar;
	public InputField p;
	public void LoadLevel ()
	{
		StartCoroutine (LevelCoroutine ());
	}
	IEnumerator LevelCoroutine ()
	{
		LoadingScene.SetActive (true);
		CurrentPanel.SetActive (false);
		PlayerPrefs.SetString ("EmailID",p.text);

		AsyncOperation async = Application.LoadLevelAsync (1);

		while (!async.isDone) {
			LoadingBar.fillAmount = async.progress * .9f;
			yield return null;
		}
		//yield return null;

	}
}