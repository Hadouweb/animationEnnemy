using UnityEngine;
using System.Collections;

public class spawner : MonoBehaviour {

	public GameObject prefab;
	public float force = 20f;

	void Update() {
		if (Input.GetKeyDown (KeyCode.A) == true) {
			GameObject go = (GameObject)Instantiate (prefab, transform.position, transform.rotation);
			go.GetComponent<Rigidbody> ().AddForce (transform.forward * force, ForceMode.Impulse);
			Destroy (go, 2f);
		}
	}
}
