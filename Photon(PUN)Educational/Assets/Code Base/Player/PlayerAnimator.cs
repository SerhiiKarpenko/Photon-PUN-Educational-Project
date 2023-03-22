using Photon.Pun;
using UnityEngine;

namespace Code_Base.Player
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimator : MonoBehaviourPun
    {
        private const string Speed = "Speed";
        private const string Direction = "Direction";
        private const string Jump = "Jump";
        private const string BaseLayerRun = "Base Layer.Run";

        [SerializeField] private float _directionDampTime = 0.25f;
        
        private Animator _animator;
        private float _horizontalAxis;
        private float _verticalAxis;
        
        private void Start() => 
            SetAnimator();

        private void Update()
        {
            if (!photonView.IsMine && PhotonNetwork.IsConnected)
                return;
            
            Axis();
            SetSpeedFloat();
            SetDirectionFloat();
        }

        private void Axis()
        {
            _horizontalAxis = Input.GetAxis("Horizontal");
            _verticalAxis = Input.GetAxis("Vertical");

            if (_verticalAxis < 0)
                _verticalAxis = 0;
        }

        private void HandleJump()
        {
            AnimatorStateInfo stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
            
            if (!stateInfo.IsName(BaseLayerRun)) return;

            if (Input.GetButtonDown("Fire2"))
                SetJumpTrigger();
        }

        private void SetSpeedFloat() => 
            _animator.SetFloat(Speed, Mathf.Abs(_horizontalAxis) + Mathf.Abs(_verticalAxis));

        private void SetDirectionFloat() => 
            _animator.SetFloat(Direction, _horizontalAxis, _directionDampTime, Time.deltaTime);

        private void SetJumpTrigger() =>
            _animator.SetTrigger(Jump);

        private void SetAnimator() =>
            _animator = GetComponent<Animator>();
    }
}
