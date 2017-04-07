using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Com.PDev.PCG {

	[RequireComponent (typeof(InputField))]
	public class PlayerNameInputField : MonoBehaviour {

		#region Private Var

		static string playerNamePrefKey = "PlayerName";

		#endregion

		#region MonoBehaviour Callbacks

		void Start(){

			string defaultName = "Primórdio";

			InputField _inputField = this.GetComponent<InputField> ();

			if (_inputField != null) {

				if (PlayerPrefs.HasKey (playerNamePrefKey)) {

					defaultName = PlayerPrefs.GetString (playerNamePrefKey);
					_inputField.text = defaultName;
				}

			}

			PhotonNetwork.playerName = defaultName;

		}

		#endregion 

		#region PUblic Methods

		public void SetPlayeName (string value){

			PhotonNetwork.playerName = value + " ";

			PlayerPrefs.SetString (playerNamePrefKey, value);

		}

		#endregion
	}
}
