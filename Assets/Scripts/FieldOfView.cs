using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FieldOfView : MonoBehaviour {

	public float viewRadius;
	[Range(0,180)]
	public float viewAngle;

	public LayerMask targetMask;
	public LayerMask obstacleMask;

	public List<Transform> visibleTargets;

	void Start(){
		StartCoroutine ("FindTargetWithDelay", 0.2f);
	}

	IEnumerator FindTargetWithDelay(float delayInSecond){
		while (true) {
			yield return new WaitForSeconds (delayInSecond);
			FindVisibleTarget ();
		}
	}

	void FindVisibleTarget(){
		visibleTargets = new List<Transform>();//init
		Collider[] targetsInViewRadius = Physics.OverlapSphere (transform.position, viewRadius, targetMask);

		foreach(Collider possibleTarget in targetsInViewRadius){
			Transform target = possibleTarget.transform;
			Vector3 dirToTarget = (target.position - transform.position).normalized;
			if (Vector3.Angle (transform.forward, dirToTarget) < viewAngle / 2) {
				float distToTarget = Vector3.Distance (transform.position, target.position);
				if (!Physics.Raycast (transform.position, dirToTarget, distToTarget, obstacleMask)) {
					visibleTargets.Add (target);
				}
			}
		}
	}

	public Vector3 DirFromAngle(float angleInDegree, bool isAngleGlobal){
		if (!isAngleGlobal) {
			angleInDegree += transform.eulerAngles.y;//if the angle is not global, convert it to global
		}
		return new  Vector3 (Mathf.Sin(angleInDegree * Mathf.Deg2Rad ), 0, Mathf.Cos(angleInDegree * Mathf.Deg2Rad));
	}
}
