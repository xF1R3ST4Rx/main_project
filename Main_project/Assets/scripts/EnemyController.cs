using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Tilemap ground;
    [SerializeField] private Tilemap walls;
    [SerializeField] private List<GameObject> Enemies = new List<GameObject>();
    [SerializeField] PlayerController controller;
    [SerializeField] GameObject player;
    [SerializeField] TextMeshProUGUI gameOver;
    [SerializeField] Button reset;
    bool hascollide = false;
    private void Update()
    {
        Move();
        collisioncheck();
    }
    private void Move()
    {
        Vector2 newdirection;
        if (controller.getplayermoved() == true)
        {
            foreach (GameObject enemy in Enemies)
            {
                if (enemy.gameObject.tag == "vertical")
                {
                    bool needSwitch = enemy.gameObject.GetComponent<Enemy>().Switch;
                    if (needSwitch)
                    {
                        newdirection = new Vector2(enemy.transform.position.x, enemy.transform.position.y + 1);
                        if (CanMove(newdirection))
                        {
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
                            enemy.transform.position = newdirection;
                            controller.playerhasmoved = false;
                        }
                        if (CanMove(newdirection) == false)
                        {
                            enemy.gameObject.GetComponent<Enemy>().Switch = true;
                        }
                    }
                }
                else
                {
                    bool needSwitch = enemy.gameObject.GetComponent<Enemy>().Switch;
                    if (needSwitch)
                    {
                        newdirection = new Vector2(enemy.transform.position.x+1, enemy.transform.position.y);
                        if (CanMove(newdirection))
                        {
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
                        newdirection = new Vector2(enemy.transform.position.x-1, enemy.transform.position.y);
                        if (CanMove(newdirection))
                        {
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
    public void collisioncheck()
    {
        for (int i = Enemies.Count - 1; i >= 0; i--)
        {
            if (getPosition(player).x == Enemies[i].transform.position.x && getPosition(player).y == Enemies[i].transform.position.y)
            {
                hascollide = true;
                int currentsceneindex = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(currentsceneindex);
            }
        }
    }
    private Vector2 getPosition(GameObject player)
    {
        Vector2 pos = player.transform.position;
        return pos;
    }
    public bool getcollide()
    {
        return hascollide;
    }
}
