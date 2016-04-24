using UnityEngine;
using System.Collections;

public abstract class Tool : ScriptableObject {

	public abstract void MouseDown();
	public abstract void MouseUp();
	public abstract void MouseHold();
	public abstract void Update();
	
}
