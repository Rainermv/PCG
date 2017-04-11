using System;
using System.Collections;
using Photon;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using Object = System.Object;

using Com.PDev.PCG.Data;

using UnityEngine.SceneManagement;

namespace Com.PDev.PCG.Client{
	
	public class ClientManager : Photon.PunBehaviour {

		#region Public Proprieties

		static public ClientManager Instance;

        public PhotonView photon_view;

		#endregion

		#region PUblic Variables

		[Tooltip("The prefab to use for representing the player")]
		public GameObject playerPrefab;

        #endregion

       
        private PlayerData local_player;
		private RulesetData ruleset;

		public int player_number = 0;

        #region MonoBehaviour CallBacks

        void Awake()
        {
           
        }

        // Use this for initialization
        void Start () {

            photon_view = this.GetComponent<PhotonView>();

            Instance = this;

			local_player = ServerConnection.Instance.getPlayerData (PhotonNetwork.player);
			ruleset = ServerConnection.Instance.getRulesetData ();

            ServerConnection.instance.Init(photon_view);

            this.TriggerAction("set_ready");

			/*
			if (playerPrefab == null) {
				Debug.LogError("<Color=Red><a>Missing</a></Color> playerPrefab Reference (Game Manager)", this);
			} else {
				//Debug.Log("Instantiating LocalPlayer from " + Application.loadedLevelName);

				// Spawn a character for the local player
				PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(0f,0f,0f), Quaternion.identity, 0);
			}
			*/
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

        public void TriggerAction(string action)
        {
            ServerConnection.instance.TriggerAction(action);
        }

        public void LeaveRoom(){

			PhotonNetwork.LeaveRoom ();

		}

        #endregion

        #region Private Methods


        #endregion

        #region events

       


        #endregion

        #region RPCs

        [PunRPC]
		void SendActionRPC(string actionKey, Object arg){

            //ServerConnection.instance.SendAction(actionKey, arg);

		}

        [PunRPC]
        void UpdateState(int gameId)
        {
           // Entity entity = ServerConnection.instance.GetState(gameId);

           // Debug.Log(entity.debug_value);

        }

        #endregion


    }
}
