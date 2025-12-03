
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FallenWing.Module.HFSM;
using FallenWing.Module.EventManager;
public class PlayerController : HFSM_Factory<PlayerController.PlayerState, PlayerController>
{
    public enum PlayerState
    {

    }
    protected override void Awake()
    {
        base.Awake();
    }
    void Start()
    {
    }
}