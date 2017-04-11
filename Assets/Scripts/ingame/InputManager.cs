using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.PDev.PCG.Client {
	
	public class InputManager : Photon.PunBehaviour, IPunObservable {

		#region Public Proprieties

		[Tooltip("The local player instance")]
		public static GameObject LocalPlayerInstance;

		[Tooltip("The current Health of our player (TEMP)")]
		public int Health = 1;

		#endregion

		#region MonoBehaviour CallBacks

		void Awake(){

			if (photonView.isMine) {

				InputManager.LocalPlayerInstance = this.gameObject;

			}

		}

		void Update(){

			if (photonView.isMine == false && PhotonNetwork.connected == true) {

				return;
			}

			if (Health <= 0) {

				ClientManager.Instance.LeaveRoom ();
			}


			ProcessInputs ();

		}

		#endregion

		#region Private Methods

		private void ProcessInputs(){

			/*
			if (Input.GetButtonDown("Fire1")){

				InputLeftClick (Input.mousePosition);

			}
			*/

		}

		private void InputLeftClick(Vector2 position){

			Vector3 pos = Camera.main.ScreenToWorldPoint(position);
			pos.z = 0;
			transform.position = pos;

		}
			

		#endregion

		#region IPunObservable implementation

		public void OnPhotonSerializeView (PhotonStream stream, PhotonMessageInfo info)	{

			if (stream.isWriting) {

				// We on this player: send the others our data
				stream.SendNext (Health);
			} else {
				// Network player, receive data
				this.Health = (int)stream.ReceiveNext();
			}

		}

		#endregion
	}
}
