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
        Dictionary<int,Phase> phases = new Dictionary<int,Phase>();

        private PlayerTurnData currentPlayer;
        private Phase currentPhase;

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
                phases.Add(phase.order, new Phase(phase));

            }
        }

        public void NextPhase()
        {
            int phaseNumber = currentPlayer.phase++;
            
            if (phaseNumber > PhaseCount)
            {
                NextTurn();
            }

            phases.TryGetValue(phaseNumber, out currentPhase);

            if (currentPhase == null) {
                Logger.Log("Turn Manager ERROR", "missing phase " + phaseNumber);
            }
            
            UnityEngine.Debug.Log("Starting Phase");

            currentPhase.Run();
            
        }

        public void NextTurn()
        {

        }

    }
}
