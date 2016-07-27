using UnityEngine;
using System.Collections;

public class AnimationEnnemy : MonoBehaviour {

	public bool walk = false;

	public Animator animator;

	void OnTriggerEnter(Collider col) {
		if (col.tag == "Player") {
			animator.SetBool ("HighKick", true);
		}
		if (col.name == "Capsule") {
			animator.enabled = false;
		}
	}

	void OnTriggerStay(Collider col) {
		if (col.tag == "Player") {
			animator.SetBool ("HighKick", true);
		}
		if (col.name == "Capsule") {
			animator.enabled = false;
		}
	}

	void OnTriggerExit(Collider col) {
		if (col.tag == "Player") {
			animator.SetBool ("HighKick", false);
		}
		if (col.name == "Capsule") {
			animator.enabled = true;
		}
	}

	void Update() {

		if (walk) {
			animator.SetBool ("Walk", true);
		} else {
			animator.SetBool ("Walk", true);
		}

	}

}
