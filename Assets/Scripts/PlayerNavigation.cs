using UnityEngine;
using System.Collections;

public class PlayerNavigation : MonoBehaviour {

	public NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		#if UNITY_ANDROID
		if(Input.touchCount == 1){
			Vector3 pos = Camera.main.ScreenToWorldPoint(Input.GetTouch (0).position);
			agent.SetDestination (pos);
		}
		#endif

		#if UNITY_EDITOR

		if(Input.GetMouseButton(0))
		{
			Vector3 pos1 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			agent.SetDestination (pos1);
		}
		#endif
	}
}
