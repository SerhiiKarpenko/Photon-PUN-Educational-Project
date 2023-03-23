using Code_Base.Player;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code_Base.UI
{
    public class PlayerUI : MonoBehaviour
    {
        [Tooltip("UI Text to display Player's Name")]
        [SerializeField] private TextMeshProUGUI _playerNameText;

        [Tooltip("UI Slider to display Player's Health")]
        [SerializeField] private Slider _playerHealthSlider;

        [Tooltip("Pixel offset from the player target")]
        [SerializeField] private Vector3 _screenOffset = new Vector3(0f, 30f, 0f);

        private float _characterControllerHeight = 0f;
        private Transform _targetTransform;
        private Renderer _targetRenderer;
        private CanvasGroup _canvasGroup;
        private Vector3 _targetPosition;

        private PlayerHealth _target;

        private void Awake()
        {
            transform.SetParent(GameObject.Find("Canvas").GetComponent<Transform>(), false);
            _canvasGroup = GetComponent<CanvasGroup>();
        }
        
        private void Update()
        {
            if (_target == null)
            {
                Destroy(gameObject);
                return;
            }
            
            if (_playerHealthSlider != null)
            {
                _playerHealthSlider.value = _target.Health;
            }
        }

        private void LateUpdate()
        {
            if (_targetRenderer != null)
                _canvasGroup.alpha = _targetRenderer.isVisible ? 1f : 0f;

            if (_targetTransform != null)
            {
                _targetPosition = _targetTransform.position;
                _targetPosition.y += _characterControllerHeight;
                transform.position = Camera.main.WorldToScreenPoint(_targetPosition) + _screenOffset;
            }
        }

        public void SetTarget(PlayerHealth target)
        {
            if (target == null)
            {
                Debug.LogError("Missing, PlayerHealthMarker target for PlayerUI.SetTarget.", this);
                return;
            }

            _target = target;

            _targetTransform = _target.GetComponent<Transform>();
            _targetRenderer = _target.GetComponent<Renderer>();
            CharacterController characterController = target.GetComponent<CharacterController>();

            if (characterController != null)
                _characterControllerHeight = characterController.height;
            
            if (_playerNameText != null)
            {
                _playerNameText.text = _target.photonView.Owner.NickName;
            }
        }
        
    }
}
