using System;
using System.Collections;
using Photon;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

using UnityEngine.SceneManagement;

namespace Com.PDev.PCG{
	
	public class GameManager : Photon.PunBehaviour {

		#region Public Proprieties

		static public GameManager Instance;

		#endregion

		#region PUblic Variables

		[Tooltip("The prefab to use for representing the player")]
		public GameObject playerPrefab;

		#endregion

		private PunTurnManager turnManager;

		private PlayerData local_player;
		private RulesetData ruleset;

		public int player_number = 0;

		#region MonoBehaviour CallBacks

		// Use this for initialization
		void Start () {

			Instance = this;

			local_player = ServerConnection.Instance.getPlayerData (PhotonNetwork.player);
			ruleset = ServerConnection.Instance.getRulesetData ();



			/*
			if (playerPrefab == null) {
				Debug.LogError("<Color=Red><a>Missing</a></Color> playerPrefab Reference (Game Manager)", this);
			} else {
				//Debug.Log("Instantiating LocalPlayer from " + Application.loadedLevelName);

				// Spawn a character for the local player
				PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(0f,0f,0f), Quaternion.identity, 0);
			}
			*/

			this.StartTurn ();
		}

		// Update is called once per frame
		void Update () {

		}

		#endregion

		#region Photon Messages

		public override void OnPhotonPlayerConnected( PhotonPlayer other ){

			Debug.Log ("OnPhotonPlayerConnected() " + other.NickName);

		}

		public override void OnPhotonPlayerDisconnected( PhotonPlayer other){

			Debug.Log ("OnPhotonPlayerDisconnected() " + other.NickName);

		}

		/// <summary>
		/// Called when the local player left the room. We need to load the launcher scene.
		/// </summary>
		public override void OnLeftRoom(){

			SceneManager.LoadScene (0);

		}
			
		#endregion

		#region Public Methods

		public void LeaveRoom(){

			PhotonNetwork.LeaveRoom ();

		}

		#endregion

		#region Private Methods


		#endregion

		#region Core Gameplay Methods

		public void StartTurn(){

			ServerConnection.startTurn ();

		}

		public void EndTurn(){


		}
			
		#endregion

		#region RPCS

		[PunRPC]
		void instantiateEntity(Vector3 position, Entity entity, PhotonViewID id, PhotonPlayer player){



		}

		#endregion

	
	}
}
