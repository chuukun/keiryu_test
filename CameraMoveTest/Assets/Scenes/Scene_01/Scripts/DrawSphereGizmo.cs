using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawSphereGizmo : MonoBehaviour {

	public Color color = Color.red;
	public float radius = 5f;

	void OnDrawGizmos(){
		Gizmos.color = color;
		Gizmos.DrawSphere (transform.position,radius);
	}
}
