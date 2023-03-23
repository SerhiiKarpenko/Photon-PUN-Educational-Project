using Code_Base.Networking;
using Photon.Pun;

namespace Code_Base.Player
{
	public class PlayerHealth : MonoBehaviourPunCallbacks, IPunObservable
	{
		public float Health = 1f;
		private bool _leaved = false;

		private void Update()
		{
			if (photonView.IsMine)
			{
				if (Health <= 0f)
					Die();
			}
		}

		public void GetDamage(float amount)
		{
			Health -= amount;
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