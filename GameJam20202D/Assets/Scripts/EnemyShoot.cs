using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    GameObject player;
    public float minTurn = -10f;
    public float maxTurn = 10f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y + 5);
        Debug.DrawRay(this.transform.position, player.transform.position, Color.red);
        Physics2D.Raycast(this.transform.position, player.transform.position);

    }
}
