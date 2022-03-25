using UnityEngine;

public class Explosion : MonoBehaviour
{
    private float speed = 2f;
   
    private void Update()
    {
        
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y < -5.23)
        {
            Destroy(this.gameObject);
        }

        
    }  
}
