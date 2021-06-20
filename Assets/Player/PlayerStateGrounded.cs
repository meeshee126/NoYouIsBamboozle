using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateGrounded : IPlayerState
{
    public static bool grounded;

    Player _player;

    public PlayerStateGrounded(Player player)
    {
        _player = player;
    }

    public bool Condition()
    {
        grounded = _player.groundCollider = Physics2D.OverlapBox(_player.groundColliderTransform.position,
                    _player.groundColliderSize, 0, _player.groundLayer);

        

        return grounded;
    }

    public void OnEnter()
    {
        Debug.Log("groundedState");
    }

    public void Execute()
    {
        Debug.Log("grounded");
    }

    public void OnExit()
    {

    }

}
