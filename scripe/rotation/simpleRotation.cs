using System.Collections;
using UnityEngine;

public class simpleRotation : MonoBehaviour
{
    public float RotationAmount = 2f;
    public int TicksPerSecond = 60;
    public bool Pause = false;
    private void Start()
    {
        StartCoroutine(Rotate());
    }
    private IEnumerator Rotate()
    {
        WaitForSeconds wait = new WaitForSeconds(1f / TicksPerSecond);

        while (true)
        {
            if (!Pause)
                transform.Rotate(Vector3.up * RotationAmount);
        }
        yield return wait;
    }
}
