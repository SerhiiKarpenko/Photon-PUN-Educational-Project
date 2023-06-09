using Code_Base.Networking;
using UnityEngine;
using UnityEngine.UI;

namespace Code_Base.UI
{
	public class LauncherUIController : MonoBehaviour
	{
		[SerializeField] private Launcher _launcher;
		
		[SerializeField] private GameObject[] _gameObjectsToDisableOnLoading;
		
		[SerializeField] private GameObject _controlPanel;
		[SerializeField] private GameObject _progressLabel;
		[SerializeField] private Button _playButton;
		[SerializeField] private Button _exitGameButton;

		private void Start()
		{
			SubscribeOnEvents();
			
			SetActiveForProgressLabel(false);
			SetActiveForObjectsOnLoadingArray(true);
		}

		private void OnDestroy() => 
			UnsubscribeFromEvents();

		private void SubscribeOnEvents()
		{
			_launcher.OnConnectingStartedEvent += OnConnectingStarted;
			_launcher.OnDisconnectedEvent += OnDisconnected;
			_launcher.OnConnectedToRoomEvent += OnConnected;

			_playButton.onClick.AddListener(() => _launcher.Connect());
			_exitGameButton.onClick.AddListener(ExitGame);
		}

		private void UnsubscribeFromEvents()
		{
			_launcher.OnConnectingStartedEvent -= OnConnectingStarted;
			_launcher.OnDisconnectedEvent -= OnDisconnected;
			_launcher.OnConnectedToRoomEvent -= OnConnected;

			_playButton.onClick.RemoveListener(() => _launcher.Connect());
			_exitGameButton.onClick.RemoveListener(ExitGame);
		}

		private void OnDisconnected()
		{
			SetActiveForControlPanel(true);
			SetActiveForObjectsOnLoadingArray(true);
			SetActiveForProgressLabel(false);
		}

		private void OnConnectingStarted()
		{
			SetActiveForObjectsOnLoadingArray(false);
			SetActiveForProgressLabel(true);
		}

		private void SetActiveForObjectsOnLoadingArray(bool shouldBeActive)
		{
			foreach (GameObject gameObjectToDisable in _gameObjectsToDisableOnLoading)
				gameObjectToDisable.SetActive(shouldBeActive);
		}

		private void OnConnected() => 
			SetActiveForControlPanel(false);

		private void SetActiveForProgressLabel(bool shouldBeActive) => 
			_progressLabel.SetActive(shouldBeActive);
		
		private void SetActiveForControlPanel(bool shouldBeActive) => 
			_controlPanel.SetActive(shouldBeActive);

		private void ExitGame() =>
			Application.Quit();
	}
}
