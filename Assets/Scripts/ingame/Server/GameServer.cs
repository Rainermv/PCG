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

        private static GameServer instance;

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

        //Entity game;
        List<Action> actionBuffer = new List<Action>();

        ActionTriggerDictionary triggerDictionary = new ActionTriggerDictionary();

        GameManager gameManager;

        // TEMP: using this to send RPC calls to the client
       // PhotonView masterConnection; 

        private GameServer()
        {
            Debug.Log("CREATING SERVER");
            //this.masterConnection = masterConnection;

            //PhotonNetwork.OnEventCall += this.OnEvent;

            List<PhaseData> phaseData = PhaseData.GetPhases();

            gameManager = new GameManager(PhotonNetwork.playerList, phaseData);

            
        }

        #region public methods

        public void Update()
        {
            gameManager.Update();
        }

        public void TriggerAction(string actionTrigger, object[] parameters)
        {

            Action action = new Action(actionTrigger, parameters);
            action.Run();
            //Debug.Log("SERVER - Resolving action: " + actionTrigger);
            // BUSCA AÇÃO

            // CHECA CONDIÇÕES

            // BUSCA ALVOS

            // EXECUTA EFEITO

            //string effect = actionTrigger; // temp

            //ActionEffectsManager.Instance.RunEffect(effect, game, parameters);

        }

        public void InvokeEndPhase()
        {
            gameManager.NextPhase();
        }


        #endregion






    }

}
