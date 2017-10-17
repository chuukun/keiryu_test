using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PointChecker : MonoBehaviour {

	public List<string> startScenes;

	//初期設定、開始時のSceneを読み込む
	void Start(){
		foreach (string sceneName in startScenes) {
			SceneManager.LoadScene (sceneName, LoadSceneMode.Additive);
		}
	}


	//CheckPointの衝突判定
	void FixedUpdate(){
		Vector3 fwd = transform.TransformDirection (Vector3.forward);
		RaycastHit hit;
		if (Physics.Raycast (transform.position, fwd, out hit, 10f)) {
			if (hit.collider.tag == "CheckPoint") {
				LodingScene (hit.transform.gameObject);
			}
		}
	}

	//Sceneの読み込み判定
	void LodingScene(GameObject go){
		CheckPoint cp = go.GetComponent<CheckPoint>();
		if (!cp) {
			Debug.LogWarning ("Missing CheckPoint Script!!");
			Destroy (go);
			return;
		}

		//Sceneの読み込み(複数対応)
		foreach (CheckPoint.AddScene addScene in cp.addScenes) {
			string sceneName = addScene.sceneName;
			AddType addType = addScene.addType;

			switch (addType) {
			case AddType.AddScene:
				SceneManager.LoadSceneAsync (sceneName, LoadSceneMode.Additive);
				break;
			case AddType.DeleteScene:
				SceneManager.UnloadSceneAsync (sceneName);
				break;
			}
		}
		//チェックされたCheckPointは破棄する
		Destroy (go);
	}
}
