using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    [HideInInspector] public Rigidbody2D rb;
    public Collider2D groundCollider;

    public Transform groundColliderTransform;
    public Vector2 groundColliderSize;
    public LayerMask groundLayer;
    [SerializeField] bool _onEnter = false;

    public float speed, jumpHeight;

    IPlayerState _currentState;

    public List<IPlayerState> playerStates = new List<IPlayerState>();

    void Start()
    {
        playerStates.Add(new PlayerStateGrounded(this));
        playerStates.Add(new PlayerStateJump(this));

        instance = this;

        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();

        foreach(IPlayerState state in playerStates)
        {
            if (_currentState == null)
                _onEnter = false;

            if (state.Condition())
            {
                _currentState = state;

                if (!_onEnter)
                {
                    _currentState.OnEnter();
                    _onEnter = true;
                }

                _currentState.Execute();

                _currentState = null;
            }        
        }
    }

    void Move()
    {
        Vector2 move = new Vector2(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, rb.velocity.y);

        rb.velocity = move;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(groundColliderTransform.position, groundColliderSize);
    }
}
