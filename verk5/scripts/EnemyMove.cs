using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed; //public breytur sem haegt er ad breyta gegnum unity
    public bool vertical;
    public float changeTime = 3.0f;

    Rigidbody2D rigidbody2D; //breytur sem notaðar eru til að breyta hreyfinguni
    float timer;
    int direction = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
    }

    void Update() // telur nidur timann og breytir um att
    {   
        timer -= Time.deltaTime;

        if (timer < 0) // telur niður tímann og snýr við timinn klárast
        {
            direction = -direction;
            timer = changeTime;
        }
    }
    
    void FixedUpdate() // faerir gaurinn
    {   
        Vector2 position = rigidbody2D.position;
        
        if (vertical) // færir hann annaðhvort up og niður eða hægri vinstri eftir því hvort vertical er true eða false
        {
            position.y = position.y + Time.deltaTime * speed * direction;;

        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;;
        }
        
        rigidbody2D.MovePosition(position);
    }
}