using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectCollider : MonoBehaviour
{
    public int value; // public breyta sem hægt er að stilla fyrir bæði óvini og gimsteina
    public bool goal = false; //bool breyta bara fyrir markið  

    void OnTriggerStay2D(Collider2D other)
        {
            RubyController controller = other.GetComponent<RubyController>(); //reynir að sækja rubycontroller

            if (controller != null) // ef rubycontroller finnst breytir stigum eftir value og eyðileggur object
            {
                if (goal) //leikur klarast ef rekist er í markið
                {
                    SceneManager.LoadScene(2);
                }

                if (controller.isInvincible && value <0) { //ef ruby er invicible gerist ekki neitt
                    return;
                }
                controller.ChangeStig(value);
                Destroy(gameObject);
            }

            Projectile e = other.GetComponent<Projectile>(); // reynir að sækja projectile

            if (e != null && value < 0) // ef value ef minna er 0 þá er er um að ræða óvin og eyðir honum ef hann fær byssoskot i sig
            {
                Destroy(gameObject);
            }
        }
}
