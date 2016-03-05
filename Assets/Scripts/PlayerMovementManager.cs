using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovementManager : MonoBehaviour {

	public float speed;
	public GameObject player;
	private List<Vector2> path;
	private int currentNode;

	void Start(){
		currentNode = 0;
		path = new List<Vector2> ();
	}

	// Update is called once per frame
	void Update()
	{
		#if UNITY_EDITOR

		#endif

		#if UNITY_ANDROID
		if (Input.touchCount > 0) 
		{
			Vector2 temp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
			path.Add(temp);
		}
		else if(Input.touchCount == 0){
			StartCoroutine(followPath());
		}


		#endif
	}

	IEnumerator followPath(){
		if(path.Count > 0){
			for(int i = 0; i < path.Count-1; i++){
				Debug.DrawLine(path[i], path[i+1]);
			}
			//if (Vector2.Distance (transform.position, path [currentNode]) <= 1.0f) {
				while (currentNode < path.Count - 1) {
					Vector2 diff = (path [currentNode] - (Vector2)transform.position);
					float atan2 = Mathf.Atan2 (diff.y, diff.x);
					transform.rotation = Quaternion.Euler (0f, 0f, atan2 * Mathf.Rad2Deg);
					transform.position = Vector2.Lerp (transform.position, path [currentNode], speed);
					if (Vector2.Distance (transform.position, path [currentNode]) <= 0.2f) {
						currentNode++;
					}
					yield return new WaitForEndOfFrame ();
				}
			//} 
			//else {
			//	path = new List<Vector2> ();
			//	currentNode = 0;
			//}
		}
		if(currentNode >= path.Count - 1){
			path = new List<Vector2> ();
			currentNode = 0;
		}

	}



}
