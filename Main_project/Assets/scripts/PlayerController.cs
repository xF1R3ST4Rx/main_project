using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Playermovement controls;
    [SerializeField] private Tilemap ground;
    [SerializeField] private Tilemap walls;
    public bool playerhasmoved = false;
    [SerializeField] GameManager gamemanager;
    private Vector2 lastDirection;
    [SerializeField] GameObject player;
    private void Awake()
    {
        controls = new Playermovement();
    }
    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
    void Start()
    {
        controls.Main.Movement.performed += ctx => Move(ctx.ReadValue<Vector2>());
    }
    //player movement 
    private void Move(Vector2 direction)
    {
        Debug.Log(gamemanager.oiledMove(direction));
        if (gamemanager.oiledMove(direction) == true && CanMove(lastDirection))
        {
            transform.position += (Vector3)lastDirection;
            playerhasmoved = true;
        }
        else if (CanMove(direction))
        {
            transform.position += (Vector3)direction;
            playerhasmoved = true;
            lastDirection = direction;
        }
    }
    //checks if can move
    public bool CanMove(Vector2 direction)
    {
        Vector3Int gridPosition = ground.WorldToCell(transform.position + (Vector3)direction);
        if (walls.HasTile(gridPosition))
        {
            return false;
        }
        return true;
    }
    //gets if the player has moved for the enemy script
    public bool getplayermoved()
    {
    return playerhasmoved;
    }
    //returns last direction 
    public Vector2 GetLastDirection()
    {
        return lastDirection;
    }
}

