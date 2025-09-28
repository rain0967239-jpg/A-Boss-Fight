
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    [SerializeField] private health playerHealth;
    [SerializeField] private Image totalhealthbar;
    [SerializeField] private Image currenthealthBar;

    private void Start()
    {
        totalhealthbar.fillAmount = playerHealth.currentHealth / 5;
    }
    private void Update()
    {
        currenthealthBar.fillAmount = playerHealth.currentHealth / 5;
    }
}
