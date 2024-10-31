using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.Tilemaps;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Tilemap ground;
    [SerializeField] private Tilemap walls;
    [SerializeField] private List<GameObject> Enemies = new List<GameObject>();
    private void Update()
    {
        Move();
        Debug.Log(Enemies[0].transform.position);
    }
    private void Move()
    {
        foreach (var Enemy in Enemies)
        {
            Vector2 newdirection = new Vector2(Enemy.transform.position.x, Enemy.transform.position.y + 1);
            if (CanMove(newdirection)){
                Enemy.transform.position = newdirection;
            }
            else
            {
                Vector2 reverse = new Vector2(Enemy.transform.position.x, Enemy.transform.position.y - 1);
                Enemy.transform.position = reverse;
            }
        }
    }
    private bool CanMove(Vector2 direction)
    {
        Vector3Int gridPosition = ground.WorldToCell(transform.position + (Vector3)direction);
        if (!ground.HasTile(gridPosition) || walls.HasTile(gridPosition))
        {
            return false;
        }
        return true;
    }


}
