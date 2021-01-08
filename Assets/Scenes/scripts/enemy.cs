using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy : MonoBehaviour
{
    public float speed;
    float direction = 1f;
    private int shoot;
    Animator anim;
    private Rigidbody2D rb;
    public Transform FirePoint;
    public GameObject bullet;
    public float speed_shoot = 1f;
    public float speed_shoot_ost = 0;
    private GameObject hero;
    private float dist;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        shoot = 0;
        hero = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        dist = hero.transform.position.x - this.transform.position.x;
        Debug.Log(hero.transform.position.y - this.transform.position.y);
        if (dist <= 10 && dist >= -10 && hero.transform.position.y - this.transform.position.y < 1 )
        {
            
            if (dist >= 0 && direction < 0 || dist < 0 && direction > 0)
            {

                direction *= -1f;
                this.transform.Rotate(0, 180, 0);
            }

            anim.SetInteger("func", 3);
            shoot = 1;
            rb.velocity = new Vector2(0, rb.velocity.y);
            transform.localScale = new Vector3(7.50657f, 7.50657f, 1);
        }
        else
        {
            anim.SetInteger("func", 2);
            shoot = 0;
        }

        if (shoot == 0)
        {
            rb.velocity = new Vector2(speed * direction * Time.deltaTime, rb.velocity.y);
            transform.localScale = new Vector3(7.50657f, 7.50657f, 1);
            anim.SetInteger("func", 2);
        }
        else
        {
            speed_shoot_ost -= Time.deltaTime;
            if (speed_shoot_ost <= 0)
            {
                Instantiate(bullet, FirePoint.position, FirePoint.rotation);
                speed_shoot_ost = speed_shoot;
            }

        }

        


    }

  
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "wall")
        {
            direction *= -1f;
            this.transform.Rotate(0, 180, 0);

        }


    }
    void OnTriggerExit2D(Collider2D other)
    {


    }

}
