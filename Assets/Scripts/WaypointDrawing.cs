using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class WaypointDrawing : MonoBehaviour {
	public static int index=0;
	public static bool doneAdd=true;
	private List<Vector2> path;
	public static Vector2[] mouse;
	public float speed;
	public GameObject player;
	private int currentNode;
	public static bool enableMove;
	public static float mouseSpeed;
//	public static 	RaycastHit2D hit;
//	public static Vector2 startPos;
	void Start()
	{
		path = new List<Vector2> ();
		mouse = new Vector2[2];
	//	startPos = transform.position;
	}
	void Update () {

		//path [0] = startPos;
	//	hit = Physics2D.Raycast (path [0], Vector2.zero);
		if (Input.GetMouseButton (0)) {
			calculateMouseChange ();
			if (doneAdd)
				StartCoroutine ("Add");
		} 
		else
			StartCoroutine (followPath ());
		
		
		//	if (hit.collider.tag.Equals ("Player")) {
				for (int i = 0; i < path.Count - 1; i++) {
					Debug.DrawLine (path [i], path [i + 1]);
				}
	//	}
	}

	IEnumerator Add()
	{
		doneAdd = false;
		Vector2 temp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		path.Add(temp);
		yield return new WaitForSeconds (mouseSpeed);
		doneAdd = true;
	}

	IEnumerator calculateMouseChange()
	{
		mouse [0] = Input.mousePosition;
		yield return new WaitForSeconds (0.02f);
		mouse [1] = Input.mousePosition;
		float xSq = Mathf.Pow (mouse [0].x - mouse [1].x, 2);
		float ySq = Mathf.Pow (mouse [0].y - mouse [1].y, 2);
		mouseSpeed=0.05f/Mathf.Pow(xSq+ySq,0.2f);
	}

	IEnumerator followPath()
	{
		while (currentNode < path.Count - 1) {
			Vector2 diff = (path [currentNode] - (Vector2)transform.position);
			float atan2 = Mathf.Atan2 (diff.y, diff.x);
			transform.rotation = Quaternion.Euler (0f, 0f, atan2 * Mathf.Rad2Deg);
			transform.position = Vector2.Lerp (transform.position, path [currentNode],diff.sqrMagnitude/speed);
			if (Vector2.Distance (transform.position, path [currentNode]) <= 0.2f) {
				currentNode++;
			}
			if (Input.GetKey(KeyCode.D)) {
				path = new List<Vector2> ();
				break;
			}
			yield return new WaitForEndOfFrame ();
		}
	    
	if(currentNode >= path.Count - 1){
		path = new List<Vector2> ();
		currentNode = 0;
		//	startPos = transform.position;
	}


	}
}

