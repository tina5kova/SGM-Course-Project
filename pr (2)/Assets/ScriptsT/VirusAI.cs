using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusAI : MonoBehaviour {

	public Transform[] patrolPoints;
	public float speed;
	Transform currentPatrolPoint;
	int currentPatrolIndex;

	void Start () {
		currentPatrolIndex = 0;
		currentPatrolPoint = patrolPoints[currentPatrolIndex];
	}

	void Update () {
		transform.Translate(Vector3.left * Time.deltaTime * speed);
		//Check to see if patrol point is reached
		if(Vector3.Distance(transform.position, currentPatrolPoint.position) < .1f) {
			//Patrol point reached - Get next patrol point
			//Check to see if there are anymore patrol points - if not go back to first point
			if(currentPatrolIndex + 1 < patrolPoints.Length) {
				currentPatrolIndex++;
			} else {
				currentPatrolIndex = 0;
			}
			currentPatrolPoint = patrolPoints[currentPatrolIndex];
		}

		//Turn to face the current patrol point;
		//Finding the direction Vector that vector points to the patrol pint
		Vector3 patrolPointDir = currentPatrolPoint.position - transform.position;

		//Figure out the rotation in degrees that we need to turn towards
		float angle = Mathf.Atan2(patrolPointDir.y, patrolPointDir.x) * Mathf.Rad2Deg - 90f;

		//Made the rotation that we need to face
		Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);

		//Apply the rotation to our transform
		transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180f);

	}
}
