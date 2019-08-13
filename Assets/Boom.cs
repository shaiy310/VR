using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
	public GameObject self;
	
	void OnCollisionEnter(Collision other) {
		Dictionary<string, float> flags = GameObject.Find("Camera").GetComponent<Globals>().flags;
		List<string> board = GameObject.Find("Camera").GetComponent<Globals>().Board;
		List<string> trackers = GameObject.Find("Camera").GetComponent<Globals>().trackers;
		
		if (!other.collider.name.Contains("Const")) {
			if (flags[self.tag] > 0) {
				GameObject.Find("Camera").GetComponent<Globals>().UpdateScore(10);
				GameObject.Find("Const" + self.name.Replace("_trig", "")).GetComponent<Renderer>().material.color = new Color(1, 242.0f / 255.0f, 0);
			}
		}
		
	}
	
    void OnCollisionExit(Collision other) {
		if (!other.collider.name.Contains("Const")) {
			GameObject.Find("Const" + self.name.Replace("_trig", "")).GetComponent<Renderer>().material.color = new Color(1, 1, 1);
		}
	}
}
