using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UpdateNavMesh : MonoBehaviour
{
    private NavMeshSurface surface2d;

    private void Awake()
    {
        surface2d = GetComponent<NavMeshSurface>();
    }

    private void Start()
    {
        GameEvents.instance.onBlockDestroyed += UpdateMesh;
    }

    private void UpdateMesh()
    {
        surface2d.UpdateNavMesh(surface2d.navMeshData);
    }

}
