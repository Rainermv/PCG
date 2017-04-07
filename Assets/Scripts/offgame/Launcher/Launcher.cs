using UnityEngine;
using System.Collections;

namespace Com.PDev.PCG {
	
	public class Launcher : Photon.PunBehaviour {

		#region Public Var

		/// <summary>
		/// The maximum number of players per room. When a room is full, it can't be joined by new players, and so new room will be created.
		/// </summary>   
		[Tooltip("The maximum number of players per room. When a room is full, it can't be joined by new players, and so new room will be created")]
		public byte MaxPlayersPerRoom = 4;

		// the PUN log level
		public PhotonLogLevel Loglevel = PhotonLogLevel.Informational;


		#endregion

		#region Private Var

		/// <summary>
		/// This client's version number. 
		/// Users are separated from each other by gameversion (which allows you to make breaking changes).
		/// </summary>
		string _gameVersion = "1";

		#endregion

		#region MonoBehaviour CallBacks

		void Awake(){

			// #Critical
			// we don't join the lobby. There is no need to join a lobby to get the list of rooms.
			PhotonNetwork.autoJoinLobby = false;

			// #Critical
			// this makes sure we can use PhotonNetwork.LoadLevel() on the master client and all clients in the same room sync their level automatically
			PhotonNetwork.automaticallySyncScene = true;

			PhotonNetwork.logLevel = Loglevel;

		}
			
		#endregion

		#region Public Methods

		public void Connect(){

			if (PhotonNetwork.connected) {

				PhotonNetwork.JoinRandomRoom();
			} else {
			
				PhotonNetwork.ConnectUsingSettings (_gameVersion);

			}
		}

		#endregion

		#region Pun Behaviour Callbacks

		public override void OnConnectedToMaster(){

			Debug.Log ("DemoAnimator/Launcher: OnConnectedToMaster() was called by PUN");

			PhotonNetwork.JoinRandomRoom ();

		}

		public override void OnDisconnectedFromPhoton(){

			Debug.LogWarning("DemoAnimator/Launcher: OnDisconnectedFromPhoton() was called by PUN");
		
		}

		public override void OnPhotonRandomJoinFailed( object[] codeAndMsg){

			Debug.Log("DemoAnimator/Launcher:OnPhotonRandomJoinFailed() was called by PUN. No random room available, so we create one.\nCalling: PhotonNetwork.CreateRoom(null, new RoomOptions() {maxPlayers = 4}, null);");

			PhotonNetwork.CreateRoom (null, new RoomOptions () { MaxPlayers = MaxPlayersPerRoom }, null);
		}

		public override void OnJoinedRoom()
		{
			Debug.Log("DemoAnimator/Launcher: OnJoinedRoom() called by PUN. Now this client is in a room.");
		}



		#endregion

	}
}
