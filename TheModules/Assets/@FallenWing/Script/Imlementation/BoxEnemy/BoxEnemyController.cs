using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FallenWing.Module.FSM;
public class BoxEnemyController : FSM_Factory<BoxEnemyController.BoxEnemyEnum,BoxEnemyController>
{
    public enum BoxEnemyEnum
    {
        Idle,
        Patrol,
        Die
    }

    private void Awake()
    {
        states.Add(BoxEnemyEnum.Idle, new BoxEnemyIdle(BoxEnemyEnum.Idle, this));
        states.Add(BoxEnemyEnum.Patrol, new BoxEnemyPatrol(BoxEnemyEnum.Patrol, this));
        states.Add(BoxEnemyEnum.Die, new BoxEnemyDie(BoxEnemyEnum.Die, this));
        currentState = states[BoxEnemyEnum.Idle];
    }

    protected override void Update()
    {
        if (Time.timeScale == 0) return;//State paused
        base.Update();
    }
}
