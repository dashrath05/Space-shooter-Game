using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
   
    public int lives = 3;
    public bool isTrippleBullet = false;

    [SerializeField]private GameObject gameoverPopup;
    [SerializeField] private GameObject explosionPrefab;

    private float fireRate = 0.28f;
    private AudioSource fireSound;
    private float smoothTouch=15f;
    private float canFire = 1.5f;  


    private void Start()
    {
        fireSound = gameObject.GetComponent<AudioSource>();
        
    }


    private void Update()
    {
        PlayerPosition();
        if(Time.time>canFire)
        {
            FireBullets();
            canFire = Time.time + fireRate;
        }
            
    }

    private void FireBullets()
    {

        GameObject bullet = ObjectPool.instance.GetBulletPooledObject();
        if (bullet != null)
        {
            fireSound.Play();
            if(isTrippleBullet)  
            {
                //rightside bullets
                GameObject rightbullet = ObjectPool.instance.GetBulletPooledObject();
                rightbullet.transform.position = transform.position + new Vector3(0.402f, -0.693f, 0);
                rightbullet.SetActive(true);

                //center bullets
                GameObject centerBullet = ObjectPool.instance.GetBulletPooledObject();
                centerBullet.transform.position = transform.position + new Vector3(0.001f, 0.31f, 0);
                centerBullet.SetActive(true);

                //leftside bullets
                GameObject leftBullet = ObjectPool.instance.GetBulletPooledObject();
                leftBullet.transform.position = transform.position + new Vector3(-0.402f, -0.693f, 0);
                leftBullet.SetActive(true);

            }
            else
            {
                //single bullet
                bullet.transform.position = transform.position + new Vector3(0.001f, 0.31f, 0);
                bullet.SetActive(true);
            }
        }

    }
    private void PlayerPosition()
    {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                //get the touch position 
                Vector3 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
                //lerp and set the position smooth
                transform.position = Vector3.Lerp(transform.position, touchedPos, Time.deltaTime * smoothTouch);
            }
        }
    }

    public void TripleShotOn()
    {
        isTrippleBullet = true;
        StartCoroutine(TripleShootPowerOff());

    }
    IEnumerator TripleShootPowerOff()
    {
        yield return new WaitForSeconds(5.0f);
        isTrippleBullet = false;

    }

    public void PlayerTakeDamege()
    {
        lives--;

        if(lives<=0)
        {
            gameoverPopup.SetActive(true);
            Time.timeScale = 0;
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            this.gameObject.SetActive(false);
        }
    }
}  
