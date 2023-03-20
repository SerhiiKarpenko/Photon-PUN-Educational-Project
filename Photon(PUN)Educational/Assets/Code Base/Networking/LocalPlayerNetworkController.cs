using Photon.Pun;
using UnityEngine.SceneManagement;

namespace Code_Base.Networking
{
	public class LocalPlayerNetworkController : MonoBehaviourPunCallbacks
	{
		public override void OnLeftRoom() => 
			SceneManager.LoadScene(0);

		public void LeaveRoom() =>
			PhotonNetwork.LeaveRoom();
	}
}
