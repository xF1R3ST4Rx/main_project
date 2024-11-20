using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerController : MonoBehaviour
{
    private Playermovement controls;
    [SerializeField] SoundManager sound;
    [SerializeField] SoundManager honk;
    [SerializeField] private Tilemap ground;
    [SerializeField] private Tilemap walls;
    public bool playerhasmoved = false;
    [SerializeField] GameManager gamemanager;
    private Vector2 lastDirection;
    [SerializeField] GameObject player;
    [SerializeField] List<GameObject> oilSpots = new List<GameObject>();
    bool slickmove = false;
    [SerializeField] EnemyController enemy;
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
        if (oiledMove() == true && CanMove(lastDirection))
        {
            transform.position += (Vector3)lastDirection;
            sound.PlaySound();
            playerhasmoved = true;
            if (CanMove(lastDirection) == false)
            {
                slickmove = false;
            }
        }
        else if (CanMove(direction))
        {
            transform.position += (Vector3)direction;
            playerhasmoved = true;
            lastDirection = direction;
            sound.PlaySound();
        }
        if(enemy.getcollide() == true)
        {
            honk.PlaySound();
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
    public bool oiledMove()
    {
        foreach (GameObject spill in oilSpots)
        {
            if (player.transform.position.x == spill.transform.position.x && player.transform.position.y == spill.transform.position.y || (slickmove == true && CanMove(lastDirection)))
            {
                return slickmove = true;
            }
        }
        return false;
    }
}

