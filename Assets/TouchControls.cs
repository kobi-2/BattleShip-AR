using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour {

	//public DoneButtonScript battleshipTiles;
	public PlayerGetInstance battleshipTiles;

	private GameObject tile;

	private Color originalColor;

	// Use this for initialization
	void Start () {
		//originalColor = GameObject.Find ("Tile").GetComponent<Renderer> ().material.color;

	}


	// Update is called once per frame
	void Update () {
		

		if (Input.GetMouseButtonDown (0)) {

			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				
				if (hit.transform.tag == "Tile") {

					tile = hit.transform.gameObject;

					performAttack ();

				}
			}
		}
	}


	public void performAttack(){

		//no need? this was old alternatives...
		//GameObject battleShip = GameObject.Find ("Battleship");
		//doneButton = battleShip.GetComponent<DoneButtonScript> ();

		battleshipTiles = this.GetComponentInParent<PlayerGetInstance>();

			

		//check if this is server...
		battleshipTiles.calculateIsServer ();


		// check if local player wins...
		if ((!battleshipTiles.thisIsServer) && (!battleshipTiles.isGameOver)) {

			if (battleshipTiles.localPlayerPoints >= 3 && battleshipTiles.serverPoints >=3) {
				
				battleshipTiles.isGameOver = true;
				battleshipTiles.isTied = true;
				battleshipTiles.CmdSendGameOver (battleshipTiles.isTied, battleshipTiles.serverWins, battleshipTiles.localPlayerWins);

			}else if(battleshipTiles.localPlayerPoints>=3){
				
				battleshipTiles.isGameOver = true;
				battleshipTiles.localPlayerWins = true;
				battleshipTiles.CmdSendGameOver (battleshipTiles.isTied, battleshipTiles.serverWins, battleshipTiles.localPlayerWins);

			}else if(battleshipTiles.serverPoints>=3){
				
				battleshipTiles.isGameOver = true;
				battleshipTiles.serverWins = true;
				battleshipTiles.CmdSendGameOver (battleshipTiles.isTied, battleshipTiles.serverWins, battleshipTiles.localPlayerWins);
			}

		}


		// perform attack, and change turn, and add points...
		//if( ( (battleshipTiles.thisIsServer && battleshipTiles.isServersTurn)  ||  ((!battleshipTiles.thisIsServer) && (!battleshipTiles.isServersTurn)) )  ){	
		if( (!battleshipTiles.isGameOver) && ( (battleshipTiles.thisIsServer && battleshipTiles.isServersTurn)  ||  ((!battleshipTiles.thisIsServer) && (!battleshipTiles.isServersTurn)) )  ){	
			
			if ((tile.name == battleshipTiles.remoteTile0.name) && (tile.transform.parent.name == battleshipTiles.remoteTile0.transform.parent.name )) {
				tile.GetComponent <Renderer> ().material.color = Color.red;
			} else if ((tile.name == battleshipTiles.remoteTile1.name) && (tile.transform.parent.name == battleshipTiles.remoteTile1.transform.parent.name )) {
				tile.GetComponent <Renderer> ().material.color = Color.red;
			} else if ((tile.name == battleshipTiles.remoteTile2.name) && (tile.transform.parent.name == battleshipTiles.remoteTile2.transform.parent.name )) {
				tile.GetComponent <Renderer> ().material.color = Color.red;
			} else {
				tile.GetComponent <Renderer> ().material.color = Color.green;
			}

			if ( (battleshipTiles.thisIsServer) && ( tile.GetComponent<Renderer>().material.color == Color.red) )  {
				battleshipTiles.serverPoints++;
			}else if ( (!battleshipTiles.thisIsServer) && ( tile.GetComponent<Renderer>().material.color == Color.red) )  {
				battleshipTiles.localPlayerPoints++;
			}
				
			battleshipTiles.isServersTurn = !battleshipTiles.isServersTurn;

			battleshipTiles.CmdSendUpdates (battleshipTiles.isServersTurn, battleshipTiles.serverPoints, battleshipTiles.localPlayerPoints);


		}


	

		// check if server player wins...
		if ((battleshipTiles.thisIsServer) && (!battleshipTiles.isGameOver)) {

			if (battleshipTiles.localPlayerPoints >= 3 && battleshipTiles.serverPoints >=3) {

				battleshipTiles.isGameOver = true;
				battleshipTiles.isTied = true;
				battleshipTiles.CmdSendGameOver (battleshipTiles.isTied, battleshipTiles.serverWins, battleshipTiles.localPlayerWins);

			}else if(battleshipTiles.localPlayerPoints>=3){

				battleshipTiles.isGameOver = true;
				battleshipTiles.localPlayerWins = true;
				battleshipTiles.CmdSendGameOver (battleshipTiles.isTied, battleshipTiles.serverWins, battleshipTiles.localPlayerWins);

			}else if(battleshipTiles.serverPoints>=3){

				battleshipTiles.isGameOver = true;
				battleshipTiles.serverWins = true;
				battleshipTiles.CmdSendGameOver (battleshipTiles.isTied, battleshipTiles.serverWins, battleshipTiles.localPlayerWins);
			}

		}




		/*
		if ((tile == doneButton.tile0) && (tile.transform.parent == doneButton.tile0.transform.parent)) {
			tile.GetComponent <Renderer> ().material.color = Color.green;
		} else if ((tile == doneButton.tile1) && (tile.transform.parent == doneButton.tile1.transform.parent)) {
			tile.GetComponent <Renderer> ().material.color = Color.green;
		} else if ((tile == doneButton.tile2) && (tile.transform.parent == doneButton.tile2.transform.parent)) {
			tile.GetComponent <Renderer> ().material.color = Color.green;
		} else {
			tile.GetComponent <Renderer> ().material.color = Color.red;
		}

		*/


		/*

		if ((tile.name == battleshipTiles.localTile0.name) && (tile.transform.parent.name == battleshipTiles.localTile0.transform.parent.name )) {
			tile.GetComponent <Renderer> ().material.color = Color.black;
		} else if ((tile.name == battleshipTiles.localTile1.name) && (tile.transform.parent.name == battleshipTiles.localTile1.transform.parent.name )) {
			tile.GetComponent <Renderer> ().material.color = Color.black;
		} else if ((tile.name == battleshipTiles.localTile2.name) && (tile.transform.parent.name == battleshipTiles.localTile2.transform.parent.name )) {
			tile.GetComponent <Renderer> ().material.color = Color.black;
		} else {
			tile.GetComponent <Renderer> ().material.color = Color.magenta;
		}

		*/











		/*
		//go back to previous one
		if ((tile.name == battleshipTiles.localTile0.name) && (tile.GetInstanceID() == battleshipTiles.localTile0.GetInstanceID() )) {
			tile.GetComponent <Renderer> ().material.color = Color.green;
		} else if ((tile.name == battleshipTiles.localTile1.name) && (tile.GetInstanceID() == battleshipTiles.localTile1.GetInstanceID() )) {
			tile.GetComponent <Renderer> ().material.color = Color.green;
		} else if ((tile.name == battleshipTiles.localTile2.name) && (tile.GetInstanceID() == battleshipTiles.localTile2.GetInstanceID() )) {
			tile.GetComponent <Renderer> ().material.color = Color.green;
		} else {
			tile.GetComponent <Renderer> ().material.color = Color.red;
		}
		*/

		/*
					 * different ways to find equality between gameobjects:
					 * 

					if(GameObject.ReferenceEquals(doneButton.tile0, tile))
						tile.GetComponent <Renderer> ().material.color = Color.grey;
					
					if(tile.GetInstanceID() == doneButton.tile1.GetInstanceID())
						tile.GetComponent <Renderer> ().material.color = Color.green;

					if(tile == doneButton.tile2)
						tile.GetComponent <Renderer> ().material.color = Color.blue;


					*/
		Debug.Log ("my log: touch controls: position: " + tile.transform.position);




	}



}
