using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public string Level;

    // Start is called before the first frame update
    void Start()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Colide");
        if(other.gameObject.tag == "Player")
        {
            if (other.gameObject.GetComponent<PlayerController>().hasKey)
            {
                SceneManager.LoadScene(Level);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
