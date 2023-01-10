using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{

    public float speed;
    public Transform[] patrolPoints;
    public float waitTime;
    int current;
    bool once;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != patrolPoints[current].position)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[current].position, speed * Time.deltaTime);
        }
        else
        {
            if (once == false)
            {
                once = true;
                StartCoroutine(Wait());
            }
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);
        if (current + 1 < patrolPoints.Length)
        {
            current++;
        }
        else
        {
            current = 0;
        }
        once = false;
    }
}
