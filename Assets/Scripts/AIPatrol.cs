using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrol : MonoBehaviour
{
    [HideInInspector] 
    public bool mustPatrol;
    private bool mustTurn = false;

    private Rigidbody2D rb;
    public int walkspeed = 16;
    public Transform groundCheckPosition;
    public LayerMask GroundLayer;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        mustPatrol = true;
    }

    void FixedUpdate()
    {
        if (mustPatrol)
        {
            mustTurn = Physics2D.OverlapCircle(groundCheckPosition.position, 0.1f, GroundLayer);
        }
    }
    void Update()
    {
        if (mustPatrol)
            Patrol();
    }

    private void Patrol()
    {
        if (mustTurn)
        {
            FLip();
        }
        rb.velocity = new Vector2(walkspeed * Time.fixedDeltaTime,rb.velocity.y);
    }

    void FLip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y * -1 );
        walkspeed *= -1;
        mustPatrol = true;
    }
}
