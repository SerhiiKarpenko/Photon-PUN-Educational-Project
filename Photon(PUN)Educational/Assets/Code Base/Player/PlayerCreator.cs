using Photon.Pun;
using UnityEngine;

namespace Code_Base.Player
{
    public class PlayerCreator : MonoBehaviourPunCallbacks
    {
        public GameObject PlayerPrefab;

        private void Start()
        {
            if (PlayerPrefab == null)
            {
                Debug.LogError("Color=Red><a>Missing</a></Color> playerPrefab Reference. Please set it up in GameObject 'Game Manager'",this);
                return;
            }

            if (PlayerInstanceTracker.LocalPlayerInstance == null)
            {
                Debug.LogFormat("We are Instantiating LocalPlayer from {0}", Application.loadedLevelName);

                PhotonNetwork.Instantiate(this.PlayerPrefab.name, new Vector3(0f, 5f, 0f), Quaternion.identity);
                return;
            }
            
            Debug.LogFormat("Ignoring scene load for {0}", SceneManagerHelper.ActiveSceneName);
        }
    }
}
