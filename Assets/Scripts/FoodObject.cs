using UnityEngine;
using System.Collections;

public class FoodObject : MonoBehaviour {

	public float lifetime;

	void Start () {
		//Invoke("destroy", lifetime);
		if (transform.position.y < 17)
			Destroy(gameObject);
	}

	void destroy() {
		Destroy(gameObject);
	}
}
