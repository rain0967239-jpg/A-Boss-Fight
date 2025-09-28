using UnityEngine;

public class playerAttack : MonoBehaviour
{
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float horizontalInput;
    private float verticalInput;
    [SerializeField] private float attackDistance;
    [SerializeField] protected float damage;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        if (horizontalInput != 0 )
            transform.localPosition = new Vector3(-attackDistance, 0, 0);
        else if (verticalInput > 0 )
            transform.localPosition = new Vector3(0 ,attackDistance , 0);
        else if (verticalInput < 0)
            transform.localPosition = new Vector3(0, -attackDistance, 0);
        if (Input.GetKeyDown("j"))
        {
            boxCollider.enabled = true;
            anim.SetBool("attack", true);
        }
    }
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemy")
        {
            collision.GetComponent<health>().TakeDamage(damage);
            Debug.Log("hurt");
        }
    }
    private void stopAttack()
    {
        anim.SetBool("attack", false);
        boxCollider.enabled = false;
    }
}
