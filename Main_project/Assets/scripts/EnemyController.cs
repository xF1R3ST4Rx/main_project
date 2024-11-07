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
    [SerializeField] PlayerController controller;
    private void Update()
    {
        Move();

    }
    private void Move()
    {
        Vector2 newdirection;
        if (controller.getplayermoved() == true)
        {
            foreach (GameObject enemy in Enemies)
            {
                bool needSwitch = enemy.gameObject.GetComponent<Enemy>().Switch;
                if (needSwitch)
                {
                    newdirection = new Vector2(enemy.transform.position.x, enemy.transform.position.y + 1);
                    if (CanMove(newdirection))
                    {
                        Debug.Log("1");
                        enemy.transform.position = newdirection;
                        controller.playerhasmoved = false;
                    }
                    if (CanMove(newdirection) == false)
                    {
                        enemy.gameObject.GetComponent<Enemy>().Switch = false;
                    }
                }
                else if (!needSwitch)
                {
                    newdirection = new Vector2(enemy.transform.position.x, enemy.transform.position.y - 1);
                    if (CanMove(newdirection))
                    {
                        Debug.Log("1");
                        enemy.transform.position = newdirection;
                        controller.playerhasmoved = false;
                    }
                    if (CanMove(newdirection) == false)
                    {
                        enemy.gameObject.GetComponent<Enemy>().Switch = true;
                    }
                }
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
