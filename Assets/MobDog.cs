using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobDog : MonoBehaviour
{
    [SerializeField]
    Sprite[] mobSides;
    SpriteRenderer mob_sprite;
    Rigidbody2D mob_rb;
    [SerializeField]
    float changeDirectionCooldown = 5f;
    // Start is called before the first frame update
    void Start()
    {
        mob_sprite = GetComponent<SpriteRenderer>();
        mob_sprite.sprite = mobSides[0];
        mob_rb = GetComponent<Rigidbody2D>();
        ChangeDirection();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -6)
        {
            transform.position = new Vector2(-6, transform.position.y);
            ChangeDirection();
        }
        if (transform.position.x > 6)
        {
            transform.position = new Vector2(6, transform.position.y);
            ChangeDirection();
        }
        if (transform.position.y > 3)
        {
            transform.position = new Vector2(transform.position.x, 3);
            ChangeDirection();
        }
        if (transform.position.y < -3)
        {
            transform.position = new Vector2(transform.position.x, -3);
            ChangeDirection();
        }
    }
    void ChangeDirection()
    {
        int direction_number = (int) Random.Range(0, 3.99f);
        mob_sprite.sprite = mobSides[direction_number];
        switch (direction_number)
        {
            case 0:
                mob_rb.velocity = Vector2.right;
                break;
            case 1:
                mob_rb.velocity = Vector2.left;
                break;
            case 2:
                mob_rb.velocity = Vector2.down;
                break;
            case 3:
                mob_rb.velocity = Vector2.up;
                break;
        }
        Invoke("ChangeDirection", changeDirectionCooldown);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) Destroy(collision.gameObject);
        else ChangeDirection();
    }
}
