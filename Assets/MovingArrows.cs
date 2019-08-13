using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class DynamicArrow {
	
	public string name;
	public GameObject arrow;
	public Vector3 start_position;
	public Vector3 move_direction;
	
	public DynamicArrow(string name, Vector3 move_direction) {
		this.name = name;
		this.arrow = GameObject.Find(name);
		// this.arrow.SetActive(false);
		this.start_position = this.arrow.GetComponent<Transform>().position;
		this.move_direction = move_direction;
	}
	
	public DynamicArrow(string name, 
						GameObject arrow, 
						Vector3 start_position,
						Vector3 move_direction) {
		this.name = name;
		this.arrow = arrow;
		// this.arrow.SetActive(false);
		this.start_position = start_position;
		this.move_direction = move_direction;
	}
	
	public GameObject Arrow { 
		get { return this.arrow; } 
	}
	
	~DynamicArrow() {
		GameObject.Destroy(this.arrow);
	}
}
	

public class MovingArrows : MonoBehaviour
{	
	List<DynamicArrow> arrow_templates;
	Color white = new Color(1, 1, 1);
	Color green = new Color(72.0f / 255.0f, 249.0f / 255.0f, 78.0f / 255.0f);
	Color pink = new Color(245.0f / 255.0f, 69.0f / 255.0f, 192.0f / 255.0f);
	Color blue = new Color(39.0f / 255.0f, 166.0f / 255.0f, 250.0f / 255.0f);
	
	// TBD - how to use
	int speed;
	
	List<DynamicArrow> dynamic_arrows;
	int counter;
	
    // Start is called before the first frame update
    void Start()
    {
		GameObject.Find("LeftLeg_Cube").GetComponent<Renderer>().material.color = new Color(1, 0, 0);
		GameObject.Find("RightLeg_Cube").GetComponent<Renderer>().material.color = new Color(1, 0, 0);
		arrow_templates = new List<DynamicArrow>{
			new DynamicArrow("ArrowLeft", Vector3.up),
			new DynamicArrow("ArrowDown", Vector3.right),
			new DynamicArrow("ArrowUp", Vector3.left),
			new DynamicArrow("ArrowRight", Vector3.up)
		};
		dynamic_arrows = new List<DynamicArrow>();
		speed = 150;
		counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
		if (counter <= 0) {
			int rnd = Random.Range(0, arrow_templates.Count);
			dynamic_arrows.Add(CreateCopy(arrow_templates[rnd]));
			counter = speed;
			//Debug.Log(string.Format("Created a new DA of index {0}", rnd));
		}
		// Debug.Log(string.Format("Current dynamic arrows: {0}", dynamic_arrows.Count));
		
		List<DynamicArrow> temp = new List<DynamicArrow>();
		// raise all arrows
		foreach (DynamicArrow da in dynamic_arrows) {
			Transform transform = da.arrow.GetComponent<Transform>();
			transform.Translate(da.move_direction * Time.deltaTime);
			
			if (transform.position.y >= 2.4) {
				temp.Add(da);
			}
		}
		
		// Remove arrow that reached the end of the path.
		foreach (DynamicArrow da in temp) {
			if (!dynamic_arrows.Remove(da)) {
				Debug.Log(string.Format("failed to remove {0}", da.name));
			}
			GameObject.Destroy(da.arrow);
		}
		
		counter -= 1;
    }
	
	DynamicArrow CreateCopy(DynamicArrow template) {
		GameObject go = Instantiate(template.Arrow, 
			template.Arrow.GetComponent<Transform>().position,
			template.Arrow.GetComponent<Transform>().rotation);
		DynamicArrow da = new DynamicArrow(template.name,
										   go,
										   template.start_position,
										   template.move_direction);
	    // da.arrow.SetActive(true);
		
		return da;
	}
}
