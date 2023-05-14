using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d; //sækja rigibody á projectile
    
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    public void Launch(Vector2 direction, float force) //tekur við upplýsingum frá ruby og notar AddForce til að skjóta í þá átt sem hún lítur
    {
        rigidbody2d.AddForce(direction * force);
    }

    void OnCollisionEnter2D(Collision2D other) // eyðileggur projectile þegar hann rekst í eitthvað
    {
        Destroy(gameObject);
    }
    void Update()
    {
        if(transform.position.magnitude > 1000.0f) // ef skotið er farið út í buska eyðir því
        {
            Destroy(gameObject);
        }
    }
}
