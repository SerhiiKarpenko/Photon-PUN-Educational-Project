using Code_Base.Networking;
using Photon.Pun;

namespace Code_Base.Player
{
	public class PlayerHealth : MonoBehaviourPunCallbacks, IPunObservable
	{
		public float Health = 1f;
		private bool _leaved = false;
		
		public void GetDamage(float amount)
		{
			if (!photonView.IsMine)
				return;
			
			Health -= amount;
			
			if (Health <= 0)
				Die();
		}

		private void Die()
		{
			if (_leaved) 
				return;
			
			LocalPlayerNetworkController.Instance.LeaveRoom();
			_leaved = true;
		}

		public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
		{
			if (stream.IsWriting)
			{
				stream.SendNext(Health);
			}
			else
			{
				this.Health = (float)stream.ReceiveNext();
			}
		}
	}
}
