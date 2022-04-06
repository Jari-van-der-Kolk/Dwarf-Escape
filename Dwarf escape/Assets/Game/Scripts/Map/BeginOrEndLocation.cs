using UnityEngine;

[System.Serializable]
public class BeginOrEndLocation
{
    public BeginOrEndLocation(GameObject beginPrefab, GameObject endPrefab, Vector2 location, Directions direction)
    {
        this.beginPrefab = beginPrefab;
        this.endPrefab = endPrefab;
        this.direction = direction;
        this.location = location;
    }

    public GameObject beginPrefab;
    public GameObject endPrefab;
    public Directions direction;
    public Vector2 location;
}

public enum Directions
{
    Up,
    Down,
    Left,
    Right
};