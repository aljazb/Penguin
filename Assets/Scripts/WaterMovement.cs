using UnityEngine;
using System.Collections;

public class WaterMovement : MonoBehaviour {

	public float increaseSpeed;
	public float decreaseSpeed;
	float offset = 0.1f;
	bool start = false;

	public void StartIncrease() {
		start = true;
	}

	void Update () {
		if (start)
			transform.Translate(0, increaseSpeed * Time.deltaTime, 0);
	}

	public void decrease(float y) {
		StartCoroutine(decreaseCoroutine(transform.position, y));
	}

	IEnumerator decreaseCoroutine(Vector3 startPosition, float y) {
		while (transform.position.y > startPosition.y - y + offset) {
			transform.position = Vector3.Lerp(transform.position, startPosition + Vector3.down * y, Time.deltaTime * decreaseSpeed);
			yield return new WaitForEndOfFrame();
		}
	}
}
