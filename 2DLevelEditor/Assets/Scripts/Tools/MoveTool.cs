using UnityEngine;
using System.Collections;

public class MoveTool : Tool {
	
	GameObject selectedObject;
	
	public override void MouseDown() {
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit)) {
			selectedObject = hit.collider.gameObject;
		}
	}
	
	public override void MouseUp() {
		if (selectedObject != null)
			selectedObject = null;
	}
	
	public override void MouseHold() {
		if (selectedObject) {
			Vector3 objPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			objPos.z = 0.0f;
			selectedObject.transform.position = objPos;
		}
	}
	
	public override void Update() { }
}
