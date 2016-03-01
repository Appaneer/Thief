using UnityEngine;
using System.Collections;

public class PlayerMovementManager : MonoBehaviour {

	public float speed;

	private float fingerStartTime = 0.0f;
	private Vector2 fingerStartPos = Vector2.zero;
	private bool isSwiping = false;
	private float minSwipeDist = 50.0f;
	private float maxSwipeTime = 0.5f;

	// Update is called once per frame
	void Update()
	{
		#if UNITY_EDITOR
		if (Input.GetKeyUp(KeyCode.A))
		{
		}
		else if (Input.GetKeyUp(KeyCode.D))
		{
		}
		else if (Input.GetKeyUp(KeyCode.W))
		{
		}
		else if (Input.GetKeyUp(KeyCode.S))
		{
		}
		#endif

		#if UNITY_ANDROID
		if (Input.touchCount == 1)
		{
			foreach (Touch touch in Input.touches)
			{
				switch (touch.phase)
				{
				case TouchPhase.Began:// a new touch begins
					isSwiping = true;
					fingerStartTime = Time.time;
					fingerStartPos = touch.position;
					break;

				case TouchPhase.Canceled://the touch is cancelled
					isSwiping = false;
					break;

				case TouchPhase.Ended:// the touch is ended so now we can calculate the time and distance

					float gestureTime = Time.time - fingerStartTime;
					float gestureDist = (touch.position - fingerStartPos).magnitude;

					if (isSwiping && gestureTime < maxSwipeTime && gestureDist > minSwipeDist)
					{
						Vector2 direction = touch.position - fingerStartPos;
						Vector2 swipeType = Vector2.zero;

						if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
						{
							// the swipe is horizontal:
							swipeType = Vector2.right * Mathf.Sign(direction.x);
						}
						else {
							// the swipe is vertical:
							swipeType = Vector2.up * Mathf.Sign(direction.y);
						}

						if (swipeType.x != 0.0f)
						{
							if (swipeType.x > 0.0f)
							{
								//right
							}
							else {
								//left
							}
						}

						if (swipeType.y != 0.0f)
						{
							if (swipeType.y > 0.0f)
							{
								//up
							}
							else {
								//down
							}
						}

					}
					break;
				}
			}
		}
		else if(Input.touchCount == 2){
			Touch touchZero = Input.GetTouch(0);
			Touch touchOne = Input.GetTouch(1);

			Vector2 swipeType = Vector2.zero;

			if (Mathf.Abs(touchZero.deltaPosition.x) > Mathf.Abs(touchZero.deltaPosition.y) && Mathf.Abs(touchOne.deltaPosition.x) > Mathf.Abs(touchOne.deltaPosition.y))
			{
				// the swipe is horizontal:
				swipeType = Vector2.right * Mathf.Sign(touchZero.deltaPosition.x);
			}
			else {
				// the swipe is vertical:
				swipeType = Vector2.up * Mathf.Sign(touchZero.deltaPosition.y);
			}

			if (swipeType.x != 0.0f)
			{
				if (swipeType.x > 0.0f)
				{
					//right
				}
				else {
					//left
				}
			}

			if (swipeType.y != 0.0f)
			{
				if (swipeType.y > 0.0f)
				{
					//up
				}
				else {
					//down
				}
			}
		}


		#endif
	}

}
