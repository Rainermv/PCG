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

		TurnManager turn_manager = new TurnManager();

		#endregion

		#region public methods

		public void Init(){

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

		#endregion
	}
}

