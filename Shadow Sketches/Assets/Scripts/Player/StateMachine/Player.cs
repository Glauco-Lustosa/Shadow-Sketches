using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerStateMachine StateMachine { get; private set; }
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }

    public Animator Anim { get; private set; }
    public PlayerInputHandler inputHandler { get; private set; }
    [SerializeField]
        private PlayerData playerData;

    public Rigidbody2D _rb2D { get; private set; }
    public Vector2 _movement { get; private set; }

    private Vector2 workspace;

    private void Awake()
    {
        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, StateMachine, playerData, "idle");
        MoveState = new PlayerMoveState(this, StateMachine, playerData, "move");

    }

    private void Start()
    {
        // ToDo Initialize SateMachine

        Anim = GetComponent<Animator>();
        inputHandler = GetComponent<PlayerInputHandler>();
        _rb2D = GetComponent<Rigidbody2D>();
        StateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        
        StateMachine.CurrentSate.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentSate.PhysicsUpdate();
    }

    public void setVelocityX(float velocity)
    {
        workspace.Set(velocity, _movement.y);
        _rb2D.velocity = workspace;
        _movement = workspace;
       // _rb2D.MovePosition(_rb2D.position + _movement * Time.fixedDeltaTime);

    }
}
