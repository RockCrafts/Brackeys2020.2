using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    GameObject player;
    public float minTurn = -10f;
    public float maxTurn = 10f;
    public float range = 5f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void shoot()
    {
        RaycastHit2D ray;
        ray = Physics2D.Linecast(this.transform.position, player.transform.position);
        if(ray.collider != null)
        {
            RewindCore rewindCore = ray.collider.gameObject.GetComponent<RewindCore>();
            if (rewindCore.getRewinding())
            {
                return;
            }
            else
            {
                rewindCore.startRewind();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y + 5);
        RaycastHit2D ray;
        ray = Physics2D.Linecast(this.transform.position, player.transform.position);
        Debug.DrawLine(ray.point, transform.position, Color.red);
        print(ray.point);

        if(Vector2.Distance(this.transform.position, player.transform.position) < range)
        {
            shoot();
        }
    }
}
