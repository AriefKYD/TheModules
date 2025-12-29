using UnityEngine;
using FallenWing.Module.PlayerController;
using UnityEngine.Windows;
namespace FallenWing.Example.Abstraction
{
    public class PlayerController_WeaponAbs : BasePlayerController
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private AimMouse aimMethod;
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
