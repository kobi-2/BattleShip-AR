using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


public static class FlagClass {

	public static bool[] rowStatus { get; set; }

}



public class PlayerGetInstance : NetworkBehaviour {

	private GameObject[] pDB;
	public int serverPDB, localPDB;

	public DoneButtonScript doneButtonScript;
	public GameObject localTile0, localTile1, localTile2;
	public GameObject remoteTile0, remoteTile1, remoteTile2;

	public GameObject tile;
	public Color color;
	public bool hasColorValue;
	public string playerName;

	public bool isServersTurn, thisIsServer ;

	public bool isGameOver, serverWins, localPlayerWins, isTied;
	public int serverPoints, localPlayerPoints;

	void Start () {

		serverPDB = 0;
		localPDB = 0;
		pDB = GameObject.FindGameObjectsWithTag ("ParentDialogueButton");

		//Object[] objects = Object.FindObjectsOfType<GameObject.>;
		//GameObject ob = GameObject.FindGameObjectsWithTag;
		//this.GetInstanceID;

		hasColorValue = false;

		getTiles ();
		isServersTurn = false;

		isGameOver = false;

		serverWins = false;
		localPlayerWins = false;
		isTied = false;

		serverPoints = 0;
		localPlayerPoints = 0;


		/*
		RemotePlayer remotePlayer = new RemotePlayer();
		remotePlayer.playerInstanceID = this.GetInstanceID ();
		remotePlayer.remoteTiles [0] = localTile0;
		remotePlayer.remoteTiles [1] = localTile1;
		remotePlayer.remoteTiles [2] = localTile2;
		
		CmdSendTiles (remotePlayer);
		*/

	}


	
	void Update () {

		getTiles ();

		/*
		RemotePlayer remotePlayer = new RemotePlayer();
		remotePlayer.playerInstanceID = this.GetInstanceID ();
		remotePlayer.remoteTiles [0] = localTile0;
		remotePlayer.remoteTiles [1] = localTile1;
		remotePlayer.remoteTiles [2] = localTile2;

		CmdSendTiles (remotePlayer);
		*/

	}


	public void calculateIsServer(){
		if (isServer) {
			thisIsServer = true;
		}
	}


