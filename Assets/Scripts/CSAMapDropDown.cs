using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CSAMapDropDown : MonoBehaviour {
	public Dropdown dropdownMenu;
	public Image a;
	public Sprite ground;
	public Sprite first;
	public Sprite second;
	void Update()
	{
		Sprite[] floors = new Sprite[]{ ground, first, second };

		dropdownMenu.onValueChanged.AddListener(delegate {a.sprite = floors[dropdownMenu.value]  ;});
		Debug.Log (dropdownMenu.value+ "hi");

	}


}
