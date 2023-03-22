using Photon.Pun;
using UnityEngine;

namespace Code_Base.Player
{
	public class PlayerInstanceTracker : MonoBehaviourPunCallbacks
	{
		public static GameObject LocalPlayerInstance;

		private void Awake()
		{
			if (photonView.IsMine)
			{
				LocalPlayerInstance = gameObject;
			}
			
			DontDestroyOnLoad(gameObject);
		}
	}
}