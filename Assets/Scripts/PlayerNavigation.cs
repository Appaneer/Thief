using UnityEngine;
using System.Collections;

public class PlayerNavigation : MonoBehaviour {

	public static NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		agent = this.GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		#if UNITY_ANDROID
		if(Input.touchCount == 1)
			agent.SetDestination (Camera.main.ScreenToWorldPoint(Input.GetTouch (0).position));
		#endif

		#if UNITY_EDITOR
		if(Input.GetMouseButton(0)){
			agent.SetDestination (Camera.main.ScreenToWorldPoint(Input.mousePosition));
	
		}
		#endif
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag.Equals("Enemy")){
			//TODO add knifing animation
			Destroy (other.gameObject);
		}
	}
}
