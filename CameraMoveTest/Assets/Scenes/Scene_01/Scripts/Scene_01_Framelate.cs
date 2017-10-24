using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene_01_Framelate : MonoBehaviour {

	public Text text_frame;

	void Update(){
		string txt = Time.frameCount.ToString();
		text_frame.text = "Frame : " + txt;
	}
}
