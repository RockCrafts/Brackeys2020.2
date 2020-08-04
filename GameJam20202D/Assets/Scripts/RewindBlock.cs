using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindBlock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("COlide");
        if(other.gameObject.tag == "Player")
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
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
