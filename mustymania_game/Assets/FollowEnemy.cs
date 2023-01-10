using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemy : MonoBehaviour
{
    public float speed;
    public Transform target;
    public float minimumDistance;
    public float maximumDistance;

    private Rigidbody2D rb;

    [SerializeField]
    private LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > minimumDistance && Vector2.Distance(transform.position, target.position) < maximumDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            //ATTACK CODE
        }
    }

    private void FixedUpdate()
    {
        RaycastHit2D hitWallLeft = Physics2D.Raycast(transform.position, Vector2.left, 2f, layerMask);
        Debug.DrawRay(transform.position, Vector2.left, Color.red);

        //RaycastHit2D hitWallRight = Physics2D.Raycast(wallRayRight.transform.position, Vector2.right);
        //Debug.DrawRay(wallRayRight.transform.position, Vector2.right * hitWallRight.distance, Color.red);

        if (hitWallLeft.collider != null)
        {
            rb.AddForce(new Vector2(0f, 35f));
        }
    }
}
