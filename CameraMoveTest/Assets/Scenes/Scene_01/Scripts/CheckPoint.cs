using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AddType{
	AddScene,
	DeleteScene
}

public class CheckPoint : MonoBehaviour {

	[System.Serializable]
	public class AddScene{
		public AddType addType;
		public string sceneName;
	}

	public List<AddScene> addScenes;

	void OnDrawGizmos(){
		Gizmos.color = new Color (1f, 0f, 0f, .5f);
		Gizmos.DrawSphere (transform.position,10f);
	}
}
