using UnityEngine;
using System.Collections;

public class AnimationEnnemy : MonoBehaviour {

	public bool walk = false;

	private Animator animator;

	void Start() {
		animator = GetComponent<Animator> ();
	}

	void OnTriggerEnter(Collider col) {
		if (col.tag == "Player") {
			animator.SetBool ("HighKick", true);
		}
	}

	void OnTriggerStay(Collider col) {
		if (col.tag == "Player") {
			animator.SetBool ("HighKick", true);
		}
	}

	void OnTriggerExit(Collider col) {
		if (col.tag == "Player") {
			animator.SetBool ("HighKick", false);
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
