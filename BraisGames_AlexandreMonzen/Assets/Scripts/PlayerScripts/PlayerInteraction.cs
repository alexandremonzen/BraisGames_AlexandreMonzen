using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerCharacter
{
    public sealed class PlayerInteraction : MonoBehaviour
    {
        private PlayerInputActions _playerInputActions;
        private bool _canInteract;

        private IInteractable _actualInteractable;

        [SerializeField] private Transform _carryOffset;

        [Header("Player Scripts")]
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private PlayerAnimation _playerAnimation;
        [SerializeField] private PlayerRotation _playerRotation;

        #region Getters & Setters
        public bool CanInteract { get => _canInteract; set => _canInteract = value; }
        public Transform CarryOffset { get => _carryOffset; }
        public PlayerAnimation PlayerAnimation { get => _playerAnimation; }
        public PlayerMovement PlayerMovement { get => _playerMovement; }
        #endregion

        private void Awake()
        {
            _playerInputActions = new PlayerInputActions();
            _canInteract = true;
        }

        private void OnEnable()
        {
            _playerInputActions.PlayerGeneralActionMap.Interact.Enable();
            _playerInputActions.PlayerGeneralActionMap.Interact.performed += PerformedInteraction;
        }

        private void OnDisable()
        {
            _playerInputActions.PlayerGeneralActionMap.Interact.performed -= PerformedInteraction;
            _playerInputActions.PlayerGeneralActionMap.Interact.Disable();
        }

        private void OnTriggerStay(Collider col)
        {
            if (_canInteract)
            {
                IInteractable _interactable = col.GetComponent<IInteractable>();
                if (_interactable != null)
                {
                    _actualInteractable = _interactable;
                }
            }
            else
            {
                //Debug.Log("Ja esta carregando algo!!!");
            }
        }

        private void OnTriggerExit(Collider col)
        {
            if (_canInteract)
            {
                IInteractable _interactable = col.GetComponent<IInteractable>();
                if (_interactable != null)
                {
                    _actualInteractable = null;
                }
            }
        }

        private void PerformedInteraction(InputAction.CallbackContext obj)
        {
            if (_actualInteractable != null)
            {
                _actualInteractable.Interact(this);
            }
            else
            {
                //Debug.Log("Nao existe item para interagir");
            }
        }

        public void SetActualInteractableNull()
        {
            _actualInteractable = null;
        }
    }
}
