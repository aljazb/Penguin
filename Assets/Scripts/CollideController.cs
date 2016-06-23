using UnityEngine;
using System.Collections;

public class CollideController : MonoBehaviour {

	public Health health;
	public Animator canvasAnimator;

	void OnTriggerEnter(Collider col) {
		if (col.tag == "Food") {
			Destroy(col.gameObject);
			health.eat();
		} else if (col.tag == "Water") {
			health.inWater = true;
		} else if (col.tag == "Flag") {
			canvasAnimator.SetTrigger("Won");
		}
	}
//
//	void OnTriggerExit(Collider col) {
//		if (col.tag == "Water") {
//			health.inWater = false;
//		}
//	}
}
