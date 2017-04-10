using System;

namespace Com.PDev.PCG
{
	public class TurnManager
	{

		private PhotonPlayer turn_player;

		public TurnManager ()
		{
		}

		public void PassTurn(){

			turn_player = turn_player.GetNext();

		}

		public void SetTurn (PhotonPlayer player){

			this.turn_player = player;

		}
	}
}

