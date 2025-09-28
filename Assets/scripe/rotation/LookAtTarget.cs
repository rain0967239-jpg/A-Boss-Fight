using UnityEngine;
using System.Collections;

public class LookAtTarget : MonoBehaviour
{
    public Transform target;
    public float speed = 1f;

    private Coroutine LookCoroutine;

    public void StartRotating()
    {
        if (LookCoroutine != null)
            StopCoroutine(LookCoroutine);

        LookCoroutine = StartCoroutine(LookAt());
    }
    private IEnumerator LookAt()
    {
        Quaternion lookRotation = Quaternion.LookRotation(target.position - transform.position);

        float time = 0;

        while (time < 1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, time);

            time += Time.deltaTime * speed;

            yield return null;
        }
    }
    private void OnGUI()
    {
        if(GUI.Button(new Rect(10, 10, 200, 30), "Look At"))
            StartRotating();
            
    }
}
