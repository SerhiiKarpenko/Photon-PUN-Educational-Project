using Photon.Pun;
using UnityEngine.SceneManagement;

namespace Code_Base.Networking
{
	public class LocalPlayerNetworkController : MonoBehaviourPunCallbacks
	{
		#region Singleton

		public static LocalPlayerNetworkController Instance;
		
		private void Start() => 
			Instance = this;

		#endregion
		
		public override void OnLeftRoom() => 
			SceneManager.LoadScene(0);

		public void LeaveRoom() =>
			PhotonNetwork.LeaveRoom();
	}
}
