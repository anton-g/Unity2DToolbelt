using UnityEngine;

public class Snap : MonoBehaviour {
	void LateUpdate () {
		int snapSize = SettingManager.Instance.snapSize;
		float x = Mathf.Round(transform.position.x / snapSize) * snapSize;
		float y = Mathf.Round(transform.position.y / snapSize) * snapSize;
		
		int maxX = (int)SettingManager.Instance.stageSize.x - (int)gameObject.transform.localScale.x / 2;
		int maxY = (int)SettingManager.Instance.stageSize.y - (int)gameObject.transform.localScale.y / 2;
		int minX = (int)gameObject.transform.localScale.x / 2 + 1;
		int minY = (int)gameObject.transform.localScale.y / 2 + 1;
		
		x = Mathf.Clamp(x, minX, maxX);
		y = Mathf.Clamp(y, minY, maxY);
		
		transform.position = new Vector2(x, y);
	}
}