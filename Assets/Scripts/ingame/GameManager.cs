using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

		#region Photon Messages

		public override void OnPhotonPlayerConnected( PhotonPlayer other ){

			Debug.Log ("OnPhotonPlayerConnected() " + other.NickName);

			if (PhotonNetwork.isMasterClient) {

				Debug.Log ("OnPhotonPlayerConnected is MasterClient " + PhotonNetwork.isMasterClient);

				LoadArena ();
			}

		}

		public override void OnPhotonPlayerDisconnected( PhotonPlayer other){

			Debug.Log ("OnPhotonPlayerDisconnected() " + other.NickName);

			if (PhotonNetwork.isMasterClient) {

				Debug.Log ("OnPhotonPlayerConnected is MasterClient " + PhotonNetwork.isMasterClient);

				LoadArena ();

			}

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

		private void LoadArena(){

			if (!PhotonNetwork.isMasterClient) {

				Debug.LogError ("PhotonNetwork : Load level failed - Not master Client");

			}

			string level_string = "game" + PhotonNetwork.room.PlayerCount + "p";

			Debug.Log("PhotonNetwork : Loading Level : " + level_string);
			PhotonNetwork.LoadLevel (level_string);


		}

		#endregion

		#region MonoBehaviour CallBacks

		// Use this for initialization
		void Start () {

			Instance = this;

			if (playerPrefab == null) {
				Debug.LogError("<Color=Red><a>Missing</a></Color> playerPrefab Reference (Game Manager)", this);
			} else {
				Debug.Log("Instantiating LocalPlayer from " + Application.loadedLevelName);

				// Spawn a character for the local player
				PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(0f,5f,0f), Quaternion.identity, 0);
			}
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		#endregion
	}
}
