using UnityEngine;
using System.Collections;

namespace Com.PDev.PCG {
	
	public class Launcher : Photon.PunBehaviour {

		#region Public Var

		public bool loadDebugRoom = false;

		[Tooltip("The UI Panel to let the user enter name, connect and play")]
		public GameObject controlPanel;

		[Tooltip("The UI Label to inform the user that the connection is in progress")]
		public GameObject progressLabel;


		/// <summary>
		/// The maximum number of players per room. When a room is full, it can't be joined by new players, and so new room will be created.
		/// </summary>   
		[Tooltip("The maximum number of players per room. When a room is full, it can't be joined by new players, and so new room will be created")]
		public byte MaxPlayersPerRoom = 4;

		// the PUN log level
		public PhotonLogLevel Loglevel = PhotonLogLevel.Informational;

		public string UserId;

		public string previousRoom;

		#endregion

		#region Private Var

		string previousRoomPlayerPrefKey = "PUN:PRC:PCG:PreviousRoom";


		/// <summary>
		/// Keep track of the asynchronous connection process 
		/// </summary>
		bool isConnecting;

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

		void Start(){

			SetProgressViewVisible (false);

		}
			
		#endregion

		#region Public Methods


		public void Connect(){

			isConnecting = true;

			SetProgressViewVisible (true);

			if (PhotonNetwork.connected) {

				PhotonNetwork.JoinRandomRoom();
			} else {
			
				PhotonNetwork.ConnectUsingSettings (_gameVersion);

			}
		}

		#endregion

		#region Private Methods

		private void SetProgressViewVisible(bool visible){

			progressLabel.SetActive (visible);
			controlPanel.SetActive (!visible);
		}

		#endregion

		#region Pun Behaviour Callbacks

		/*

		public override void OnConnectedToMaster()
		{
			// after connect 
			this.UserId = PhotonNetwork.player.UserId;
			////Debug.Log("UserID " + this.UserId);

			if (PlayerPrefs.HasKey(previousRoomPlayerPrefKey))
			{
				Debug.Log("getting previous room from prefs: ");
				this.previousRoom = PlayerPrefs.GetString(previousRoomPlayerPrefKey);
				PlayerPrefs.DeleteKey(previousRoomPlayerPrefKey); // we don't keep this, it was only for initial recovery
			}


			// after timeout: re-join "old" room (if one is known)
			if (!string.IsNullOrEmpty(this.previousRoom))
			{
				Debug.Log("ReJoining previous room: " + this.previousRoom);
				PhotonNetwork.ReJoinRoom(this.previousRoom);
				this.previousRoom = null;       // we only will try to re-join once. if this fails, we will get into a random/new room
			}
			else
			{
				// else: join a random room
				PhotonNetwork.JoinRandomRoom();
			}
		}

		public override void OnJoinedLobby()
		{
			OnConnectedToMaster(); // this way, it does not matter if we join a lobby or not
		}

		public override void OnPhotonRandomJoinFailed(object[] codeAndMsg)
		{
			Debug.Log("OnPhotonRandomJoinFailed");
			PhotonNetwork.CreateRoom(null, new RoomOptions() { MaxPlayers = MaxPlayersPerRoom, PlayerTtl = 20000 }, null);
		}

		public override void OnJoinedRoom()
		{
			Debug.Log("Joined room: " + PhotonNetwork.room.Name);
			this.previousRoom = PhotonNetwork.room.Name;
			PlayerPrefs.SetString(previousRoomPlayerPrefKey,this.previousRoom);

			if (PhotonNetwork.room.PlayerCount == MaxPlayersPerRoom) {

				//Debug.Log("We Load the 'game2p' scene");

				PhotonNetwork.LoadLevel ("game" + MaxPlayersPerRoom + "p");

			} else if (loadDebugRoom == true) {
			
				PhotonNetwork.LoadLevel ("gameTest");
			
			}

		}

		public override void OnPhotonJoinRoomFailed(object[] codeAndMsg)
		{
			Debug.Log("OnPhotonJoinRoomFailed");
			this.previousRoom = null;
			PlayerPrefs.DeleteKey(previousRoomPlayerPrefKey);
		}

		public override void OnConnectionFail(DisconnectCause cause)
		{
			Debug.Log("Disconnected due to: " + cause + ". this.previousRoom: " + this.previousRoom);
		}

		public override void OnPhotonPlayerActivityChanged(PhotonPlayer otherPlayer)
		{
			Debug.Log("OnPhotonPlayerActivityChanged() for "+otherPlayer.NickName+" IsInactive: "+otherPlayer.IsInactive);
		}

		public override void OnDisconnectedFromPhoton(){

			SetProgressViewVisible (false);

			Debug.LogWarning("PCG/Launcher: OnDisconnectedFromPhoton() was called by PUN");

		}
		*/

		public override void OnConnectedToMaster(){

			Debug.Log ("PCG/Launcher: OnConnectedToMaster() was called by PUN");

			if (isConnecting){
				PhotonNetwork.JoinRandomRoom ();
			}

		}

		public override void OnDisconnectedFromPhoton(){

			SetProgressViewVisible (false);

			Debug.LogWarning("PCG/Launcher: OnDisconnectedFromPhoton() was called by PUN");
		
		}

		public override void OnPhotonRandomJoinFailed( object[] codeAndMsg){

			Debug.Log("DemoAnimator/Launcher:OnPhotonRandomJoinFailed() was called by PUN. No random room available, so we create one.\nCalling: PhotonNetwork.CreateRoom(null, new RoomOptions() {maxPlayers = 4}, null);");

			PhotonNetwork.CreateRoom (null, new RoomOptions () { MaxPlayers = MaxPlayersPerRoom }, null);
		}

		public override void OnJoinedRoom()
		{
			Debug.Log("DemoAnimator/Launcher: OnJoinedRoom() called by PUN. Now this client is in a room.");

			// #Critical Only load the game when the room is full
			if (PhotonNetwork.room.PlayerCount == MaxPlayersPerRoom) {

				//Debug.Log("We Load the 'game2p' scene");

				PhotonNetwork.LoadLevel ("game" + MaxPlayersPerRoom + "p");

			} else if (loadDebugRoom == true) {

				PhotonNetwork.LoadLevel ("gameTest");

			}
				
		}



		#endregion

	}
}
