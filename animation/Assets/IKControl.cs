using UnityEngine;
using System;
using System.Collections;

[RequireComponent(typeof(Animator))] 

public class IKControl : MonoBehaviour {

	protected Animator animator;

	public bool ikActive = false;
	public Transform rightHandObj = null;
	public Transform lookObj = null;
	private float smooth = 0f;

	void Start () 
	{
		animator = GetComponent<Animator>();
	}

	//a callback for calculating IK
	void OnAnimatorIK()
	{
		if(animator) {

			//if the IK is active, set the position and rotation directly to the goal. 
			if(ikActive) {

				// Set the look target position, if one has been assigned
				if(lookObj != null) {
					animator.SetLookAtWeight(smooth	);
					animator.SetLookAtPosition(lookObj.position);
				}    

				smooth += Time.deltaTime * 0.1f;
				if (smooth > 1)
					smooth = 1;

				// Set the right hand target position and rotation, if one has been assigned
				if(rightHandObj != null) {
					animator.SetIKPositionWeight(AvatarIKGoal.RightHand,smooth);
					animator.SetIKRotationWeight(AvatarIKGoal.RightHand,smooth);  
					animator.SetIKPosition(AvatarIKGoal.RightHand,rightHandObj.position);
					animator.SetIKRotation(AvatarIKGoal.RightHand,rightHandObj.rotation);
				}        

			}

			//if the IK is not active, set the position and rotation of the hand and head back to the original position
			else {
				smooth += Time.deltaTime * 0.1f;
				if (smooth > 1)
					smooth = 1;
				animator.SetIKPositionWeight(AvatarIKGoal.RightHand,1 - smooth);
				animator.SetIKRotationWeight(AvatarIKGoal.RightHand,1 - smooth); 
				animator.SetLookAtWeight(smooth);
			}
		}
	}    
}
