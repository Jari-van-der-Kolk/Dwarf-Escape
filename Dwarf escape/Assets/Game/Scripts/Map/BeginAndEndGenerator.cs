using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(PerlinMapGenerator))]
public class BeginAndEndGenerator : MonoBehaviour
{
    private PerlinMapGenerator _perlinMapGenerator;

    [SerializeField] private GameObject beginPrefab;
    [SerializeField] private GameObject endPrefab;

    public List<BeginOrEndLocation> beginOrEndLocations;


    private void Awake()
    {
        _perlinMapGenerator = GetComponent<PerlinMapGenerator>();
    }
    
    private void Start()
    {
        GenerateGameLoopPositions();
    }

    private void GenerateGameLoopPositions()
    {
        List<BeginOrEndLocation> positions = new List<BeginOrEndLocation>();
        GeneratePositions(positions);
        GenerateStartPosition(positions);
        GenerateEndPosition(positions);
    }

    private void GeneratePositions( List<BeginOrEndLocation> positions)
    {
        positions.Add(AddPosition(beginPrefab, endPrefab, Vector2.down, _perlinMapGenerator.mapHeight / 2, Directions.Down));
        positions.Add(AddPosition(beginPrefab, endPrefab, Vector2.down, -_perlinMapGenerator.mapHeight / 2, Directions.Up));
        positions.Add(AddPosition(beginPrefab, endPrefab, Vector2.left, -_perlinMapGenerator.mapWidth / 2, Directions.Right));
        positions.Add(AddPosition(beginPrefab, endPrefab, Vector2.left, _perlinMapGenerator.mapWidth / 2, Directions.Left));
    }

    BeginOrEndLocation AddPosition(GameObject begin, GameObject end, Vector2 dir, int radius, Directions direction)
    {
        Vector3 pos = (transform.position + (Vector3) dir * 0.5f) + ((Vector3) dir * radius);
        return new BeginOrEndLocation(begin, end,pos, direction);
    }

    private void GenerateStartPosition( List<BeginOrEndLocation> positions)
    {
        int randomIndex = Random.Range(0, positions.Count);
        BeginOrEndLocation position = positions[randomIndex];
        CreateStartOrEndPosition(position.location, position.beginPrefab, position.direction);
        beginOrEndLocations.Add(position);
        positions.Remove(position);
    }

    private void GenerateEndPosition( List<BeginOrEndLocation> positions)
    {
        int randomIndex = Random.Range(0, positions.Count);
        BeginOrEndLocation position = positions[randomIndex];
        CreateStartOrEndPosition(position.location, position.endPrefab, position.direction);
        beginOrEndLocations.Add(position);
    }

    private void CreateStartOrEndPosition(Vector3 spawnPosition, GameObject beginOrEndPrefab, Directions direction)
    {
        switch (direction)
        {
            case Directions.Down:
                Instantiate(beginOrEndPrefab, spawnPosition, Quaternion.Euler(0, 0, 180));
                break;
            case Directions.Up:
                Instantiate(beginOrEndPrefab, spawnPosition, Quaternion.Euler(0, 0, 0));
                break;
            case Directions.Left:
                Instantiate(beginOrEndPrefab, spawnPosition, Quaternion.Euler(0, 0, 90));
                break;
            case Directions.Right:
                Instantiate(beginOrEndPrefab, spawnPosition, Quaternion.Euler(0, 0, 270));
                break;
        }
    }

    private void OnDrawGizmos()
    {
        if (_perlinMapGenerator == null)
            _perlinMapGenerator = GetComponent<PerlinMapGenerator>();

        Gizmos.color = Color.cyan;
        //Gizmos.DrawWireSphere(transform.position + (Vector3.down * 0.5f), _perlinMapGenerator.mapHeight / 2);
        //Gizmos.DrawWireSphere(transform.position + (Vector3.left * 0.5f), _perlinMapGenerator.mapWidth / 2);
        
        // om alle kanten te krijgen moet je 2 circels gebruiken inplaats van 2
    }
    
}
