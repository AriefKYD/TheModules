using UnityEngine;

namespace FallenWing.Example.ObjectPoolerSample
{
    using FallenWing.Example.Global;
    using FallenWing.Module.PlayerController;
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