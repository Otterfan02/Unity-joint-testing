using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float jumpForce;
    public float speed;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        // right
        if (Input.GetKey(KeyCode.D))
            rb.AddForce(speed * Time.deltaTime * Vector2.right); 

        // left
        if (Input.GetKey(KeyCode.A))
            rb.AddForce(speed * Time.deltaTime * -Vector2.right);

        // jump
        if (Input.GetKeyDown(KeyCode.Space))
            rb.velocity = Vector2.up * jumpForce;
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Blessed"))
            collision.gameObject.GetComponent<AudioSource>().Play();
    }

}
