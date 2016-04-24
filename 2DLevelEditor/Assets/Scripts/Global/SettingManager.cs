using UnityEngine;
using System.Collections;

public class SettingManager : MonoBehaviour {
	
	public int snapSize = 1;
    public Vector2 stageSize = new Vector2(70, 36);
	
	public static SettingManager Instance = null;

    void Awake() {
        if (Instance == null) {
            Instance = this;
        } else if (Instance != this) {
            Destroy(gameObject);
        }    
        DontDestroyOnLoad(gameObject);
    }
}