	void getTiles(){

		if (isLocalPlayer) {
			doneButtonScript = this.GetComponentInChildren<DoneButtonScript> ();

			localTile0 = doneButtonScript.tile0;
			localTile1 = doneButtonScript.tile1;
			localTile2 = doneButtonScript.tile2;
		}




		if (isServer) {

			thisIsServer = true;



			if (serverPDB<=0) {

				for (int i = 0; i < pDB.Length; i++) {
					pDB [i].SetActive (false);
				}
				
				serverPDB++;
			}
				

			GameObject[] gameObjects = GameObject.FindGameObjectsWithTag ("Battleship");
			gameObjects [0].GetComponent<Renderer> ().material.color = Color.red;
			//gameObjects [1].GetComponent<Renderer> ().material.color = Color.green;
			//gameObjects [1].GetComponentInChildren<MeshRenderer> ().enabled = false;
			//gameObjects [0].GetComponentInChildren<MeshRenderer> ().enabled = false;



			Renderer[] rObj = gameObjects[1].GetComponentsInChildren<MeshRenderer> ();
			for (int i = 0; i < rObj.Length; i++) {
				rObj [i].enabled = false;
			}

			gameObjects [0].GetComponentInChildren<MeshRenderer> ().enabled = true;


			DoneButtonScript dB = gameObjects [1].GetComponentInChildren<DoneButtonScript> ();// index 1 is the remote player for server
			dB.calculateTilePosition ();
			//dB.calculateTilePosition (FlagClass.rowStatus[0]);

			remoteTile0 = dB.tile0;
			remoteTile1 = dB.tile1;
			remoteTile2 = dB.tile2;


			//coloring the tile
			/*
			if((playerName.CompareTo("LocalPlayer")==0) && hasColorValue){
				//gameObjects[0].GetComponentsInChildren
				GameObject[] gObjs = GameObject.FindGameObjectsWithTag("Tile");
				for (int i = 0; i < gObjs.Length; i++) {
					if (gObjs[i].name == tile.name && gObjs[i].transform.parent.name == tile.transform.parent.name) {
						gObjs [i].GetComponent<Renderer> ().material.color = color;
					}
				}
			}
			*/

		}



		if (isLocalPlayer) {

			thisIsServer = false;
		


			if (localPDB<=0) {
				for (int i = 0; i < pDB.Length; i++) {
					pDB [i].SetActive (false);
				}

				localPDB++;
			}


			GameObject[] gameObjects = GameObject.FindGameObjectsWithTag ("Battleship");
			//gameObjects [0].GetComponent<Renderer> ().material.color = Color.blue;
			gameObjects [1].GetComponent<Renderer> ().material.color = Color.black;
			//gameObjects [0].GetComponentInChildren<MeshRenderer> ().enabled = false;
			//gameObjects [1].GetComponentInChildren<MeshRenderer> ().enabled = false;

			if (gameObjects.Length > 1) {
				Renderer[] obj = gameObjects [0].GetComponentsInChildren<MeshRenderer> ();
				for (int i = 0; i < obj.Length; i++) {
					obj [i].enabled = false;
				}
			}

			DoneButtonScript dB = gameObjects [0].GetComponentInChildren<DoneButtonScript> ();	// index 0 is the server
			dB.calculateTilePosition ();
			//FlagClass.rowStatus[gameObjects.Length-1] = ShipOrientation.rowWise;
			//dB.calculateTilePosition (FlagClass.rowStatus[gameObjects.Length-1]);

			remoteTile0 = dB.tile0;
			remoteTile1 = dB.tile1;
			remoteTile2 = dB.tile2;

			/*
			if( (playerName.CompareTo("ServerPlayer")==0) && hasColorValue){
				//gameObjects[0].GetComponentsInChildren
				GameObject[] gObjs = GameObject.FindGameObjectsWithTag("Tile");
				for (int i = 0; i < gObjs.Length; i++) {
					if (gObjs[i].name == tile.name && gObjs[i].transform.parent.name == tile.transform.parent.name) {
						gObjs [i].GetComponent<Renderer> ().material.color = color;
					}
				}
			}
			*/
				


		}



		/*
		for (int i = 0; i < gameObjects.Length; i++) {
			
			DoneButtonScript dB = gameObjects [i].GetComponent<DoneButtonScript> ();

			if ((localTile0 != dB.tile0) || (localTile1 != dB.tile1) || (localTile2 != dB.tile2)) {

				remoteTile0 = dB.tile0;
				remoteTile1 = dB.tile1;
				remoteTile2 = dB.tile2;

				break;
			}
		
		}
		*/



/*
		DoneButtonScript[] doneButtonScriptsArray = this.GetComponents<DoneButtonScript> ();	

		for(int i=0; i<doneButtonScriptsArray.Length; i++){
			
			if ((localTile0 != doneButtonScriptsArray [i].tile0) || (localTile1 != doneButtonScriptsArray [i].tile1) || (localTile2 != doneButtonScriptsArray [i].tile2)) {

				remoteTile0 = doneButtonScriptsArray[i].tile0;
				remoteTile1 = doneButtonScriptsArray[i].tile1;
				remoteTile2 = doneButtonScriptsArray[i].tile2;
				
				break;
			}
		
		}

*/

	}





	[Command]
	public void CmdSendTiles(RemotePlayer remotePlayer){
		RpcGetRemoteTiles (remotePlayer);
	}



	[ClientRpc]
	void RpcGetRemoteTiles (RemotePlayer remotePlayer){

		if (remotePlayer.playerInstanceID != this.GetInstanceID ()) {
		
			remoteTile0 = remotePlayer.remoteTiles [0];
			remoteTile1 = remotePlayer.remoteTiles [1];
			remoteTile2 = remotePlayer.remoteTiles [2];

		}
	
	}



	[Command]
	public void CmdSendUpdates(string m_playerName, GameObject m_tile, Color m_color, bool turnStatus, int m_serverPoints, int m_localPlayerPoints){
		RpcReceiveUpdate (m_playerName, m_tile, m_color, turnStatus, m_serverPoints, m_localPlayerPoints);
	}


	[ClientRpc]
	public void RpcReceiveUpdate(string m_playerName, GameObject m_tile, Color m_color, bool turnStatus,int m_serverPoints, int m_localPlayerPoints){
		isServersTurn = turnStatus;

		hasColorValue = true;
		playerName = m_playerName;
		tile = m_tile;
		color = m_color;

		serverPoints = m_serverPoints;
		bool hasScored = false;
		if (m_localPlayerPoints > localPlayerPoints) {
			hasScored = true;
		}
		localPlayerPoints = m_localPlayerPoints;

		showPointTurnMessage ();
	}


