using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovementManager : MonoBehaviour {

	public float speed;
	public GameObject player;
	private List<Vector2> path;

	void Start(){
		path = new List<Vector2> ();
	}

	// Update is called once per frame
	void Update()
	{
		#if UNITY_EDITOR

		#endif

		#if UNITY_ANDROID

		if(Input.touchCount == 0){
			path = new List<Vector2> ();
		}
		else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) 
		{
			path.Add(Input.GetTouch(0).position);
		}

		if(path != null){
			for(int i = 0; i < path.Count-1; i++){
				Debug.DrawLine(path[i], path[i+1]);
			}
		}
		#endif
	}



}
