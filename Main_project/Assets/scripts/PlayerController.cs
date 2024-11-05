using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    private Playermovement controls;
    [SerializeField] private Tilemap ground;
    [SerializeField] private Tilemap walls;
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
    private void Move(Vector2 direction)
    {
        if (CanMove(direction))
        {
            transform.position += (Vector3)direction;
        }
    }

    private bool CanMove(Vector2 direction)
    {
        Vector3Int gridPosition = ground.WorldToCell(transform.position + (Vector3)direction);
        if (walls.HasTile(gridPosition))
        {
            return false;
        }
        return true;
    }
}
