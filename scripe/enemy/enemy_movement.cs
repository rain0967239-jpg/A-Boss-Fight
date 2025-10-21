using UnityEngine;
using UnityEngine.Events;

public class enemy_movement : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [Header("move")]
    [SerializeField] private float speed;
    [SerializeField] private Transform enemy;
    [Header("patrolPoint")]
    [SerializeField] private Transform firstEdge;
    [SerializeField] private Transform secondEdge;
    [SerializeField] private Transform thirdEdge;
    [SerializeField] private Transform forthEdge;
    [SerializeField] private Transform centralEdge;
    [Header("Idel Behaviour")]
    [SerializeField] private float idleDuration;
    [Header("attacking")]
    [SerializeField] UnityEvent shoot;
    [SerializeField] UnityEvent lazer;
    private float idleTimer;
    private int position = 0;
    private int positionLast;

    private void Update()
    {
        if (enemy.position.x == centralEdge.position.x)
            shoot?.Invoke();
        positionChange();
    }
    private void positionChange()
    {
        idleTimer += Time.deltaTime;
        do
        {
            positionLast = position;
            position = Random.Range(0, 5);
        }while (positionLast == position);

        if (idleTimer > idleDuration)
        {
            switch (position)
            {
                case 0:
                    idleTimer = 0;
                    transform.position = firstEdge.position;
                    break;
                case 1:
                    idleTimer = 0;
                    transform.position = secondEdge.position;
                    break;
                case 2:
                    idleTimer = 0;
                    transform.position = thirdEdge.position;
                    break;
                case 3:
                    idleTimer = 0;
                    transform.position = forthEdge.position;
                    break;
                case 4:
                    idleTimer = 0;
                    transform.position = centralEdge.position;
                    break;
            }
                
        }
    }
}
