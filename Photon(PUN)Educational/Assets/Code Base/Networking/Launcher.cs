using Photon.Pun;
using UnityEngine;

namespace Networking
{
	public class Launcher : MonoBehaviour
	{
		private string _gameVersion = "1";


		private void Awake()
		{
			PhotonNetwork.AutomaticallySyncScene = true;
		}
	}
}
