using UnityEngine;
using System.Collections;

public class DeviceTrigger : MonoBehaviour {

	[SerializeField] private GameObject[] targets;

	public bool requireKey;

	void OnTriggerEnter(Collider other) {
		if (requireKey && Managers.Invertory.equippedItem != "key") {
			return;
		}

		foreach(GameObject target in targets) {
			target.SendMessage ("Activate");
		}
	}

	void OnTriggerExit(Collider other) {
		foreach(GameObject target in targets) {
			target.SendMessage("Deactivate");
		}
	}

}
