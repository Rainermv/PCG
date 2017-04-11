using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine; //TEMP

using Object = System.Object;

namespace Com.PDev.PCG
{
    public class GameServer
    {
        Entity game;
        List<Action> actionBuffer = new List<Action>();

        TurnManager turn_manager = new TurnManager();

        // TEMP: using this to send RPC calls to the client
        PhotonView masterConnection; 

        public GameServer(PhotonView masterConnection)
        {
            Debug.Log("CREATING SERVER");
            this.masterConnection = masterConnection;

            PhotonNetwork.OnEventCall += this.OnEvent;

            game = new Entity();
            game.GameId = 0;
        }

        void SendEvent(int code)
        {

            byte evCode = 1;    // my event 0. could be used as "group units"
            byte[] content = new byte[] { 1, 2, 5, 10 };    // e.g. selected unity 1,2,5 and 10
            bool reliable = true;
            RaiseEventOptions options = new RaiseEventOptions();
            options.Receivers = ReceiverGroup.All;

            PhotonNetwork.RaiseEvent(evCode, content, reliable, options);

        }

        private void OnEvent(byte eventcode, object content, int senderid)
        {
            
            if (eventcode == 0)
            {
                Debug.Log("SERVER - RECEIVED EVENT FROM ID:" + senderid + " responding");
                SendEvent(1);
            }

        }

        public void RunAction(string actionKey, object arg)
        {
            
            Action action = new Action(actionKey, arg);
            if (action.run(game))
            {
                actionBuffer.Add(action);
            }

            ConfirmActions();

        }

        private void ConfirmActions()
        {
            foreach (Action action in actionBuffer)
            {
               // masterConnection.RPC("local_action");
            }


        }




    }

}
