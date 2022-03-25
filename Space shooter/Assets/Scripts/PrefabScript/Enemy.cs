using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed=5f;
    [SerializeField] private GameObject explosionPrefab;

    private AudioManager audioManager;
    private int hitBullets = 0;

    private void Start()
    {
        audioManager = GameObject.Find("SoundManager").GetComponent<AudioManager>();
    }

   

    private void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if(transform.position.y <-5.57f)
        {
            float randomX = Random.Range(-2.15f, 2.25f);
            transform.position = new Vector3(randomX, 5.50f, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {  
       
        if (other.tag == "Bullet")
        {

            hitBullets++;
            other.gameObject.SetActive(false);
            if(hitBullets==4)
            {
               
                //score increment
                ObjectPool.instance.score += 1;

                audioManager.isExplosion = true;
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
                hitBullets = 0;
            }
        }
        else if(other.tag == "Player")
        {
            
            Player player = other.GetComponent<Player>();
            if(player != null)
            {
                audioManager.isExplosion = true;
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
                player.PlayerTakeDamege();
            }

        }
    }
}
