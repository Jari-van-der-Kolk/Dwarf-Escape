using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Tile Type")]
public class TileNodeData : ScriptableObject
{
    public Sprite defaultRockSprite;
    public ParticleSystem particle;
    public int durability;
    public float spawnPrefabDelay = 0.3f;
    public GameObject SpawnPrefab;

}
