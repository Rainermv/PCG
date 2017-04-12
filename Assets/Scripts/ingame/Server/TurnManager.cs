using Com.PDev.PCG.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.PDev.PCG.Server
{
    struct PlayerTurnData
    {
        public PhotonPlayer photonPlayer;
        public int turn;
        public int phase;
    }

    class TurnManager
    {
        public int PhaseCount { get { return phases.Count; } }
        
        Dictionary<int, PlayerTurnData> players = new Dictionary<int, PlayerTurnData>();
        
        //List<PlayerData> players = new List<PlayerData>();
        List<TurnPhase> phases = new List<TurnPhase>();

        private PlayerTurnData currentPlayer;

        //public TurnManager(List<PlayerData> players)
        public TurnManager(PhotonPlayer[] photonPlayers, List<PhaseData> phaseData)
        {
            foreach (PhotonPlayer p in photonPlayers)
            {
                PlayerTurnData pturn = new PlayerTurnData();
                pturn.photonPlayer = p;
                pturn.turn = 0;
                pturn.phase = 0;

                //currentPlayer = pturn;

                players.Add(p.ID, pturn);
            }

            foreach (PhaseData phase in phaseData)
            {
                phases.Add(new TurnPhase(phase));
            }
        }

        public void NextPhase()
        {
            UnityEngine.Debug.Log("NEXT PHASE CALLED");
        }

        public void NewTurn()
        {

        }

    }
}
