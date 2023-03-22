using Photon.Pun;
using UnityEngine;

namespace Code_Base.Player
{
	public class PlayerBeams : MonoBehaviourPunCallbacks, IPunObservable
	{
		[Tooltip("The Beams GameObject to control")]
		[SerializeField] private GameObject _beams;

		private bool _isFiring;

		private void Awake() => 
			CheckBeamsGameObjectNull();

		public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
		{
			if (stream.IsWriting)
			{
				stream.SendNext(_isFiring);
			}
			else
			{
				this._isFiring = (bool)stream.ReceiveNext();
			}
		}

		private void Update()
		{
			if (photonView.IsMine)
			{
				ProcessInputs();
			}

			if (!CheckBeamsGameObjectNull() && BeamsCanBeSetToActive())
			{
				_beams.SetActive(_isFiring);
			}
		}

		private void ProcessInputs()
		{
			if (Input.GetButtonDown("Fire1"))
			{
				if (!_isFiring)
				{
					_isFiring = true;
				}
			}
			if (Input.GetButtonUp("Fire1"))
			{
				if (_isFiring)
				{
					_isFiring = false;
				}
			}
		}

		private bool CheckBeamsGameObjectNull()
		{
			if (_beams == null)
			{
				Debug.LogError("<Color=Red><a>Missing</a></Color> Beams Reference.", this);
				return true;
			}

			return false;
		}

		private bool BeamsCanBeSetToActive() => 
			_isFiring != _beams.activeInHierarchy;
	}
}
