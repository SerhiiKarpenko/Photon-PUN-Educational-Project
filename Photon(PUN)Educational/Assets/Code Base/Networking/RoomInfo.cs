using Photon.Pun;
using UnityEngine;

namespace Code_Base.Networking
{
	public class RoomInfo : MonoBehaviourPunCallbacks
	{
		public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
		{
			Debug.LogFormat("OnPlayerEnteredRoom() {0}", newPlayer.NickName);

			if (PhotonNetwork.IsMasterClient)
			{
				Debug.LogFormat("OnPlayerEnteredRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient);
				
				LoadArena();
			}
		}

		public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
		{
			Debug.LogFormat("OnPlayerLeftRoom {0}", otherPlayer.NickName);
			
			if (PhotonNetwork.IsMasterClient)
			{
				Debug.LogFormat("OnPlayerLetfRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient);
				
				LoadArena();
			}
		}
		
		private void LoadArena()
		{
			if (!PhotonNetwork.IsMasterClient)
			{
				Debug.LogError("PhotonNetwork: Trying to lad a level but we are not the master Client(HOST)");
				return;
			}
			
			Debug.LogFormat("PhotonNetwork: loading level {0}", PhotonNetwork.CurrentRoom.PlayerCount);
			PhotonNetwork.LoadLevel("Room for " + PhotonNetwork.CurrentRoom.PlayerCount);
		}
	}
}