using System;
using System.Collections;
using Photon;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Com.PDev.PCG
{
	public class ServerConnection
	{
		#region public proprieties

		public static ServerConnection Instance {
			get {
				if (instance == null) {
					instance = new ServerConnection ();
				}
				return instance;
			}
		}

		#endregion

		#region private variables

		static public ServerConnection instance;

        PhotonView managerPhotonView;

        GameServer server;

		#endregion

		#region public methods

		public void Init(PhotonView photon_view){

            managerPhotonView = photon_view;

            PhotonNetwork.OnEventCall += this.OnEvent;

            if (PhotonNetwork.player.IsMasterClient)
            {
                server = new GameServer(photon_view);
                

            }

                //Hashtable proprieties = new Hashtable ();

                //proprieties.Add ("turn_number", "1");

                //PhotonNetwork.room.SetCustomProperties ();

        }

		public PlayerData getPlayerData(PhotonPlayer player){

			PlayerData pdata = new PlayerData ();
	
			return pdata;
		}
			
		public RulesetData getRulesetData(){

			RulesetData ruledata = new RulesetData ();

			return ruledata;
		}
			
		public void startTurn(){

		}

        public void SendEvent(int code)
        {
            Debug.Log("SENDING EVENT TO SERVER");
            byte evCode = 0;    // my event 0. could be used as "group units"
            byte[] content = new byte[] { 1, 2, 5, 10 };    // e.g. selected unity 1,2,5 and 10
            bool reliable = true;

            RaiseEventOptions options = new RaiseEventOptions();
            options.Receivers = ReceiverGroup.All;

            PhotonNetwork.RaiseEvent(evCode, content, reliable, options);

        }

        private void OnEvent(byte eventcode, object content, int senderid)
        {
            if (eventcode == 1)
            {
                Debug.Log("CLIENT - RECEIVED EVENT FROM ID:" + senderid);
            }

        }

        // SERVER - VALIDATE ACTION, UPDATE STATE, SAVE ON ACTION BUFFER
        internal void SendAction(string actionKey, object arg)
        {
            if (PhotonNetwork.player.IsMasterClient)
            {
                server.RunAction(actionKey, arg);

            }
        }

        #endregion
    }
}

