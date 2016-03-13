using UnityEngine;
using System.Collections;

public class EnemyNavigation : MonoBehaviour {

	public NavMeshAgent agent;
	public Transform[] waypoints;
	[Range (0,1)]
	public float distanceThreshold;
	[HideInInspector]
	public int index;//current index of the waypoints
	[HideInInspector]
	public static bool isPlayerSpotted;
	public SpriteRenderer warningIcon;

	// Use this for initialization
	void Start () {
		index = 0;
		isPlayerSpotted = false;
		agent.SetDestination (waypoints[index].position);
		warningIcon.enabled = false;
	}

	// Update is called once per frame
	void Update () {
		if (!isPlayerSpotted) {
			if (Vector3.Distance (transform.position, waypoints [index].position) <= distanceThreshold) {
				index++;
				if (index >= waypoints.Length)
					index = 0;

				agent.SetDestination (waypoints [index].position);
			}
		} 
		else {
			warningIcon.enabled = true;
			agent.Stop ();
		}

	}
}
