using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_manager : MonoBehaviour
{
    [SerializeField] GameObject car;
    [SerializeField] int grid;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 pos = new Vector2(0, 0);
        transform.Translate(pos);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Vector2 pos = new Vector2(-grid, 0);
            transform.Translate(pos);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            Vector2 pos = new Vector2(0, -grid);
            transform.Translate(pos);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Vector2 pos = new Vector2(grid,0);
            transform.Translate(pos);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Vector2 pos = new Vector2( 0, grid);
            transform.Translate(pos);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Enter");
    }
}
