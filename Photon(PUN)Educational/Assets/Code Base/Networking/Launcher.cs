using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace Code_Base.Networking
{
	public class Launcher : MonoBehaviourPunCallbacks
	{
		[Tooltip("The maximum amount of players per room. When a room is full, it can't be joined by new players, and so new room will be created")]
		[SerializeField] private byte _maximumAmountOfPlayersPerRoom = 4;
		
		
		private readonly string _gameVersion = "1";

		private void Awake() => 
			PhotonNetwork.AutomaticallySyncScene = true;

		private void Start() => 
			Connect();

		private void Connect()
		{
			if (PhotonNetwork.IsConnected)
			{
				PhotonNetwork.JoinRandomRoom();
			}
			else
			{
				PhotonNetwork.ConnectUsingSettings();
				PhotonNetwork.GameVersion = _gameVersion;
			}
		}
		
		public override void OnConnectedToMaster()
		{
			Debug.Log("PUN Basics Tutorial/Launcher: OnConnectedToMaster was called by PUN");
			
			PhotonNetwork.JoinRandomRoom();
		}

		public override void OnJoinRandomFailed(short returnCode, string message)
		{
			Debug.Log("PUN Basics Tutorial/Launcher: OnJoinRandomFailed() was called by PUN. No random room available, so we create one. \nCalling: PhotonNetwork.CreateRoom");
			
			PhotonNetwork.CreateRoom(null, new RoomOptions
			{
				MaxPlayers = _maximumAmountOfPlayersPerRoom
			});
		}

		public override void OnJoinedRoom() => 
			Debug.Log("PUN Basics Tutorial/Launcher: OnJoinedRoom() called by PUN. Now this client is in a room");

		public override void OnDisconnected(DisconnectCause cause) => 
			Debug.LogWarningFormat("PUN Basics Tutorial/Launcher: OnDisconnected() was called by PUN with reason {0}", cause);
	}
}
