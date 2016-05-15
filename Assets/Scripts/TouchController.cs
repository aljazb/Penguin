using UnityEngine;
using System.Collections;

public class TouchController : MonoBehaviour {

	public int maxRayDistance;
	Vector3 destination;
	Vector3 origin;
	float completion = 0f;
	public float walkSpeed;
	public float slideSpeed;
	public float slideDistance;
	public float cameraRotateSpeedWalk;
	public float cameraRotateSpeedSlide;
	float distance;
	float speedDeduction;
	public float offset;
	public float slowDownOffset;
	public float slowDownSpeed;
	public float penguinHeight;
	bool isWalking;
	public float minSwipeDistance;
	Vector2 beganPosition;
	Vector2 endedPosition;
	bool swipe;

	Vector2 direction;
	Vector3 slideEndPosition;
	Vector3 beganLocalPosition;

	void Start () {
		origin = transform.position;
		destination = transform.position;
	}

	void Update () {
		if (Input.touchCount > 0) {
			if (Input.GetTouch(0).phase == TouchPhase.Began) {
				beganPosition = Input.GetTouch(0).position;
			}
			if (Input.GetTouch(0).phase == TouchPhase.Ended) {
				endedPosition = Input.GetTouch(0).position;
				if (Vector2.Distance(beganPosition, endedPosition) > minSwipeDistance) {
					beganLocalPosition = transform.localPosition; 

					direction = endedPosition-beganPosition;
					direction.Normalize();
					direction *= slideDistance;

					slideEndPosition = beganLocalPosition + transform.forward*direction.y + transform.right*direction.x;

					swipe = true;
					isWalking = false;
				} else {
					Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
					RaycastHit hit;

					if (Physics.Raycast(ray, out hit, maxRayDistance)) {
						destination = hit.point;
					}
					origin = transform.position;
					completion = 0f;
					distance = Vector3.Distance(origin, destination);
					isWalking = true;
					swipe = false;
					speedDeduction = 0;
				}
			}
		}

		if (swipe) {
			transform.localPosition = Vector3.Lerp(transform.localPosition, slideEndPosition, Time.deltaTime*slideSpeed);

			Vector3 lookDirection = slideEndPosition-beganLocalPosition;
			lookDirection.Normalize();
			float step = cameraRotateSpeedSlide * Time.deltaTime * (Vector3.Angle(transform.forward, lookDirection)/30);
			Vector3 newDir = Vector3.RotateTowards(transform.forward, lookDirection, step, 0f);
			transform.rotation = Quaternion.LookRotation(newDir);
		}
		if (isWalking) {
			if (Vector3.Distance(destination, transform.position) < slowDownOffset) {
				speedDeduction += Time.deltaTime * slowDownSpeed;
			}
			if (Vector3.Distance(destination, transform.position) < offset || speedDeduction > walkSpeed/distance) {
				isWalking = false;
			}
			completion += walkSpeed/distance - speedDeduction;
			transform.position = Vector3.Lerp(origin, destination, completion);

			Vector3 targetDir = destination - transform.position;
			float step = cameraRotateSpeedWalk * Time.deltaTime;
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
