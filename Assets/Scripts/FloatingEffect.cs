using UnityEngine;
using System.Collections;

public class FloatingEffect : MonoBehaviour {
	public float movementDistance = 0.5f;
	public float floatSpeed = 0.5f;
	public float startingY;
	private bool isMovingUp=true;
	// Use this for initialization
	void Start () {
		startingY = transform.position.y;
		StartCoroutine (Float ());
	}
	
	private IEnumerator Float()
	{
		while (true)
		{
			float newY = transform.position.y + (isMovingUp ? 1 : -1) * 2 * movementDistance * floatSpeed * Time.deltaTime;

			if (newY > startingY + movementDistance)
			{
				newY = startingY + movementDistance;
				isMovingUp = false;
			}
			else if (newY < startingY)
			{
				newY = startingY;
				isMovingUp = true;
			}

			transform.position = new Vector3(transform.position.x, newY, transform.position.z);
			yield return 0;
		}
	}

}
