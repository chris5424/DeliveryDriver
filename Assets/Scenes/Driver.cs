using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 200f;
    [SerializeField] float slowSpeed = 10f;
    [SerializeField] float moveSpeed = 15f;
    [SerializeField] float boostSpeed = 30f;

    void OnTriggerEnter2D(Collider2D other)
    {
          if (other.tag == "BoostSpeed")
          {
              moveSpeed = boostSpeed;
          } 
    }
    void OnCollisionEnter2D(Collision2D other) 
    {
        moveSpeed = slowSpeed;
    }

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal");
        float moveAmount = Input.GetAxis("Vertical");
        transform.Rotate(0,0,-steerAmount * steerSpeed * Time.deltaTime);
        transform.Translate(0,moveAmount * moveSpeed * Time.deltaTime,0);
    }
}
