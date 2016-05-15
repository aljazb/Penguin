using UnityEngine;
using System.Collections;

public class CollideController : MonoBehaviour {

	public Health health;

	void Start () {
	
	}

	void OnTriggerEnter(Collider col) {
		if (col.tag == "Food") {
			Destroy(col.gameObject);
			health.eat();
		}
	}
}
