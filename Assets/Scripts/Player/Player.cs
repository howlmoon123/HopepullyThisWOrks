using UnityEngine;

public class Player : SingletonMonobehaviour<Player>
{
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    private SpriteRenderer[] renderers;
    private Rigidbody2D rigidbody2D;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword

    private float xInput;

    private float yInput;
    private float movementSpeed;
    private bool _playerInputIsDisabled = false;
    public bool PlayerInputIsDisabled { get => _playerInputIsDisabled; set => _playerInputIsDisabled = value; }
    public Direction playerDirection;

    private void OnEnable()
    {
        EventHandler.BeforeSceneUnloadEvent += SetPlayerDisabled;
        EventHandler.AfterSceneLoadEvent += UnSetPlayerDisabled;
    }

    private void OnDisable()
    {
        EventHandler.BeforeSceneUnloadEvent += SetPlayerDisabled;
        EventHandler.AfterSceneLoadEvent += UnSetPlayerDisabled;
    }

    public void SetPlayerDisabled()
    {
        PlayerInputIsDisabled = true;
    }

    public void UnSetPlayerDisabled()
    {
        PlayerInputIsDisabled = false;
    }

    protected override void Awake()
    {
        base.Awake();

        renderers = GetComponentsInChildren<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!PlayerInputIsDisabled)
        {
            PlayerMovementInput();
            PlayerWalkInput();
        }
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        Vector2 move = new Vector2(xInput * movementSpeed * Time.deltaTime, yInput * movementSpeed * Time.deltaTime);

        rigidbody2D.MovePosition(rigidbody2D.position + move);
    }

    private void PlayerMovementInput()
    {
        yInput = Input.GetAxisRaw("Vertical");
        xInput = Input.GetAxisRaw("Horizontal");

        if (yInput != 0 && xInput != 0)
        {
            xInput = xInput * 0.71f;
            yInput = yInput * 0.71f;
        }

        if (xInput != 0 || yInput != 0)
        {
            movementSpeed = Settings.runningSpeed;

            // Capture player direction for save game
            if (xInput < 0)
            {
                playerDirection = Direction.left;
            }
            else if (xInput > 0)
            {
                playerDirection = Direction.right;
            }
            else if (yInput < 0)
            {
                playerDirection = Direction.down;
            }
            else
            {
                playerDirection = Direction.up;
            }
        }
    }

    private void PlayerWalkInput()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            movementSpeed = Settings.walkingSpeed;
        }
        else
        {
            movementSpeed = Settings.runningSpeed;
        }
    }
}