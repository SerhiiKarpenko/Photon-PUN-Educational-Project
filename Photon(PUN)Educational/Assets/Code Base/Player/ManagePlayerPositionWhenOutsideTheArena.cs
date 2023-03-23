using Photon.Pun;
using UnityEngine;
using Code_Base.UI;


namespace Code_Base.Player
{
	public class ManagePlayerPositionWhenOutsideTheArena : MonoBehaviourPunCallbacks
	{
		public GameObject PlayerUIPrefab;
		private PlayerHealth _playerHealth;
		
		private void Start()
		{
			_playerHealth = GetComponent<PlayerHealth>();
			
#if UNITY_5_4_OR_NEWER
			UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
#endif
		}
		
#if UNITY_5_4_OR_NEWER
		public override void OnDisable()
		{
			base.OnDisable();
			UnityEngine.SceneManagement.SceneManager.sceneLoaded -= OnSceneLoaded;
		}
#endif
		
#if !UNITY_5_4_OR_NEWER
		private void OnLevelWasLoaded(int level)
		{
			this.CalledOnLevelWasLoaded(level);
		}
#endif
		

#if UNITY_5_4_OR_NEWER
		private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene,
			UnityEngine.SceneManagement.LoadSceneMode loadSceneMode)
		{
			this.CalledOnLevelWasLoaded(scene.buildIndex);
		} 
#endif

		private void CalledOnLevelWasLoaded(int level)
		{
			GameObject uiGameObject = Instantiate(PlayerUIPrefab);
			PlayerUI playerUI = uiGameObject.GetComponent<PlayerUI>();
			
			playerUI.SetTarget(_playerHealth);
			
			if (!Physics.Raycast(transform.position, -Vector3.up, 5f))
			{
				transform.position = new Vector3(0f, 5f, 0f);
			}
		}
	}
}
