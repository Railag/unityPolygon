using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BasicUI : MonoBehaviour {

	void OnGUI() {
		int posX = 10;
		int posY = 10;
		int width = 100;
		int height = 30;
		int margin = 10;

		List<string> itemList = Managers.Invertory.GetItemList ();
		if (itemList.Count == 0) {
			GUI.Box (new Rect (posX, posY, width, height), "No items");
		}

		foreach (string item in itemList) {
			int count = Managers.Invertory.GetItemCount (item);

			Texture2D image = Resources.Load<Texture2D> ("Icons/" + item);
			GUI.Box (new Rect (posX, posY, width, height), new GUIContent ("(" + count + ")", image));
			posX += width + margin;
		}

		string equipped = Managers.Invertory.equippedItem;
		if (equipped != null) {
			posX = Screen.width - (width + margin);
			Texture2D image = Resources.Load<Texture2D> ("Icons/" + equipped);
			GUI.Box (new Rect (posX, posY, width, height), new GUIContent ("Equipped", image));
		}

		posX = 10;
		posY += height + margin;
		foreach (string item in itemList) {
			if (GUI.Button (new Rect (posX, posY, width, height), "Equip " + item)) {
				Managers.Invertory.EquipItem (item);
			}

			if (item == "health") {
				if (GUI.Button (new Rect (posX, posY + height + margin, width, height), "Use Health")) {
					Managers.Invertory.ConsumeItem ("health");
					Managers.Player.ChangeHealth (25);
				}
			}

			posX += width + margin;
		}


	}
}