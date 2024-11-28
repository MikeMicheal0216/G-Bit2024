using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
/// <summary>
/// 管理所有状态类
/// </summary>
public class StateMachine : MonoBehaviour
{
    protected IState currentState;

    protected Dictionary<System.Type, IState> stateTable;

    void Update()
    {
        currentState.LogicUpdate();
    }
    void FixedUpdate()
    {
        currentState.PhysicaUpdate();
    }
    protected void SwitchOn(IState newState)
    {
        currentState = newState;
        currentState.Enter();
    }
    public void SwithState(IState newState)
    {
        currentState.Exit();
        SwitchOn(newState);
    }
    public void SwithState(System.Type newStateType)
    {
        SwithState(stateTable[newStateType]);
    }
}
