using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    private Animator anim;
    private float speed = 2.0f;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var maxSpeed = GameManager.Instance.SpeedMax;
        var direction = Input.GetAxis("Horizontal");
        var velocity = Mathf.Clamp(direction * speed, -maxSpeed, maxSpeed);
        rb.velocity = new Vector2(velocity, transform.position.y);

        if (Input.GetAxis("Horizontal") > 0)
        {
            sr.flipX = false;

        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            sr.flipX = true;
        }
        
        if (Input.GetAxis("Horizontal") != 0)
        {
            anim.SetBool("run", true);
        }
        else
        {
            anim.SetBool("run", false);
        }
    }
}
