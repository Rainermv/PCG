using Com.PDev.PCG.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.PDev.PCG.Server
{
    struct PlayerTurnData
    {
        public int id;
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
        public TurnManager(int[] playerIds, List<PhaseData> phaseData)
        {
            foreach (int id in playerIds)
            {
                PlayerTurnData player = new PlayerTurnData();
                player.id = id;
                player.turn = 0;
                player.phase = 0;

                players.Add(id, player);
            }

            foreach (PhaseData phase in phaseData)
            {
                phases.Add(new TurnPhase(phase));
            }

            currentPlayer = players[0];
        }


        public void AddPlayer(int id)
        {
            PlayerTurnData player = new PlayerTurnData();
            player.id = id;
            player.turn = 0;
            player.phase = 0;

            players.Add(id, player);
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
