using UnityEngine;

public class Powerup : MonoBehaviour
{
    private float speed = 2f;
    private AudioManager audioManager;

    private void Start()
    {
        audioManager = GameObject.Find("SoundManager").GetComponent<AudioManager>();
    }



    private void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if(transform.position.y < -5.57f)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if(collision.tag =="Player")
        {
            audioManager.isPowerup = true;
            //access player
            Player player = collision.GetComponent<Player>();

            //enable triple bullet
            player.TripleShotOn();

            Destroy(this.gameObject);
        }
    }
}
