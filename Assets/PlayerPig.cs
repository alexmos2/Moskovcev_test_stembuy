using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPig : MonoBehaviour
{
    [SerializeField]
    Sprite[] playerSides;
    [SerializeField]
    GameObject bomb;
    [SerializeField]
    float bomb_cooldown = 5;
    float lastbomb_time = -1000;
    SpriteRenderer player_sprite;
    Rigidbody2D player_rb;
    // Start is called before the first frame update
    void Start()
    {
        player_sprite = GetComponent<SpriteRenderer>();
        player_sprite.sprite = playerSides[0];
        player_rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            player_sprite.sprite = playerSides[3];
            player_rb.velocity = Vector2.up;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            player_sprite.sprite = playerSides[2];
            player_rb.velocity = Vector2.down;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            player_sprite.sprite = playerSides[0];
            player_rb.velocity = Vector2.right;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            player_sprite.sprite = playerSides[1];
            player_rb.velocity = Vector2.left;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            player_rb.velocity = Vector2.zero;
        }
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > lastbomb_time + bomb_cooldown)
        {
            Instantiate(bomb, transform.position, transform.rotation);
            lastbomb_time = Time.time;
        }
        if (transform.position.x < -6)
        {
            transform.position = new Vector2(-6, transform.position.y);
        }
        if (transform.position.x > 6)
        {
            transform.position = new Vector2(6, transform.position.y);
        }
        if (transform.position.y > 3)
        {
            transform.position = new Vector2(transform.position.x, 3);
        }
        if (transform.position.y < -3)
        {
            transform.position = new Vector2(transform.position.x, -3);
        }
    }
    public void LeftButton()
    {
        player_sprite.sprite = playerSides[1];
        player_rb.velocity = Vector2.left;
    }
    public void RightButton()
    {
        player_sprite.sprite = playerSides[0];
        player_rb.velocity = Vector2.right;
    }
    public void DownButton()
    {
        player_sprite.sprite = playerSides[2];
        player_rb.velocity = Vector2.down;
    }
    public void UpButton()
    {
        player_sprite.sprite = playerSides[3];
        player_rb.velocity = Vector2.up;
    }
    public void BombButton()
    {
        if (Time.time > lastbomb_time + bomb_cooldown)
        {
            Instantiate(bomb, transform.position, transform.rotation);
            lastbomb_time = Time.time;
        }
    }
    public void StopMoving()
    {
        player_rb.velocity = Vector2.zero;
    }
}
