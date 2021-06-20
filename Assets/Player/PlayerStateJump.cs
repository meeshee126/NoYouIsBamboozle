using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateJump : IPlayerState
{
    Player _player;

    bool _isJumping;

    public PlayerStateJump(Player player)
    {
        _player = player;
    }

    public bool Condition()
    {
        return Input.GetKeyDown(KeyCode.Space) && PlayerStateGrounded.grounded;
    }

    public void OnEnter()
    {
        _isJumping = false;
        Debug.Log("JumpEnter");
    }

    public void Execute()
    {
        if(!_isJumping)
        {
            Debug.Log("jumping");
            _player.rb.velocity = Vector2.up * _player.jumpHeight;
            _isJumping = true;
        }
    }

    public void OnExit()
    {

    }
}
