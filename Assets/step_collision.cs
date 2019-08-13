using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class step_collision : MonoBehaviour
{	
	public GameObject self;
	
	void Start()
	{
		//Debug.Log("WTF?! 134");
	}
	
	void OnCollisionEnter(Collision other) {
		Color green = new Color(72.0f / 255.0f, 249.0f / 255.0f, 78.0f / 255.0f, 1.0f);
		Color pink = new Color(245.0f / 255.0f, 69.0f / 255.0f, 192.0f / 255.0f, 1.0f);
		Color blue = new Color(39.0f / 255.0f, 166.0f / 255.0f, 250.0f / 255.0f, 1.0f);
		string self_tag = (self != null) ? self.tag : "Unknown";
		Debug.Log(String.Format("Entering 'OnCollisionEnter': object {0} collided with collider: {1}", self_tag, other.collider.tag));
		
		List<string> trackers = new List<string>{
			"LeftLeg",
			"RightLeg"
		};
		List<string> board = new List<string>{
			// "topRight",	// pink
			"topMiddle", // green
			// "topLeft", // blue
			"middleRight", // blue
			"middle", // pink
			"middleLeft", // green
			// "bottomRight", // green
			"bottomMiddle", // blue
			// "bottomLeft" // pink
		};
		
		if (trackers.Contains(self_tag)) {
			// Debug.Log("collider: " + other.collider.tag + "\tGameObject: " + other.gameObject.tag);
			foreach (string s in board) {
				if (other.collider.CompareTag(string.Format("{0}_trig", s))) {
					Debug.Log(s);
					if (s.Contains("middle")) {
						GameObject.Find(s).GetComponent<Renderer>().material.color = blue;
					} else {
						GameObject.Find(s).GetComponent<Renderer>().material.color = pink;
					}
					self.GetComponent<Renderer>().enabled = false;
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
        if (other.collider.GetComponent<Collider>().CompareTag("topRight_trig")) {
				Debug.Log("Leaving topRight");
				GameObject.Find("topRight").GetComponent<Renderer>().material.color = white;
		}
		if (other.collider.GetComponent<Collider>().CompareTag("topMiddle_trig")) {
			Debug.Log("Leaving topMiddle_trig");
			GameObject.Find("topMiddle").GetComponent<Renderer>().material.color = white;
		}
		if (other.collider.GetComponent<Collider>().CompareTag("topLeft_trig")) {
			Debug.Log("Leaving topLeft");
			GameObject.Find("topLeft").GetComponent<Renderer>().material.color = white;
		}
		
		if (other.collider.GetComponent<Collider>().CompareTag("middleRight_trig")) {
			Debug.Log("Leaving middleRight");
			GameObject.Find("middleRight").GetComponent<Renderer>().material.color = white;
		}
		if (other.collider.GetComponent<Collider>().CompareTag("middle_trig")) {
			Debug.Log("Leaving middle");
			GameObject.Find("middle").GetComponent<Renderer>().material.color = white;
		}
		if (other.collider.GetComponent<Collider>().CompareTag("middleLeft_trig")) {
			Debug.Log("Leaving middleLeft");
			GameObject.Find("middleLeft").GetComponent<Renderer>().material.color = white;
		}
		
		if (other.collider.GetComponent<Collider>().CompareTag("bottomRight_trig")) {
			Debug.Log("Leaving bottomRight");
			GameObject.Find("bottomRight").GetComponent<Renderer>().material.color = white;
		}
		if (other.collider.GetComponent<Collider>().CompareTag("bottomMiddle_trig")) {
			Debug.Log("Leaving bottomMiddle");
			GameObject.Find("bottomMiddle").GetComponent<Renderer>().material.color = white;
		}
		if (other.collider.GetComponent<Collider>().CompareTag("bottomLeft_trig")) {
			Debug.Log("Leaving bottomLeft");
			GameObject.Find("bottomLeft").GetComponent<Renderer>().material.color = white;
		}
    }
}
