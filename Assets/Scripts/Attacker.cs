﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    // Configuration Parameters
    // [Range (0f, 5f)]
    [Header("Enemy Effects")]
    [SerializeField] GameObject deathVFX;
    float currentSpeed = 1f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }
}
