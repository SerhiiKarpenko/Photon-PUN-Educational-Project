using Photon.Pun;
using UnityEngine;

namespace Code_Base.Player
{
	public class PlayerCollisions : MonoBehaviourPunCallbacks
	{
		[SerializeField] private PlayerHealth _playerHealth;
		
		private void OnTriggerEnter(Collider other)
		{	
			if (!photonView.IsMine)
				return;
		
			if (!other.name.Contains("Beam"))
				return;
			
			_playerHealth.GetDamage(0.1f);
		}
		
		private void OnTriggerStay(Collider other)
		{
			if (!photonView.IsMine)
				return;
		
			if (!other.name.Contains("Beam"))
				return;
			
			_playerHealth.GetDamage(0.1f * Time.deltaTime);
		}
	}
}