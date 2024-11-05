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
            Vector2 diffdirection = new Vector2(Enemy.transform.position.x, Enemy.transform.position.y - 1);
            Debug.Log(CanMove(newdirection));
            if (CanMove(newdirection))
            {
                Enemy.transform.position = newdirection;
            }
            else
            {
                    Enemy.transform.position = diffdirection;
            }
        }
    }
    private bool CanMove(Vector2 direction)
    {
        Vector3Int gridPosition = ground.WorldToCell((Vector3)direction);
        if (walls.HasTile(gridPosition))
        {
            return false;
        }
        return true;
    }
}
