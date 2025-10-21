using UnityEngine;

public class enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D BoxCollider;
    private CircleCollider2D CircleCollider;
    private Animator anim;

    [SerializeField] private float Speed;
    [SerializeField] private Transform self;
    [Header("lazer")]
    [SerializeField] private float LazerCoolDownTime;
    private float LazerCoolDown;
    private bool shootingLazer;
    [Header("stone")]
    [SerializeField] private float stoneCoolDownTime;
    private float stoneCoolDown;
    private bool shootingStone;
    [Header("patrolPoint")]
    [SerializeField] private Transform firstEdge;
    [SerializeField] private Transform secondEdge;
    [SerializeField] private Transform thirdEdge;
    [SerializeField] private Transform forthEdge;
    [SerializeField] private Transform centralEdge;
    [Header("Ranged Attack")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject[] rocks;
    [SerializeField] private Transform Lazerpoint;
    [SerializeField] private GameObject[] lazer;
    private void Awake()
    {
        BoxCollider = GetComponent<BoxCollider2D>();
        CircleCollider = GetComponent<CircleCollider2D>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (self.position == firstEdge.position || self.position == thirdEdge.position)
        {
            RangedAttack();
        }
        //shootStone
        if (self.position == secondEdge.position || self.position == forthEdge.position)
        {
            Lazer();
        }
        //lazer
        if (self.position == centralEdge.position)
        {
            BoxCollider.enabled = false;
        }
    }
    private int FindFireball()
    {
        for (int i = 0; i < rocks.Length; i++)
        {
            if (!rocks[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
    private void RangedAttack()
    {
        stoneCoolDown = 0;
        rocks[FindFireball()].transform.position = firepoint.position;
        rocks[FindFireball()].GetComponent<rock>().ActivateProjectile();
    }
    private int Findlazer()
    {
        for (int i = 0; i < lazer.Length; i++)
        {
            if (!lazer[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
    private void Lazer()
    {
        LazerCoolDown = 0;
        lazer[Findlazer()].transform.position = Lazerpoint.position;
        lazer[Findlazer()].GetComponent<Lazer>().ActivateLazer();
    }
}
