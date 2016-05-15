using UnityEngine;
using System.Collections;

public class FoodObject : MonoBehaviour {

	public float lifetime;

	void Start () {
		Invoke("destroy", lifetime);
	}

	void destroy() {
		Destroy(gameObject);
	}
}
