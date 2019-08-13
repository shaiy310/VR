using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{
	public Dictionary<string, float> flags;
	public List<string> board;
	public List<string> trackers;
	int score;
	
    // Start is called before the first frame update
    void Start()
    {
		flags = new Dictionary<string, float>() {
			// {"topRight", -1},
			{"topMiddle", -1},
			// {"topLeft", -1},
			
			{"middleRight", -1},
			{"middleLeft", -1},
			
			// {"bottomRight", -1},
			{"bottomMiddle", -1},
			// {"bottomLeft", -1},
		};
		
		board = new List<string>{
			// "topRight",	// pink
			"topMiddle", // green
			// "topLeft", // blue
			
			"middleRight", // blue
			// "middle", // pink
			"middleLeft", // green
			
			// "bottomRight", // green
			"bottomMiddle", // blue
			// "bottomLeft" // pink
		};
		
		trackers = new List<string> {
			"LeftLeg",
			"RightLeg"
		};
		
		score = 0;
		GameObject.Find("middle").GetComponent<Renderer>().material.color = new Color(
			72.0f / 255.0f, 
			249.0f / 255.0f, 
			78.0f / 255.0f
		);
    }
	
	public List<string> Board {
		get { return board; }
	}
	
	public int Score {
		get { return score; }
	}
	
	public void UpdateScore(int delta) {
		score += delta;
		
		GameObject.Find("Score").GetComponent<TextMesh>().text = string.Format("Score: {0}", score);
	}
	
	void ClearScore() {
		UpdateScore(-score);
	}
}
