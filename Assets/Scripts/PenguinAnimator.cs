using UnityEngine;
using System.Collections;

public class PenguinAnimator : MonoBehaviour {

	Animator anim;

	void Start() {
		anim = gameObject.GetComponent<Animator>();
	}

	public void Slide() {
		anim.SetTrigger("Slide");
	}

	public void Walk() {
		anim.SetTrigger("Walk");
	}

	public void StopWalk() {
		anim.SetTrigger("StopWalk");
		anim.ResetTrigger("Walk");
	}

}
