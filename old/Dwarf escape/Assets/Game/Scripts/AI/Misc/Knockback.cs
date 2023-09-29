using UnityEngine;
using UnityEngine.AI;

public class Knockback : Actor, IHitable
{
    [SerializeField] private float knockbackStrenth;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void Hit(int hitAmount)
    {
        agent.velocity = (playerLocation.position - transform.position).normalized * -knockbackStrenth; 
    }
}
