using UnityEngine;

public class enemy__damage : MonoBehaviour
{
    [SerializeField] protected float damage;

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<health>().TakeDamage(damage);
            Debug.Log("hurt");
        }
    }
}
