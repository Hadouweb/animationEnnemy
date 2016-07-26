using UnityEngine;
using System.Collections;

public class Navigation : MonoBehaviour {

	public Transform target;
	public AnimationEnnemy animationEnnemy;

	private NavMeshAgent agent;

	void Start() {
		agent = GetComponent<NavMeshAgent> ();
	}

	void Update() {
		agent.SetDestination (target.position);
		if (agent.destination != transform.position) {
			animationEnnemy.walk = true;
		} else {
			animationEnnemy.walk = false;
		}
	}

}
