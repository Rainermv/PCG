using System;
using System.Collections;
using Photon;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

using Com.PDev.PCG.Data;
using Com.PDev.PCG.Server;

namespace Com.PDev.PCG.Client
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
        PhotonView clientPhotonView;
        GameServer server;
        private ActionTriggerDictionary triggerDictionary = new ActionTriggerDictionary();

        #endregion

        #region public methods

        public void Init(PhotonView photon_view){

            clientPhotonView = photon_view;

            PhotonNetwork.OnEventCall += this.OnEvent;

            if (PhotonNetwork.player.IsMasterClient)
            {
                server = GameServer.instance;
               
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

        public void TriggerAction(string actionTrigger, object[] parameters = null)
        {
            clientPhotonView.RPC(actionTrigger, PhotonTargets.MasterClient, parameters);
            /*
            Debug.Log("SENDING EVENT TO SERVER: " + actionTrigger);
            byte evCode = 0;    // my event 0. could be used as "group units"

            ushort actionCode = triggerDictionary.GetCode(actionTrigger);

            byte[] content = BitConverter.GetBytes(actionCode);

            bool reliable = true;

            RaiseEventOptions options = new RaiseEventOptions();
            options.Receivers = ReceiverGroup.MasterClient; // TEMP: the master client is the server for now

            PhotonNetwork.RaiseEvent(evCode, content, reliable, options);
            */

        }

        

        private void OnEvent(byte eventcode, object content, int senderid)
        {
            if (eventcode == 1)
            {
                Debug.Log("CLIENT - RECEIVED EVENT FROM ID:" + senderid);
            }

        }

        #endregion

        [PunRPC]
        private void TriggerActionRPC(string actionTrigger, object[] parameters = null)
        {
            if (PhotonNetwork.player.IsMasterClient)
            {
                server.TriggerAction(actionTrigger, parameters);
            }
        }
    }
}

