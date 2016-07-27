using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

	public Animator animator;

	void allChildren(Transform t, bool v) {
		foreach (Transform child in t) {
			if (child.GetComponent<Rigidbody> () != null) {
				child.GetComponent<Rigidbody> ().isKinematic = v;
			}
			allChildren (child, v);
		}
	}

	void Start() {
		allChildren (animator.transform, true);
	}

	void OnCollisionEnter(Collision collision) {
		Debug.Log ("HIT");
		if (collision.collider.tag == "Fire") {
			StopAllCoroutines ();
			animator.enabled = false;
			allChildren (animator.transform, false);
			Debug.Log ("HIT");
		}
	}

	void OnCollisionStay(Collision collision) {
		if (collision.collider.tag == "Fire") {
			StopAllCoroutines ();
			animator.enabled = false;
			allChildren (animator.transform, false);
		}
	}

	IEnumerator SetAnimator(float time) {
		yield return new WaitForSeconds(time);
		animator.enabled = true;
		allChildren (animator.transform, true);
	}

	void OnCollisionExit(Collision collision) {
		if (collision.collider.tag == "Fire") {
			StopAllCoroutines ();
			//allChildren (animator.transform, true);
			StartCoroutine (SetAnimator (0.2f));
		}
	}

}
