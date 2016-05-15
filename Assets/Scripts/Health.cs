using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour {

	public Text text;
	public float foodMultiplier;
	public float decreaseSpeed;

	[SerializeField]
	private float healthStatus;

	void Update() {
		healthStatus -= Time.deltaTime * decreaseSpeed;
		text.text = (int)healthStatus + "";
	}

	public void eat() {
		healthStatus += foodMultiplier;
		if (healthStatus > 100)
			healthStatus = 100;
	}
}
