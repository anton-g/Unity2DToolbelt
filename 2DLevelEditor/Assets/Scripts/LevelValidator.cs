using UnityEngine;
using System.Collections;

public class LevelValidator : Validator {

	public override bool Validate() {
		GameObject[] spawns = GameObject.FindGameObjectsWithTag("EditorSpawnPoint");
		return spawns.Length > 3;
	}
}
