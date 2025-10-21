using Unity.Mathematics;
using UnityEngine;

public class rock : enemy__damage
{
    [SerializeField] private float speed;
    [SerializeField] private float resetTime;
    [SerializeField] private float turnSpeed;
    [SerializeField] private Transform target;
    
    private float lifetime;
    
    public void ActivateProjectile()
    {
        lifetime = 0;
        gameObject.SetActive(true);
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        //transform.right = Vector2.Lerp(transform.position, target.position - transform.position, turnSpeed * Time.deltaTime);

        lifetime += Time.deltaTime;
        if (lifetime > resetTime)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            base.OnTriggerEnter2D(collision);
            gameObject.SetActive(false);
        }
    }
}
