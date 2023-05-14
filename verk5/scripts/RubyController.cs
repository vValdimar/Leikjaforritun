using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RubyController : MonoBehaviour
{
    public float speed = 5.0f; //breytur til að stilla hraðann
    public float jumpForce = 10.0f; 

    int stig; // breytur sem halda um stigafjöldann
    public TextMeshProUGUI countStig;

    public float timeInvincible = 2.0f; //stillir hversu lengi Ruby er invicible eftir að hún meiðist
    public bool isInvincible;
    float invincibleTimer;

    public GameObject projectilePrefab;
    Rigidbody2D rigidbody2d;

    float horizontal;
    float vertical;

    Animator animator;
    Vector2 lookDirection = new Vector2(1,0);

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal"); //sækir inputs frá input manager
        vertical = Input.GetAxis("Jump");

        // VV uppfærir breytur fyrir animator svo að ruby snúi í rétta átt VV
        Vector2 move = new Vector2(horizontal, 0f); 

        if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        if (isInvincible) // telur tímann þegar Ruby er invincible
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }

        if(Input.GetKeyDown(KeyCode.L)) // kallar á Launch() þegar ýtt er á L takkann
        {
            Launch();
        }
    }

    void FixedUpdate()
    {
        // VV hreyfir Ruby út frá input manager og hraðastillingum VV
        Vector2 position = rigidbody2d.position; 
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + jumpForce * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }

    void Launch()
    {
        //býr til afrit af prefab af byssukúlunni
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);

        Projectile projectile = projectileObject.GetComponent<Projectile>(); //sækir Projectile skriftuna
        projectile.Launch(lookDirection, 600); //notar Launch() úr henni til að skjóta 

        animator.SetTrigger("Launch"); // lætur animator vita að verið var að skjóta
    }

    public void ChangeStig(int amount) //fall til að breyta og uppfæra stig
    {
        if (amount < 0) // VV ef breyting á stigum er neikvæð þá gerir Ruby invincible
        {
            animator.SetTrigger("Hit");
            if (isInvincible)
                return;

            isInvincible = true;
            invincibleTimer = timeInvincible;
        }

        stig = stig + amount; // breytir sitgafjölda

        if ( stig < 0 )
        {
            SceneManager.LoadScene(0);
        }

        countStig.text = "Stig: " + stig.ToString(); // upp færir textann á canvas

        Lokastig.stigValue = stig; // uppfærir stigafjoldann fyrir loka senuna
    }
}
