using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnActor : MonoBehaviour
{
    [SerializeField] private GameObject spawnActor;
    ParticleSystem m_ParticleSystem;
    private float spawnDelay;


    private void Awake()
    {
        m_ParticleSystem = GetComponent<ParticleSystem>();
    }
    private void Start()
    {
        spawnDelay = m_ParticleSystem.main.duration;
        StartCoroutine(Process());
    }

    private IEnumerator Process()
    {
        yield return new WaitForSeconds(spawnDelay); 
        Instantiate(spawnActor, transform.position, Quaternion.Euler(0,0,0));
    }

}
                                                                         