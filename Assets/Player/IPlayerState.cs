using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerState
{
    bool Condition();
    void OnEnter();
    void Execute();
    void OnExit();
}
