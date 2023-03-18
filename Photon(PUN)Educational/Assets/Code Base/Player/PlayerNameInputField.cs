using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code_Base.Player
{
	[RequireComponent(typeof(TMP_InputField))]
	public class PlayerNameInputField : MonoBehaviour
	{
		private const string PlayerNamePrefKey = "PlayerName";

		private void Start()
		{
			string defaultName = string.Empty;
			TMP_InputField inputField = GetComponent<TMP_InputField>();

			if (inputField == null)
			{
				Debug.LogError("Input field is null");
				return;
			}
			
			defaultName = PlayerPrefs.GetString(PlayerNamePrefKey, "Enter your nickname");
			inputField.text = defaultName;
			
			PhotonNetwork.NickName = defaultName;
		}

		public void SetPlayerName(string nameToSet)
		{
			if (string.IsNullOrEmpty(nameToSet))
			{
				Debug.LogError("Player name is null or empty");
				return;
			}

			PhotonNetwork.NickName = nameToSet;
			
			PlayerPrefs.SetString(PlayerNamePrefKey, nameToSet);
		}
	}
}
