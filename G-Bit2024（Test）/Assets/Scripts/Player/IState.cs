using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    void Enter();
    void LogicUpdate();
    void PhysicaUpdate();
    void Exit();
    void HandleInput();
}
