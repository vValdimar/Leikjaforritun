using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Bullet : MonoBehaviour
{
    public float speed=20f;
    public Rigidbody rb;
    public int damage = 10;
    public GameObject sprengjan;
    public static int count;//klasabreyta
    private TextMeshProUGUI countText;
    void Start()
    {
        rb.velocity = transform.forward * speed;
        countText = GameObject.Find("Text").GetComponent<TextMeshProUGUI>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.collider.tag=="raudurkassi")
        {
            count += 10;
            Destroy(collision.gameObject);//eyðir kassanum
            //Destroy(gameObject);//eyða kúlunni þarf ekki eyðist eftir 0.5 sek                 
            Sprengja();//framkvæmir sprengju
            countText.text = "stig " + count.ToString();
        }
       
    }
    
    void Sprengja()
    {
        Instantiate(sprengjan, transform.position, transform.rotation);
    }
    
}
