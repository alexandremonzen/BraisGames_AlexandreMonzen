using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerCharacter
{
    public sealed class PlayerFootstep : MonoBehaviour
    {
        [Header("Wich Layers to Ignore?")]
        [SerializeField] private LayerMask _ignoreLayers;

        [Header("Layer Setup")]
        [Tooltip("Please select only one layer to each field")]
        [SerializeField] private LayerMask _dirtLayer;
        [SerializeField] private LayerMask _grassLayer;
        [SerializeField] private LayerMask _stoneLayer;

        [Header("Footstep Paths")]
        [SerializeField] private EventReference _dirtFootstep;
        [SerializeField] private EventReference _grassFootstep;
        [SerializeField] private EventReference _stoneFootstep;
        private EventReference _actualFootstep;

        [Header("Jump Paths")]
        [SerializeField] private EventReference _dirtJump;
        [SerializeField] private EventReference _grassJump;
        [SerializeField] private EventReference _stoneJump;
        private EventReference _actualJump;

        [Header("Jump Fall Paths")]
        [SerializeField] private EventReference _dirtJumpFall;
        [SerializeField] private EventReference _grassJumpFall;
        [SerializeField] private EventReference _stoneJumpFall;
        private EventReference _actualJumpFall;

        private int _dirtIntLayer;
        private int _grassIntLayer;
        private int _stoneIntLayer;
        private int _waterIntLayer;
        private int _woodIntLayer;

        private FMOD.Studio.EventInstance _footstepInstance;
        private FMOD.Studio.EventInstance _jumpInstance;
        private FMOD.Studio.EventInstance _jumpFallInstance;

        private PlayerMovement _playerMovement;

        private void Awake()
        {
            SetLayersNumber();

            _playerMovement = GetComponentInParent<PlayerMovement>();

            _actualFootstep = _stoneFootstep;
            _actualJump = _stoneJump;
            _actualJumpFall = _stoneJumpFall;

            _footstepInstance = FMODUnity.RuntimeManager.CreateInstance(_actualFootstep);
            _jumpInstance = FMODUnity.RuntimeManager.CreateInstance(_actualJump);
            _jumpFallInstance = FMODUnity.RuntimeManager.CreateInstance(_actualJumpFall);
        }

        private void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.layer == _dirtIntLayer)
            {
                _actualFootstep = _dirtFootstep;
                _actualJump = _dirtJump;
                _actualJumpFall = _dirtJumpFall;
            }
            else if (col.gameObject.layer == _grassIntLayer)
            {
                _actualFootstep = _grassFootstep;
                _actualJump = _grassJump;
                _actualJumpFall = _grassJumpFall;
            }
            else if (col.gameObject.layer == _stoneIntLayer)
            {
                _actualFootstep = _stoneFootstep;
                _actualJump = _stoneJump;
                _actualJumpFall = _stoneJumpFall;
            }
        }

        private void SetLayersNumber()
        {
            _dirtIntLayer = (int)Mathf.Log(_dirtLayer.value, 2);
            _grassIntLayer = (int)Mathf.Log(_grassLayer.value, 2);
            _stoneIntLayer = (int)Mathf.Log(_stoneLayer.value, 2);
        }

        public void PlayFootstep(AnimationEvent animationEvent) //called in animation keyframe
        {
            if (animationEvent.animatorClipInfo.weight > 0.25f)
            {
                _footstepInstance = FMODUnity.RuntimeManager.CreateInstance(_actualFootstep);
                _footstepInstance.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
                _footstepInstance.start();
                _footstepInstance.release();
            }
        }

        public void PlayJump()  //called in animation keyframe
        {
            _jumpInstance = FMODUnity.RuntimeManager.CreateInstance(_actualJump);
            _jumpInstance.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
            _jumpInstance.start();
            _jumpInstance.release();
        }

        public void PlayJumpFall()  //called in animation keyframe
        {
            _jumpFallInstance = FMODUnity.RuntimeManager.CreateInstance(_actualJumpFall);
            _jumpFallInstance.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
            _jumpFallInstance.start();
            _jumpFallInstance.release();
        }

    }
}