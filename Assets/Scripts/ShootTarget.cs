using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShootTarget : MonoBehaviour {

	public bool chooseTarget;
	public bool locked;
	public List<GameObject> targets;
	public Transform currentTarget;
	// Use this for initialization
	void Start () {
		chooseTarget = false;
		currentTarget = null;
		locked = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.C))
			chooseTarget = true;
		else
			chooseTarget = false;
		if (Input.GetKey (KeyCode.X))
			locked = false;
		if (locked) {
			Vector3 dir = currentTarget.position - transform.position; 
			float angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg; 
			Quaternion q = Quaternion.AngleAxis (angle, Vector3.forward); 
			transform.rotation = Quaternion.Slerp (transform.rotation, q, Time.deltaTime * 10);

		} else {
			Vector3 dir = GameObject.FindWithTag("LookPoint").transform.position - transform.position; 
			float angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg; 
			Quaternion q = Quaternion.AngleAxis (angle, Vector3.forward); 
			transform.rotation = Quaternion.Slerp (transform.rotation, q, Time.deltaTime * 10);
		}
			
		if (chooseTarget) {
			targets=GameObject.FindWithTag("Player").GetComponent<FieldOfView>().getTargets();
			if (Input.GetMouseButton (0)) {
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast (ray, out hit)) {
					for(int i=0; i<targets.Count; i++)
						if(targets[i].GetComponent<Collider>()==hit.collider)
							currentTarget = hit.transform;
				}
			}

			locked = true;
		}

	}

	public bool isLock()
	{
		return chooseTarget;
	}
}
