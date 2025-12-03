using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FallenWing.Module.FSM;
namespace FallenWing.Behavior.NPC.Minion
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Rigidbody))]
    public class MinionController : FSM_Factory<MinionController.MinionState, MinionController>
    {
        public enum MinionState
        {
            Idle,
            Chase,
            Patrol,
            Stunned,
            Attack
        }
        private Rigidbody rb;
        private Animator animator;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            animator = GetComponent<Animator>();

            InitializeStates();
        }

        private void InitializeStates()
        {
            states.Add(MinionState.Idle, new FSM_MinionIdle(MinionState.Idle, this));
            states.Add(MinionState.Chase, new FSM_MinionChase(MinionState.Chase, this));
            states.Add(MinionState.Patrol, new FSM_MinionPatrol(MinionState.Patrol, this));
            states.Add(MinionState.Stunned, new FSM_MinionStunned(MinionState.Stunned, this));
            states.Add(MinionState.Attack, new FSM_MinionAttack(MinionState.Attack, this));
            currentState = states[MinionState.Idle];
        }

        public void SwitchState(MinionState state)
        {
            TransitionToState(state);
        }
    }
}