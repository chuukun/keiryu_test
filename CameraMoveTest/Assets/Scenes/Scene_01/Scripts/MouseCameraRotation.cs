using UnityEngine;
using System.Collections;

public class MouseCameraRotation : MonoBehaviour {
	
	public float horizontalSpeed = 2.0F;
	public float verticalSpeed = 2.0F;
	private float axisX = 0f;
	private float axisY = 0f;

	void Update() {
		float h = horizontalSpeed * Input.GetAxis("Mouse X");
		float v = verticalSpeed * -Input.GetAxis("Mouse Y");
		axisY += h;
		axisX += v;
		Quaternion rot = Quaternion.AngleAxis (axisY, Vector3.up) * Quaternion.AngleAxis (axisX, Vector3.right);
		transform.localRotation = rot;
	}
}
