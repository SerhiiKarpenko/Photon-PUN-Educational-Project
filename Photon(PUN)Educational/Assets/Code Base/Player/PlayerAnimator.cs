using UnityEngine;

namespace Code_Base.Player
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimator : MonoBehaviour
    {
        private const string Speed = "Speed";
        private const string Direction = "Direction";

        [SerializeField] private float _directionDampTime = 0.25f;
        
        private Animator _animator;
        private float _horizontalAxis;
        private float _verticalAxis;
        
        private void Start() => 
            SetAnimator();

        private void Update()
        {
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

        private void SetSpeedFloat() => 
            _animator.SetFloat(Speed, Mathf.Abs(_horizontalAxis) + Mathf.Abs(_verticalAxis));
        
        private void SetDirectionFloat() => 
            _animator.SetFloat(Direction, _horizontalAxis, _directionDampTime, Time.deltaTime);
        

        private void SetAnimator() =>
            _animator = GetComponent<Animator>();
    }
}
