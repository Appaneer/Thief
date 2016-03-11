using UnityEngine;
using System.Collections;

public class EnemyNavigation : MonoBehaviour {

	public static NavMeshAgent agent;
	public Transform[] waypoints;
	[Range (0,1)]
	public static float distanceThreshold;
	[HideInInspector]
	public int index;//current index of the waypoints
	private static Vector3 startingPos;

	// Use this for initialization
	void Start () {
		index = 0;
		agent = this.GetComponent<NavMeshAgent> ();
		distanceThreshold = 0.4f;
		startingPos = waypoints [index].position;
		agent.SetDestination (startingPos);
	}

	// Update is called once per frame
	void Update () {
		if(Vector3.Distance(transform.position, waypoints[index].position) <= distanceThreshold){
			index++;
			if(index >= waypoints.Length)
				index = 0;
			
			agent.SetDestination (waypoints[index].position);
		}
	}

	public static void OverriderTravelTo(Vector3 destination){
		agent.SetDestination (destination);
		distanceThreshold = 0.1f;
	}

	public static void resumePath(){
		distanceThreshold = 0.4f;
		agent.SetDestination (startingPos);
	}
}
