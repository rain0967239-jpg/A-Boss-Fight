using UnityEngine;

public class health : MonoBehaviour
{
    [SerializeField] private float stratingHealth;
    public float currentHealth {  get; private set; }
    private Animator anim;
    private bool dead;

    [Header("components")]
    [SerializeField] private Behaviour[] components;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        currentHealth = stratingHealth;
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, stratingHealth);
        
        if(currentHealth > 0)
        {
            anim.SetTrigger("hurt");
            //ifram
        }
        else
        {
            if (!dead) 
            {
                
                anim.SetTrigger("die");
                
                foreach(Behaviour component in components)
                    component.enabled = false;

                dead = true;
            }
        }
    }
    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, stratingHealth);
    }
    public void Respawn()
    {
        dead = false;
        AddHealth(stratingHealth);
        anim.ResetTrigger("die");
        anim.Play("player_idle");
        GetComponent<PlayerMovement>().enabled = true;
        //foreach (Behaviour component in components)
        //component.enabled = true;
    }
}
