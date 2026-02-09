using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {
	Vector3 recentMousePosition = new Vector3(0, 0, 0);
	public Transform lookTarget;
	Vector3 offset = new Vector3(0,1f,0);
	void Start()
	{
		transform.rotation = Quaternion.Euler(10, lookTarget.eulerAngles.y, lookTarget.eulerAngles.z);
	}

	// Update is called once per frame
	void Update () {
		
		if (lookTarget != null) {

			Vector3 lookPosition = lookTarget.position+offset;
			Vector3 relativePos = Quaternion.Euler(0,lookTarget.eulerAngles.y,0)*new Vector3(0f,1f,-2.8f);
			transform.position = lookPosition + relativePos;


			RaycastHit hitInfo;
			if (Physics.Linecast(lookPosition,transform.position,out hitInfo,1<<LayerMask.NameToLayer("ground")))
				transform.position = hitInfo.point;
			
			transform.rotation=Quaternion.Euler(transform.eulerAngles.x,lookTarget.eulerAngles.y, lookTarget.eulerAngles.z);
			transform.Rotate(-(Input.mousePosition.y - recentMousePosition.y) * 0.05f, 0, 0);
			recentMousePosition = Input.mousePosition;


		}
	}
}
