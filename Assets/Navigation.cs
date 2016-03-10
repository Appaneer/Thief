﻿using UnityEngine;
using System.Collections;

public class Navigation : MonoBehaviour {

	public GameObject target;
	public NavMeshAgent agent;
	private Vector3 fixedPos;

	// Update is called once per frame
	void Update () {
		#if UNITY_ANDROID
		if(Input.touchCount == 1){
			Vector3 pos = Camera.main.ScreenToWorldPoint(Input.GetTouch (0).position);
			agant.SetDestination (pos);
			target.transform.position = pos;
		}
		#endif

		#if UNITY_EDITOR
		if(Input.GetMouseButton(0))
		{
		Vector3 pos1 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		agent.SetDestination (pos1);
		target.transform.position = pos1;
		}
		#endif
	}
}