using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Tile Type")]
public class TileNodeData : ScriptableObject
{
    public Sprite defaultRockSprite;
    public GameObject property;
    public ParticleSystem particle;
    public int durability;

}
