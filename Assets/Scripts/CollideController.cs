using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CollideController : MonoBehaviour {

	public Health health;

	void OnTriggerEnter(Collider col) {
		if (col.tag == "Food") {
			Destroy(col.gameObject);
			health.eat();
		} else if (col.tag == "Water") {
			health.inWater = true;
		}
	}

	void OnTriggerExit(Collider col) {
		if (col.tag == "Water") {
			health.inWater = false;
		}
	}
}
