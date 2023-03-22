using Photon.Pun;
using Photon.Pun.Demo.PunBasics;
using UnityEngine;

[RequireComponent(typeof(CameraWork))]
public class PlayerCamera : MonoBehaviourPun
{
	private CameraWork _cameraWork;
	
	private void Start()
	{
		_cameraWork = gameObject.GetComponent<CameraWork>();

		if (_cameraWork == null)
		{
			Debug.LogError("<Color=Red><a>Missing</a></Color> CameraWork Component on playerPrefab.", this);
			return;
		}

		if (photonView.IsMine)
		{
			_cameraWork.OnStartFollowing();
		}
	}
}
