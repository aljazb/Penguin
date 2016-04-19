using UnityEngine;
using System.Collections;

public class TouchController : MonoBehaviour {

	public int maxRayDistance;
	Vector3 destination;
	Vector3 origin;
	float completion = 0f;
	public float walkSpeed;
	public float cameraRotateSpeed;
	float distance;
	public float offset;
	public float penguinHeight;
	bool isWalking;

	void Start () {
		origin = transform.position;
		destination = transform.position;
	}

	void Update () {
		if (Input.touchCount > 0) {
			if (Input.GetTouch(0).phase == TouchPhase.Began) {
				Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
				RaycastHit hit;

				if (Physics.Raycast(ray, out hit, maxRayDistance)) {
					destination = hit.point;
				}
				origin = transform.position;
				completion = 0f;
				distance = Vector3.Distance(origin, destination);
				isWalking = true;
			}
		}

		if (isWalking) {
			if (Vector3.Distance(destination, transform.position) < offset) {
				isWalking = false;
			}
			completion += walkSpeed/distance;
			transform.position = Vector3.Lerp(origin, destination, completion);

			Vector3 targetDir = destination - transform.position;
			float step = cameraRotateSpeed * Time.deltaTime;
			Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0f);
			transform.rotation = Quaternion.LookRotation(newDir);
		}
	}

	void LateUpdate () {
		Vector3 newPos = transform.position; 
		newPos.y = Terrain.activeTerrain.SampleHeight(transform.position)+(penguinHeight/2);
		transform.position = newPos;
	}
}
