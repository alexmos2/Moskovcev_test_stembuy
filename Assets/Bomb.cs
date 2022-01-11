using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    float blast_time = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Blast", blast_time - 0.1f);
        Invoke("SelfDestruction", blast_time);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
    private void Blast()
    {
        GetComponent<Collider2D>().enabled = true;
        transform.Translate(new Vector3(0.01f, 0, 0));
    }
    private void SelfDestruction()
    {
        Destroy(gameObject);
    }
}
