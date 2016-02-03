using UnityEngine;
using System.Collections;

public class CollectibleItem : MonoBehaviour {

	[SerializeField] private string itemName;

	void OnTriggerEnter(Collider other) {
		Managers.Invertory.AddItem (itemName);
		Destroy (gameObject);
	}

}
