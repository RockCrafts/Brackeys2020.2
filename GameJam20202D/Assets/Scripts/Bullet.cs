using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	float moveSpeed = 7f;

	Rigidbody2D rb;

	GameObject player;
	Vector2 moveDirection;

	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		player = GameObject.FindWithTag("Player");
		moveDirection = (player.transform.position - transform.position).normalized * moveSpeed;
		rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
		Destroy(gameObject, 3f);
	}

    private void OnCollisionEnter2D(Collision2D other)
    {
		if (other.gameObject.tag == "Player")
		{
			RewindCore rewindCore = other.gameObject.GetComponent<RewindCore>();
			if (rewindCore.getRewinding())
			{
				return;
			}
			else
			{
				rewindCore.startRewind();
			}
		}
		else if (other.gameObject.tag == "Enemy")
		{
			return;
        }
        else
        {
			Destroy(this.gameObject);
        }
	}
}
