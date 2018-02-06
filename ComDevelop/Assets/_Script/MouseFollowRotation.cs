using UnityEngine;
using System.Collections;

public class MouseFollowRotation : MonoBehaviour {
	public Transform target;
	public float xSpeed = 200, ySpeed = 200, mSpeed = 10;
	public float yMinLimit = -50, yMaxLimit = 50;
	public float distance = 7, minDistance = 2, maxDistance = 30;

	//bool needDamping = false;
	public bool needDamping = true;
	float damping = 5.0f;

	public float x = 0.0f;
	public float y = 0.0f;

	public void SetTarget(GameObject go) {
		target = go.transform;
	}
	// Use this for initialization
	void Start() {
		//Vector3 angles = transform.eulerAngles;
		//x = angles.y;
		//y = angles.x;
		//print(angles.ToString());
	}

	// Update is called once per frame
	void LateUpdate() {
		//print("LateUpdate()");
		if (target) {
			//use the light button of mouse to rotate the camera
			if (Input.GetMouseButton(0)) {
				x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
				y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

				y = ClampAngle(y, yMinLimit, yMaxLimit);
			}
			//print("LateUpdate()");
			if (Input.GetMouseButton(2)) {
				print("if (Input.GetMouseButton(2)) {");
				x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
				y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

				y = ClampAngle(y, yMinLimit, yMaxLimit);
			}

			distance -= Input.GetAxis("Mouse ScrollWheel") * mSpeed;
			distance = Mathf.Clamp(distance, minDistance, maxDistance);

			Quaternion rotation = Quaternion.Euler(y, x, 0.0f);
			Vector3 disVector = new Vector3(0.0f, 0.0f, -distance);
			Vector3 position = rotation * disVector + target.position;
			//adjust the camera
			if (needDamping) {
				transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * damping);
				transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime * damping);
			}
			else {
				transform.rotation = rotation;
				transform.position = position;
			}
		}
	}

	static float ClampAngle(float angle, float min, float max) {
		if (angle < -360)
			angle += 360;
		if (angle > 360)
			angle -= 360;
		return Mathf.Clamp(angle, min, max);
	}
}