using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrol : MonoBehaviour
{
    [Header("Patrol points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;
    
    [Header("Enemy")]
    [SerializeField] private Transform enemy;
    [Header("Movement")]
    [SerializeField] private float speed = 150;

    private bool movingLeft;

    private Vector3 initScale;

    private void Awake()
    {
        initScale = enemy.localScale;
    }
    private void MoveInDirection(int _direction)
    {
        enemy.localScale = new Vector2(Mathf.Abs(initScale.x) * _direction, initScale.y);
        enemy.position = new Vector2(enemy.position.x + Time.deltaTime * _direction * speed, enemy.position.y);
    }

    void Update()
    {
        if (enemy != null)
        {
            if (movingLeft)
            {
                if(enemy.position.x >= leftEdge.position.x)
                    MoveInDirection(-1);
                else
                {
                    FLip();
                }
            }
            else
            {
                if(enemy.position.x <= rightEdge.position.x)
                    MoveInDirection(1);
                else
                {
                    FLip();
                }
            }
        }
        
    }
    void FLip()
    {
        movingLeft = !movingLeft;
    }
}
