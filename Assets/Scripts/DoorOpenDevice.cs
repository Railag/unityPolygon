using UnityEngine;
using System.Collections;

public class DoorOpenDevice : MonoBehaviour {

	[SerializeField] private Vector3 dPos;

	private bool _open;

	private void Operate() {
		if (_open) {
			iTween.MoveBy (gameObject, dPos, 2);
		} else {
			iTween.MoveBy (gameObject, -dPos, 2);
		}

		_open = !_open; 
	}

	public void Activate() {
		if (!_open) {
			iTween.MoveBy (gameObject, -dPos, 2);
			_open = true;
		}
	}

	public void Deactivate() {
		if (_open) {
			iTween.MoveBy (gameObject, dPos, 2);
			_open = false;
		}
	}
}