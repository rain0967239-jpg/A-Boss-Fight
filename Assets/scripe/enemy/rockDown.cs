using UnityEngine;

public class rockDown : enemy__damage
{
    [SerializeField] private float speed;
    [SerializeField] private float resetTime;

    private float lifetime;

    public void ActivateProjectile()
    {
        lifetime = 0;
        gameObject.SetActive(true);
    }
    private void Update()
    {
        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(0, -movementSpeed, 0);

        lifetime += Time.deltaTime;
        if (lifetime > resetTime)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        gameObject.SetActive(false);
    }
}
