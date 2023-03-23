using Photon.Pun;
using Code_Base.UI;
using UnityEngine;

namespace Code_Base.Player
{
	public class PlayerUICreator : MonoBehaviourPunCallbacks
	{
		public GameObject PlayerUIPrefab;
		private PlayerHealth _playerHealth;
		
		private void Start()
		{
			if (PlayerUIPrefab == null)
			{
				Debug.LogWarning("Missing PlayerUIPrefab reference on player prefab", this);
				return;
			}

			_playerHealth = GetComponent<PlayerHealth>();
			
			GameObject uiGameObject = Instantiate(PlayerUIPrefab);
			PlayerUI playerUI = uiGameObject.GetComponent<PlayerUI>();
			
			playerUI.SetTarget(_playerHealth);
			
			//uiGameObject.SendMessage("SetTarget", this, SendMessageOptions.RequireReceiver);
		}
	}
}