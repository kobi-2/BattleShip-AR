using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoneButtonScript : MonoBehaviour {

	public GameObject tile0, tile1, tile2;

	private float divisor;
	private float xOffset, zOffset;

	public ButtonControls buttonControls;



	public void calculateTilePosition() {

		GameObject battleShip = GameObject.Find ("Battleship");

		buttonControls = battleShip.GetComponent<ButtonControls> ();

		//set offset for x and z
		if (buttonControls.rowWise) {
			xOffset = 5f;
			zOffset = 0f;
		} else {
			xOffset = 0f;
			zOffset = 5f;
		}
		divisor = 5f;

		//map   ship's position to -->   tile & row position
		int tilePos = (int) ((this.transform.position.x - buttonControls.xMin + xOffset) / divisor);	//??//this.transform.position ??
		int rowPos = (int) ((this.transform.position.z - buttonControls.zMin + zOffset) / divisor); 


		string tileName = "Tile";
		if (tilePos > 0)
			tileName = tileName + " (" + tilePos.ToString() + ")";

		string rowName = "Row";
		if (rowPos > 0)
			rowName = rowName + " (" + rowPos.ToString() + ")";


		//tile 0	//tile0.name
		GameObject row0 = GameObject.Find (rowName);
		tile0 = row0.transform.Find (tileName).gameObject;



		if (buttonControls.rowWise) {

			//tile 1
			tilePos--;
			tileName = "Tile";
			if (tilePos > 0)
				tileName = tileName + " (" + tilePos.ToString() + ")";
			tile1 = row0.transform.Find (tileName).gameObject;

			//tile 2
			tilePos += 2;
			tileName = "Tile";
			if (tilePos > 0)
				tileName = tileName + " (" + tilePos.ToString() + ")";
			tile2 = row0.transform.Find (tileName).gameObject;


		} else {

			//tile 1
			rowPos--;
			rowName = "Row";
			if (rowPos > 0)
				rowName = rowName + " (" + rowPos.ToString() + ")";
			row0 = GameObject.Find (rowName);
			tile1 = row0.transform.Find (tileName).gameObject;

			//tile 2
			rowPos += 2;
			rowName = "Row";
			if (rowPos > 0)
				rowName = rowName + " (" + rowPos.ToString() + ")";
			row0 = GameObject.Find (rowName);
			tile2 = row0.transform.Find (tileName).gameObject;

		}
	
		GameObject buttonSet = GameObject.Find ("ButtonSet");
		buttonSet.SetActive (false);

		// GameObject grid = GameObject.Find ("Grid");
		// grid.GetComponent<TouchControls> ().enabled = true;
	}
}
