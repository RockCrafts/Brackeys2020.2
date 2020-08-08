using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindCore : MonoBehaviour
{
    public bool rewinding = false;
    List<TimePoint> points;
    Rigidbody2D rb;
    Vector2 velocity;
    float angularVel;
    public float timeToRecord = 5f;
    public bool stopedRewinding = false;
    public bool rewindTrue;
    // Start is called before the first frame update
    void Start()
    {
        points = new List<TimePoint>();
        if (GetComponent<Rigidbody2D>() == null)
        {
            rb = null;
        }
        else
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rewinding)
        {
            rewindTrue = true;
            Rewind();
        }
        else
        {
            rewindTrue = false;
            Record();
        }
    }
    void Rewind()
    {
        if (points.Count > 0)
        {
            TimePoint tp = points[0];
            transform.position = tp.position;
            transform.rotation = tp.rotation;
            points.RemoveAt(0);
        }
        else
        {
            stopRewind();
        }
    }
    [ContextMenu("startRewind")]
    public void startRewind() {
        velocity = rb.velocity;
        angularVel = rb.angularVelocity;
        rewinding = true;
        if (rb == null) return;
        rb.isKinematic = true;

    }
    private void stopRewind()
    {
        rewinding = false;
        if (rb == null) return;
        rb.isKinematic = false;
        rb.velocity = velocity;
        rb.angularVelocity = angularVel;
        stopedRewinding = true;
    }
    void Record()
    {
        if (points.Count > Mathf.Round(timeToRecord / Time.fixedDeltaTime))
        {
            points.RemoveAt(points.Count - 1);
        }
        points.Insert(0, new TimePoint(transform.position, transform.rotation));

    }
    public bool getRewinding()
    {
        return rewinding;
    }
}
