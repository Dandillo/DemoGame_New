using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 pos;

    private void Awake()
    {
        if (!player)
            player = FindObjectOfType<TheDude>().transform;
    }

    private void Update()
    {
        pos = player.position;
        transform.position = Vector3.Lerp(transform.position, new Vector3(pos.x, 0, -10), Time.deltaTime);
    }
}
