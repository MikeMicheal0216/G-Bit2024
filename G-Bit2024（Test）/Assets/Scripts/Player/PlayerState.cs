using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerState : ScriptableObject,IState
{
    protected Animator animator;

    protected PlayerStateMachine stateMachine;

    protected Rigidbody2D rb;

    protected PlayerControl player;

    public void Initialize(Animator animator, PlayerStateMachine stateMachine, Rigidbody2D rb,PlayerControl player) 
    {
        this.animator = animator;
        this.stateMachine = stateMachine;
        this.rb = rb;
        this.player = player;
    }
    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void LogicUpdate() { }
    public virtual void PhysicaUpdate() { }
    public virtual void HandleInput() { }
}
