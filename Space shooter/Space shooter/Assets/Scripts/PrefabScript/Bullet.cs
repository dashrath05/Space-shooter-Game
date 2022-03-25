using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private float bulletSpeed = 400f;
   

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
    private void Update()
    {

        if (transform.position.y > 5.23)
        {
            gameObject.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(0,bulletSpeed * Time.deltaTime);
    }
   
}
