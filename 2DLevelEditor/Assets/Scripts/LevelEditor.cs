using UnityEngine;
using System.Collections.Generic;

public class LevelEditor : MonoBehaviour {
	public GameObject Stage;
	public GameObject[] Objects;
	
	private Tool _currentTool;
	private MoveTool _moveTool;
	private RemoveTool _removeTool;
	private Validator _validator;
	private Builder _builder;

	private Dictionary<GameObject, StageObject> objectCache;

	void Awake() {
		_moveTool = (MoveTool)ScriptableObject.CreateInstance(typeof(MoveTool));
		_removeTool = (RemoveTool)ScriptableObject.CreateInstance(typeof(RemoveTool));
		_currentTool = _moveTool;
		
		_validator = new LevelValidator();
		_builder = new ExampleBuilder();
		
		this.objectCache = new Dictionary<GameObject, StageObject>();
		foreach (GameObject g in this.Objects) {
			this.objectCache.Add(g, g.GetComponent<StageObject>());
		}
	}
	
	void OnGUI() {
		GUILayout.BeginArea(
			new Rect(10, 10, 60, 300) //12 max knappar atm
		);
		for (int i = 0; i < this.Objects.Length; i++) {
			bool keyPress = Event.current.Equals(Event.KeyboardEvent("Alpha" + (i + 1)));
			if (GUILayout.Button(objectCache[this.Objects[i]].name) || keyPress) {
				Vector2 objPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				GameObject g = Instantiate(this.Objects[i], objPos, Quaternion.identity) as GameObject;
				g.transform.SetParent(this.Stage.transform);
			}
		}
		GUILayout.EndArea();
	}
	
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			_currentTool.MouseDown();
		} else if (Input.GetMouseButtonUp(0)) {
			_currentTool.MouseUp();
		} else if (Input.GetMouseButton(0)) {
			_currentTool.MouseHold();
		}
		
		_currentTool.Update();
	}
	
	void Save() {
		
	}
	
	public void TestStage() {
		if (_validator.Validate()) {
			Application.LoadLevel("_play");
		}
	}
}
