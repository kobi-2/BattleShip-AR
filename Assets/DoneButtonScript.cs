using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoneButtonScript : MonoBehaviour {

	public GameObject tile0, tile1, tile2;

	private float divisor;
	private float xOffset, zOffset;


	//changed: added this
	[SerializeField]
	public GameObject battleShip;


	public void calculatePositionAndDisableButtonSet(){

		calculateTilePosition ();
		//calculateTilePosition (ShipOrientation.rowWise);
		disableButtonSet ();
	
	}


	public void calculateTilePosition() {
			


			//GameObject battleShip = GameObject.Find ("Battleship");

			ButtonControls buttonControls = this.gameObject.GetComponent<ButtonControls> ();
			
			

			//ButtonControls buttonControls = battleShip.GetComponent<ButtonControls> ();

			//set offset for x and z
			//if( (this.transform.rotation.eulerAngles.y > 88) && (this.transform.rotation.eulerAngles.y < 92) ) {
		if ( ( (int) this.transform.rotation.eulerAngles.y ) > 50) {
			//if (buttonControls.rowWise) { 
			//if(ShipOrientation.Instance.rowWise){
			//if(ShipOrientation.rowWise){
				xOffset = 5f;
				zOffset = 0f;
			} else {

				//xOffset = 0f;
				//zOffset = 5f;
				xOffset = 5f;
				zOffset = 0f;
			}
			divisor = 5f;

			//map   ship's position to -->   tile & row position
			int tilePos = (int)((this.transform.position.x - buttonControls.xMin + xOffset) / divisor);	//??//this.transform.position ??
			int rowPos = (int)((this.transform.position.z - buttonControls.zMin + zOffset) / divisor); 


			string tileName = "Tile";
			if (tilePos > 0)
				tileName = tileName + " (" + tilePos.ToString () + ")";

			string rowName = "Row";
			if (rowPos > 0)
				rowName = rowName + " (" + rowPos.ToString () + ")";


			//tile 0	//tile0.name
			GameObject row0 = GameObject.Find (rowName);
			tile0 = row0.transform.Find (tileName).gameObject;



			//if (buttonControls.rowWise){
			//if(ShipOrientation.Instance.rowWise) {
			//if(ShipOrientation.rowWise){
		if ( ( (int) this.transform.rotation.eulerAngles.y ) > 50) {

				//tile 1
				tilePos--;
				tileName = "Tile";
				if (tilePos > 0)
					tileName = tileName + " (" + tilePos.ToString () + ")";
				tile1 = row0.transform.Find (tileName).gameObject;

				//tile 2
				tilePos += 2;
				tileName = "Tile";
				if (tilePos > 0)
					tileName = tileName + " (" + tilePos.ToString () + ")";
				tile2 = row0.transform.Find (tileName).gameObject;


			} else {

				//tile 1
				rowPos--;
				rowName = "Row";
				if (rowPos > 0)
					rowName = rowName + " (" + rowPos.ToString () + ")";
				row0 = GameObject.Find (rowName);
				tile1 = row0.transform.Find (tileName).gameObject;

				//tile 2
				rowPos += 2;
				rowName = "Row";
				if (rowPos > 0)
					rowName = rowName + " (" + rowPos.ToString () + ")";
				row0 = GameObject.Find (rowName);
				tile2 = row0.transform.Find (tileName).gameObject;

			}
	
			//GameObject buttonSet = GameObject.Find ("ButtonSet");
			//buttonSet.SetActive (false);




			// GameObject grid = GameObject.Find ("Grid");
			// grid.GetComponent<TouchControls> ().enabled = true;
		}





	public void calculateTilePosition(bool rowFlag) {



		//GameObject battleShip = GameObject.Find ("Battleship");

		ButtonControls buttonControls = this.gameObject.GetComponent<ButtonControls> ();



		//ButtonControls buttonControls = battleShip.GetComponent<ButtonControls> ();

		//set offset for x and z
		//if( (this.transform.rotation.eulerAngles.y > 88) && (this.transform.rotation.eulerAngles.y < 92) ) {
		//if (buttonControls.rowWise) { 
		//if(ShipOrientation.Instance.rowWise){
		//if(ShipOrientation.rowWise)
		{if(rowFlag){
			xOffset = 5f;
			zOffset = 0f;
		} else {

			//xOffset = 0f;
			//zOffset = 5f;
			xOffset = 5f;
			zOffset = 0f;
		}
		divisor = 5f;

		//map   ship's position to -->   tile & row position
		int tilePos = (int)((this.transform.position.x - buttonControls.xMin + xOffset) / divisor);	//??//this.transform.position ??
		int rowPos = (int)((this.transform.position.z - buttonControls.zMin + zOffset) / divisor); 


		string tileName = "Tile";
		if (tilePos > 0)
			tileName = tileName + " (" + tilePos.ToString () + ")";

		string rowName = "Row";
		if (rowPos > 0)
			rowName = rowName + " (" + rowPos.ToString () + ")";


		//tile 0	//tile0.name
		GameObject row0 = GameObject.Find (rowName);
		tile0 = row0.transform.Find (tileName).gameObject;



		//if (buttonControls.rowWise){
		//if(ShipOrientation.Instance.rowWise) {
		//if(ShipOrientation.rowWise){
		if(rowFlag){

			//tile 1
			tilePos--;
			tileName = "Tile";
			if (tilePos > 0)
				tileName = tileName + " (" + tilePos.ToString () + ")";
			tile1 = row0.transform.Find (tileName).gameObject;

			//tile 2
			tilePos += 2;
			tileName = "Tile";
			if (tilePos > 0)
				tileName = tileName + " (" + tilePos.ToString () + ")";
			tile2 = row0.transform.Find (tileName).gameObject;


		} else {

			//tile 1
			rowPos--;
			rowName = "Row";
			if (rowPos > 0)
				rowName = rowName + " (" + rowPos.ToString () + ")";
			row0 = GameObject.Find (rowName);
			tile1 = row0.transform.Find (tileName).gameObject;

			//tile 2
			rowPos += 2;
			rowName = "Row";
			if (rowPos > 0)
				rowName = rowName + " (" + rowPos.ToString () + ")";
			row0 = GameObject.Find (rowName);
			tile2 = row0.transform.Find (tileName).gameObject;

		}

		//GameObject buttonSet = GameObject.Find ("ButtonSet");
		//buttonSet.SetActive (false);




		// GameObject grid = GameObject.Find ("Grid");
		// grid.GetComponent<TouchControls> ().enabled = true;
	}



}




	public void disableButtonSet(){

		GameObject[] buttonSet = GameObject.FindGameObjectsWithTag("ButtonSet");
		for (int i = 0; i < buttonSet.Length; i++) {
			buttonSet[i].SetActive (false);
		}

		/*
		Renderer[] obj = this.GetComponentsInChildren<MeshRenderer> ();
		for (int i = 0; i < obj.Length; i++) {
			obj [i].enabled = false;
		}
		GameObject.FindGameObjectWithTag ("Weapons").GetComponentInChildren<MeshRenderer> ().enabled = false;
		GameObject.FindGameObjectWithTag ("Collider").GetComponentInChildren<MeshRenderer> ().enabled = false;
		*/

		//this.GetComponent<Renderer> ().enabled = false;
	
	}


}