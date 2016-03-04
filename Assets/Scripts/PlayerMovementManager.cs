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

		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) 
		{
			Vector2 temp = Input.GetTouch(0).deltaPosition;
			path.Add(temp);
			Debug.Log(temp);
			Instantiate(player, temp, Quaternion.identity);
		}

		#endif
	}

}
