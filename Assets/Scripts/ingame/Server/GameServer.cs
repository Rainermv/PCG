using System.Collections;
using System.Collections.Generic;
using UnityEngine; //TEMP

using Object = System.Object;

using Com.PDev.PCG.Data;
using Com.PDev.PCG.Actions;

namespace Com.PDev.PCG.Server
{
    public class GameServer
    {
        #region SINGLETON

        public static GameServer instance;

        public static GameServer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameServer();
                }
                return instance;
            }
        }

        #endregion

        Entity game;
        List<Action> actionBuffer = new List<Action>();

        ActionTriggerDictionary triggerDictionary = new ActionTriggerDictionary();

        TurnManager turn_manager = new TurnManager();

        // TEMP: using this to send RPC calls to the client
       // PhotonView masterConnection; 

        private GameServer()
        {
            Debug.Log("CREATING SERVER");
            //this.masterConnection = masterConnection;

            //PhotonNetwork.OnEventCall += this.OnEvent;

            game = new Entity();
            game.GameId = 0;
        }

        #region public methods

        public void TriggerAction(string actionTrigger, object[] parameters)
        {
            // BUSCA AÇÃO

            // CHECA CONDIÇÕES

            // BUSCA ALVOS

            // EXECUTA EFEITO

            string effect = actionTrigger; // temp

            ActionEffectsManager.Instance.RunEffect(effect, game, parameters);

        }

        public void EndPhase()
        {
            turn_manager.NextPhase();
        }


        #endregion






    }

}
