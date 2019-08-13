using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class step_collision : MonoBehaviour
{	
	public GameObject self;
	
	void OnCollisionEnter(Collision other) {
		Color green = new Color(72.0f / 255.0f, 249.0f / 255.0f, 78.0f / 255.0f, 1.0f);
		Color pink = new Color(245.0f / 255.0f, 69.0f / 255.0f, 192.0f / 255.0f, 1.0f);
		Color blue = new Color(39.0f / 255.0f, 166.0f / 255.0f, 250.0f / 255.0f, 1.0f);
		string self_tag = (self != null) ? self.tag : "Unknown";
		Debug.Log(String.Format("Entering 'OnCollisionEnter': object {0} collided with collider: {1}", self_tag, other.collider.tag));
		
		List<string> trackers = GameObject.Find("Camera").GetComponent<Globals>().trackers;
		List<string> board = GameObject.Find("Camera").GetComponent<Globals>().board;
		
		if (trackers.Contains(self_tag)) {
			// Debug.Log("collider: " + other.collider.tag + "\tGameObject: " + other.gameObject.tag);
			foreach (string s in board) {
				if (other.collider.name == (s + "_trig")) {
					if (s.Contains("middle")) {
						GameObject.Find(s).GetComponent<Renderer>().material.color = blue;
					} else {
						GameObject.Find(s).GetComponent<Renderer>().material.color = pink;
					}
					GameObject.Find("Camera").GetComponent<Globals>().flags[s] = Time.time;
				}
			}
		}
	}

    // Update is called once per frame
    void OnCollisionExit(Collision other)
    {
		string self_tag = (self != null) ? self.tag : "Unknown";
		self.GetComponent<Renderer>().enabled = true;
		Color white = new Color(1.0f, 1.0f, 1.0f, 1.0f);
		
		List<string> board = GameObject.Find("Camera").GetComponent<Globals>().board;
		
		foreach (string s in board) {
			if (other.collider.name == (s + "_trig")) {
				Debug.Log("Leaving " + s);
				GameObject.Find(s).GetComponent<Renderer>().material.color = white;
				GameObject.Find("Camera").GetComponent<Globals>().flags[s] = -1;
			}
		}
    }
}
