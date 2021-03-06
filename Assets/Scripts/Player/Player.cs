﻿using UnityEngine;
using UnityEngine.Tilemaps;
using System.Linq;
using System.Collections.Generic;

public class Player : SingletonMonobehaviour<Player>
{
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    public Tilemap tileMap;
    private SpriteRenderer[] renderers;
    private Rigidbody2D rigidbody2D;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword

    private float xInput;

    private float yInput;
    private float movementSpeed;
    private bool _playerInputIsDisabled = false;
    public bool PlayerInputIsDisabled { get => _playerInputIsDisabled; set => _playerInputIsDisabled = value; }
    public Direction playerDirection;
    public Vector3Int currentIntPlayerPositon;

    private void OnEnable()
    {
        EventHandler.BeforeSceneUnloadEvent += DisablePlayerInput;
        EventHandler.AfterSceneLoadEvent += EnablePlayerInput;
    }

    private void OnDisable()
    {
        EventHandler.BeforeSceneUnloadEvent -= DisablePlayerInput;
        EventHandler.AfterSceneLoadEvent -= EnablePlayerInput;
    }

    public void DisablePlayerInput()
    {
        PlayerInputIsDisabled = true;
    }

    public void EnablePlayerInput()
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
        currentIntPlayerPositon = new Vector3Int((int)transform.position.x, (int)transform.position.y, 0);
    }

    private void FixedUpdate()
    {

        PlayerMovement();
    }

    private void PlayerMovement()
    {
        Vector2 move = new Vector2(xInput * movementSpeed * Time.deltaTime, yInput * movementSpeed * Time.deltaTime);
        /*    if (MapManager.Instance.waterLocations.Count > 0)
            {
                bool onWater = false;
                MapManager.Instance.waterLocations.TryGetValue(currentIntPlayerPositon, out onWater);

                if (onWater)
                {
                    move *= .5f;
                }
            }
        */
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Store>())
        {
            Debug.LogError("Store type " + collision.GetComponent<Store>().locations.ToString());
        }

    }

    private void OnCollisionEnter2D(Collision2D target)
    {

     /*   NPC nPC = target.gameObject.GetComponent<NPC>();

        if (nPC != null)
        {

            Debug.LogError("Collision " + nPC.dialog.name);
            if (nPC.dialog != null)
            {
                UIManager.Instance.ShowText(nPC.dialog.Dialogs[0].dialog[0],
                    nPC.dialog.Dialogs[0].speakersImage
                    , target.gameObject.transform.position);
            }
        }
     */
    }
}