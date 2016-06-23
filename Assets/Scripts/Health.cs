using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour {

	public Animator canvasAnimator;
	public WaterMovement waterMovement;
	public Text text;
	public float foodMultiplier;
	public float decreaseSpeed;
	public float waterDecreaseSpeed;
	public bool inWater = false;
	bool start = false;

	[SerializeField]
	private float healthStatus;

	void Update() {
		if (!start)
			return;
		
		healthStatus -= Time.deltaTime * decreaseSpeed;
		text.text = (int)healthStatus + "";

//		if (inWater) {
//			healthStatus -= Time.deltaTime * waterDecreaseSpeed;
//		}

		if (healthStatus <= 0 || inWater) {
			canvasAnimator.SetTrigger("End");
		}
	}

	public void eat() {
		healthStatus += foodMultiplier;
		if (healthStatus > 100)
			healthStatus = 100;
	}

	public void StartCount() {
		start = true;
		waterMovement.StartIncrease();
	}
}
