using UnityEngine;
using System.Collections;

public class Animate : MonoBehaviour {

	public Animator anim;
	// Use this for initialization
    Vector2 current;
	Vector2 prev;
	void Start () {
		prev = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		current = transform.position;
		float change = (current - prev).magnitude / Time.deltaTime;
		anim.SetFloat("hSpeed",Mathf.Abs(change));
//		Debug.Log (change);
		prev = transform.position;
		if (Input.GetMouseButton (0))
			anim.SetBool ("shooting", true);
		else
			anim.SetBool ("shooting", false);
	}
}
