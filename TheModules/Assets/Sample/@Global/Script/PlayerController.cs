using UnityEngine;
using FallenWing.Module.PlayerController;
using UnityEngine.Windows;
using FallenWing.Example.Abstraction.WeaponSystemSO;
namespace FallenWing.Example.Global
{
    public class PlayerController : BasePlayerController
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private AimMouse aimMethod;
        [SerializeField] private WeaponSystem weaponSystem;
        private SpriteRenderer s_renderer;
        private Animator animator;
        private Vector3 direction;
        private const string animParamMove = "IsMove";
       public override void Awake()
        {
            base.Awake();
            s_renderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
            //simPos = transform.position;
        }
        private void Update()
        {
            Movement();
            Flip();
            aimMethod.Aim();
            WeaponSystemUpdate();
        }

        private void WeaponSystemUpdate()
        {
            //Swap Controll
            if (InputActions.Player.WpSlot1.WasPressedThisFrame())
            {
                weaponSystem.SwapWeapon(0);
            }
            if (InputActions.Player.WpSlot2.WasPressedThisFrame())
            {
                weaponSystem.SwapWeapon(1);
            }
            if (InputActions.Player.WpSlot3.WasPressedThisFrame())
            {

                weaponSystem.SwapWeapon(2);
            }
            if (InputActions.Player.WpSlot4.WasPressedThisFrame())
            {

                weaponSystem.SwapWeapon(3);
            }
            //Shot Controll
            weaponSystem.Shot();

        }

        public override void Movement()
        {
            animator.SetBool(animParamMove, IsMoving);
            direction = MoveInput.normalized * moveSpeed * Time.deltaTime;
            transform.position += direction;
        }

        private void Flip()
        {
            s_renderer.flipX = LastDirection < 0;
        }
     
    }
    
}
