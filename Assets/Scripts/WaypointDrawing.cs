using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class WaypointDrawing : MonoBehaviour {
	public static List<WayPoints> wp=new List<WayPoints>();
	public static int index=0;
	private float timer = 0f;

	void Update () {

		timer += Time.deltaTime;
		if (Input.GetMouseButton (0)) {
			
			if (timer > 5f) {
				wp.Add(new WayPoints((int)Input.mousePosition.x,(int) Input.mousePosition.y, true));
				Debug.Log (wp [index].getX () + " " + wp [index].getY ()+" "+index);
				index++;
				timer -= 5f;
			}
		}
		else
			index = 0;
	}
	public class WayPoints
	{
		private int x;
		private int y;
		private bool active;
		public WayPoints(int x, int y, bool active)
		{
			this.x = x;
			this.y = y;
			this.active = active;
		}
		public int getX()
		{
			return x;
		}

		public int getY()
		{
			return y;
		}
		public bool getActive()
		{
			return active;
		}
	}
}

