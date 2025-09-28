using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class Lazer : enemy__damage
{
    [SerializeField] private Transform target;
    [SerializeField] private float resetTime;
    private float lifetime;
    private BoxCollider2D BoxCollider2D;

    private void Awake()
    {
        BoxCollider2D = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        
        lifetime += Time.deltaTime;
        if (lifetime > resetTime)
        {
            gameObject.SetActive(false);
        }
    }
    public void ActivateLazer()
    {
        Vector2 direction = target.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            base.OnTriggerEnter2D(collision);
            gameObject.SetActive(false);
            BoxCollider2D.enabled = false;
        }
    }
}