	public void showPointTurnMessage (){


		if (thisIsServer && isServersTurn) {
			for (int i = 0; i < pDB.Length; i++) {
				//GameObject.Find("DialogueButton").GetComponentInChildren<Text>().text = "la di da " ;
				//Button button = GameObject.Find("DialogueButton").GetComponent<Button>();

				pDB [i].SetActive (true);

				/*
				GameObject[] bObj = GameObject.FindGameObjectsWithTag ("dialogue");
				for (int j = 0; j < bObj.Length; j++) {
					//bObj[j].GetComponentInChildren<Text>().text = "la di da";
					bObj[j].GetComponent<Text>().text = "la di da";
				}
				*/

				GameObject[] tObj = GameObject.FindGameObjectsWithTag("TextDialogueButton");
				Text text;
				for (int j = 0; j < tObj.Length; j++) {
					text = tObj [j].GetComponentInChildren<Text> ();
					//text = GameObject.Find ("Text_DialogueButton").GetComponent<Text> ();
					text.text = "You: " + serverPoints + "   Opponent: " + localPlayerPoints + " \n YOUR TURN!";
				}

			}
		} else if (thisIsServer && !isServersTurn) {
			for (int i = 0; i < pDB.Length; i++) {
				pDB [i].SetActive (false);
			}
		}

		if (!thisIsServer && !isServersTurn) {
			for (int i = 0; i < pDB.Length; i++) {
				//GameObject.Find("DialogueButton").GetComponentInChildren<Text>().text = "la di da " ;
				//Button button = GameObject.Find("DialogueButton").GetComponent<Button>();

				pDB [i].SetActive (true);

				/*
				GameObject[] bObj = GameObject.FindGameObjectsWithTag ("dialogue");
				for (int j = 0; j < bObj.Length; j++) {
					//bObj[j].GetComponentInChildren<Text>().text = "la di da";
					bObj[j].GetComponent<Text>().text = "la di da";	
				}

				*/

				GameObject[] tObj = GameObject.FindGameObjectsWithTag("TextDialogueButton");
				Text text;
				for (int j = 0; j < tObj.Length; j++) {
					text = tObj [j].GetComponentInChildren<Text> ();
					//text = GameObject.Find ("Text_DialogueButton").GetComponent<Text> ();
					text.text = "You: " + localPlayerPoints + "   Opponent: " + serverPoints + " \n YOUR TURN!";
				}

			}
		} else if (!thisIsServer && isServersTurn) {
			for (int i = 0; i < pDB.Length; i++) {
				pDB [i].SetActive (false);
			}
		}

	}



	[Command]
	public void CmdSendGameOver(bool m_isTied, bool m_serverWins, bool m_localPlayerWins){
		RpcUpdateGameOver (m_isTied, m_serverWins, m_localPlayerWins);
	}


	[ClientRpc]
	public void RpcUpdateGameOver(bool m_isTied, bool m_serverWins, bool m_localPlayerWins){
		isGameOver = true;
		isTied = m_isTied;
		serverWins = m_serverWins;
		localPlayerWins = m_localPlayerWins;
		showGameOverMessage ();
	}

	void showGameOverMessage(){


		if (thisIsServer) {
			
			string result ="";
			if (isTied) {
				result = "Game Tied! You both suck!";
			}else if(serverWins){
				result = "You WON, But At What Cost!";
			}else if(localPlayerWins){
				result = "OOPSIE, GOT REKT! GGEZ!";
			}
			
			for (int i = 0; i < pDB.Length; i++) {
				pDB [i].SetActive (true);

				GameObject[] tObj = GameObject.FindGameObjectsWithTag("TextDialogueButton");
				Text text;
				for (int j = 0; j < tObj.Length; j++) {
					text = tObj [j].GetComponentInChildren<Text> ();
					//text = GameObject.Find ("Text_DialogueButton").GetComponent<Text> ();
					text.text = result;
				}

			}

		} 

		if (!thisIsServer) {

			string result ="";
			if (isTied) {
				result = "Game Tied! You both suck!";
			}else if(serverWins){
				result = "OOPSIE, GOT REKT! GGEZ!";
			}else if(localPlayerWins){
				result = "You WON, But At What Cost!";
			}
			
			for (int i = 0; i < pDB.Length; i++) {
				pDB [i].SetActive (true);

				GameObject[] tObj = GameObject.FindGameObjectsWithTag("TextDialogueButton");
				Text text;
				for (int j = 0; j < tObj.Length; j++) {
					text = tObj [j].GetComponentInChildren<Text> ();
					//text = GameObject.Find ("Text_DialogueButton").GetComponent<Text> ();
					text.text = result;
				}

			}

		}

	}



	[Command]
	public void CmdSendUpdateColor(bool m_hasColorValue, GameObject m_tile, Color m_color){
		RpcReceiveUpdateColor (m_hasColorValue, m_tile, m_color);
	}

	[ClientRpc]
	public void RpcReceiveUpdateColor(bool m_hasColorValue, GameObject m_tile, Color m_color){
		hasColorValue = m_hasColorValue;
		tile = m_tile;
		color = m_color;
	}





}




public class RemotePlayer {

	public int playerInstanceID;
	public GameObject[] remoteTiles;

}



