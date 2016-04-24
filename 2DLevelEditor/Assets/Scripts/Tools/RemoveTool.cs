using UnityEngine;
using System.Collections;

public class RemoveTool : Tool {
	public override void MouseDown() {
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit)) {
			Destroy(hit.collider.gameObject);
		}
	}
	
	public override void MouseUp() {
		
	}
	
	public override void MouseHold() {
		
	}
	
	public override void Update() {
		
	}
}
