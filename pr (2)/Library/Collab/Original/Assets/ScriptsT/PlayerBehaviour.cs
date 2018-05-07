using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerInput))]
public class PlayerBehaviour : MonoBehaviour
{
    
    private PlayerInput playerInput;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private int _maxJumps; //Actual amount of jumps is maxJumps + 1 atm
    private Rigidbody2D _rb;


    //These 4 are needed for ground checking
    [SerializeField] private float _groundCheckerRadius;
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField]
    private Transform _groundChecker;

    private bool _grounded;

    private float _move;
    private bool _jump;
    private int _jumps;
    private Animator _anim;
    public bool _attack;
    public bool FacingRight { get; private set; }

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        // _groundChecker = transform.GetChild(1);
        //Check if the character is facing left
        FacingRight = transform.localScale.x != -1;
        
       
        if (GetComponent<PlayerInput>() != null)
            GetComponent<PlayerInput>().OnAttack += HandleAttack;

        if (GetComponent<PlayerHealth>() != null)
        {
            GetComponent<PlayerHealth>().OnDied += HandleDeath;
        }
    }


    void Update()
    {
        _move = playerInput.Horizontal;
        _jump = playerInput.Jump;
        _attack = playerInput.IsAttacking;


        if (_move != 0)
        {
            _anim.SetTrigger("PlayerWalk");
        }
        //Flipping the player depending on the direction of motion
        if (_move > 0 && !FacingRight) Flip();
        else if (_move < 0 && FacingRight) Flip();

        Jump();


        //resets numbers of jumps when we are grounded
        if (_grounded) _jumps = _maxJumps;

    }

    private void HandleAttack()
    {
        _anim.SetTrigger("PlayerAttack");
    }

    private void FixedUpdate()
    {
        //One way to check if the characters are grounded. The layer mask decides what layers count as ground.
        _grounded = Physics2D.OverlapCircle(_groundChecker.position, _groundCheckerRadius, _whatIsGround);

        //move left or right
        _rb.velocity = new Vector2(_move * _speed, _rb.velocity.y);
    }
    private void Flip()
    {
        //Flipping the character by inverting the x-scale.
        FacingRight = !FacingRight;
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }

    private void Jump()
    {
        //Check if jump is pressed and we if we have any jumps left
        if (!_jump || _jumps <= 0) return;
        _anim.SetTrigger("PlayerJump");
        _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
        _jumps -= 1;
    }
    private void HandleDeath()
    {
        _anim.SetTrigger("PlayerDie");
    }

}
