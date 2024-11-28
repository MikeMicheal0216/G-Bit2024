using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{

    [SerializeField]PlayerState[] states;

    Animator animator;

    Rigidbody2D rb;

    PlayerControl player;

    void Awake()
    {
        animator = GetComponent<Animator>();

        stateTable=new Dictionary<System.Type, IState>(states.Length);

        rb= GetComponent<Rigidbody2D>();

        player= GetComponent<PlayerControl>();

        foreach (PlayerState state in states)
        {
            state.Initialize(animator,this,rb,player);
            stateTable.Add(state.GetType(), state);
        }
    }
    void Start()
    {
        SwitchOn(stateTable[typeof(Player_Idle)]);    
    }
}
