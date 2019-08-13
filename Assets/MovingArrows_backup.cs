using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingArrows_backup : MonoBehaviour
{
	public GameObject self;
	int count;
	enum Status {Hidden = 0, Visible=1, Target=2};
	int status;
    // Start is called before the first frame update
    void Start()
    {
		// Debug.Log("here1");
		//transform.Translate(Vector3.up);
        count = 0;
		status = (int)Status.Hidden;
    }

    // Update is called once per frame
    void Update()
    {
		// Transform transform = self.GetComponent<Transform>();
		Color green = new Color(72.0f / 255.0f, 249.0f / 255.0f, 78.0f / 255.0f, 1.0f);
		Color pink = new Color(245.0f / 255.0f, 69.0f / 255.0f, 192.0f / 255.0f, 1.0f);
		Color blue = new Color(39.0f / 255.0f, 166.0f / 255.0f, 250.0f / 255.0f, 1.0f);
		Debug.Log(string.Format("WTF1 {0}", self.tag));
		transform.Translate(0, 1f * Time.deltaTime, 0, Space.World);
		Debug.Log("WTF2");
		// ++count;
		if (count >= 3) {
			Debug.Log("WTF - count 3");
			transform.Translate(Vector3.forward);
			count = 0;
		}
		
		
		if (status == (int)Status.Hidden) {
			Debug.Log("WTF2");
			if (self.transform.position.y >= 0.3) {
				GetComponent<Renderer>().material.color = pink;
				status = (int)Status.Visible;
			}
		}
			
		if (status == (int)Status.Visible) {
			Debug.Log("WTF3");
			if (self.transform.position.y >= 1.5) {
				self.GetComponent<Renderer>().material.color = green;
				status = (int)Status.Target;
			}
		}
		
		

    }
}
