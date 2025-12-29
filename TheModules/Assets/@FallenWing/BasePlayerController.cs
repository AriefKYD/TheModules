using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
namespace FallenWing.Module.PlayerController
{
    public class BasePlayerController : MonoBehaviour
    {
        private float lastDirection;
        private Vector2 moveInput;
        private bool isMoving;


        private InputSystem_Actions inputActions;

        public InputSystem_Actions InputActions { get => inputActions; private set => inputActions = value; }
        public Vector2 MoveInput { get => moveInput;private set => moveInput = value; }
        public bool IsMoving { get => isMoving; private set => isMoving = value; }
        public float LastDirection { get => lastDirection; private set => lastDirection = value; }

        public virtual void Awake()
        {
            InputActions = new InputSystem_Actions();
        }
        private void OnEnable()
        {
            InputActions.Player.Move.performed += Move_performed;
            InputActions.Player.Move.canceled += Move_canceled;
            InputActions.Enable();
        }


        private void OnDisable()
        {
            InputActions.Player.Move.performed -= Move_performed;
            InputActions.Player.Move.canceled -= Move_canceled;
            InputActions.Disable();
        }

        private void Move_canceled(InputAction.CallbackContext obj)
        {
            IsMoving = false;
            MoveInput = Vector2.zero;
        }
        private void Move_performed(InputAction.CallbackContext obj)
        {
            IsMoving = true;
            MoveInput = obj.ReadValue<Vector2>();
            if(Mathf.Abs(MoveInput.y) < 1)
            LastDirection = MoveInput.x;
        }

        public virtual void Movement()
        {
        }
    }
}
