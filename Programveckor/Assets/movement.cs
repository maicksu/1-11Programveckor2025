using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    Rigidbody2D rb;
    public int accelerationSpeed;
    public int maxSpeed;
    public int friction;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-5, 0);
            // walk left
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(5, 0);
            // walk right
        }
       
    }
}
