using Photon.Pun;
using System;
using UnityEngine;

namespace Code_Base.Player
{
	public class ManagePlayerPositionWhenOutsideTheArena : MonoBehaviourPunCallbacks
	{
		private void Start()
		{
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
			if (!Physics.Raycast(transform.position, -Vector3.up, 5f))
			{
				transform.position = new Vector3(0f, 5f, 0f);
			}
		}
	}
}
