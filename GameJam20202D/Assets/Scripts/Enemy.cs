using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public GameObject bullet;
	public GameObject player;
	public float range = 5f;
	public float fireRate = 1f;
	float nextFire;

	// Use this for initialization
	void Start()
	{
		player = GameObject.FindWithTag("Player");
		nextFire = Time.time;
	}

	// Update is called once per frame
	void Update()
	{
		if (Time.time > nextFire && Vector2.Distance(this.transform.position, player.transform.position) < range)
		{
			Instantiate(bullet, transform.position, Quaternion.identity);
			nextFire = Time.time + fireRate;
		}
	}
}
