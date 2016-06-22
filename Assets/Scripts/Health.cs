using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour {

	public Text text;
	public float foodMultiplier;
	public float decreaseSpeed;
	public float waterDecreaseSpeed;
	public bool inWater = false;

	[SerializeField]
	private float healthStatus;

	void Update() {
		healthStatus -= Time.deltaTime * decreaseSpeed;
		text.text = (int)healthStatus + "";

		if (inWater) {
			healthStatus -= Time.deltaTime * waterDecreaseSpeed;
		}
	}

	public void eat() {
		healthStatus += foodMultiplier;
		if (healthStatus > 100)
			healthStatus = 100;
	}
}
