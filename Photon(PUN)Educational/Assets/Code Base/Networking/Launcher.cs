using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using System;

namespace Code_Base.Networking
{
	public class Launcher : MonoBehaviourPunCallbacks
	{
		public event Action OnConnectedToRoomEvent;
		public event Action OnConnectingStartedEvent;
		public event Action OnDisconnectedEvent;
		
		[Tooltip("The maximum amount of players per room. When a room is full, it can't be joined by new players, and so new room will be created")]
		[SerializeField] private byte _maximumAmountOfPlayersPerRoom = 4;
		
		private readonly string _gameVersion = "1";

		private bool _isConnecting = false;

		private void Awake() => 
			PhotonNetwork.AutomaticallySyncScene = true;
		
		public void Connect()
		{
			OnConnectingStartedEvent?.Invoke();
			
			if (PhotonNetwork.IsConnected)
			{
				PhotonNetwork.JoinRandomRoom();
			}
			else
			{
				_isConnecting = PhotonNetwork.ConnectUsingSettings();
				PhotonNetwork.GameVersion = _gameVersion;
			}
		}
		
		public override void OnConnectedToMaster()
		{
			Debug.Log("PUN Basics Tutorial/Launcher: OnConnectedToMaster was called by PUN");

			if (!_isConnecting) return;
			
			PhotonNetwork.JoinRandomRoom();
			//_isConnecting = false;
		}

		public override void OnJoinRandomFailed(short returnCode, string message)
		{
			Debug.Log("PUN Basics Tutorial/Launcher: OnJoinRandomFailed() was called by PUN. No random room available, so we create one. \nCalling: PhotonNetwork.CreateRoom");
			
			PhotonNetwork.CreateRoom(null, new RoomOptions
			{
				MaxPlayers = _maximumAmountOfPlayersPerRoom
			});
		}

		public override void OnJoinedRoom()
		{
			OnConnectedToRoomEvent?.Invoke();

			if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
			{
				Debug.Log("We LoadThe 'Room for 1' ");
				
				PhotonNetwork.LoadLevel("Room for 1");
			}
			
			Debug.Log("PUN Basics Tutorial/Launcher: OnJoinedRoom() called by PUN. Now this client is in a room");
		}

		public override void OnDisconnected(DisconnectCause cause)
		{
			Debug.LogWarningFormat("PUN Basics Tutorial/Launcher: OnDisconnected() was called by PUN with reason {0}",
				cause);
			
			OnDisconnectedEvent?.Invoke();

			//_isConnecting = false;
		}
	}
}
