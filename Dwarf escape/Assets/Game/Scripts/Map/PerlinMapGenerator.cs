using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinMapGenerator : MonoBehaviour
{
	Dictionary<int, GameObject> tileset;
	Dictionary<int, GameObject> tile_groups;

	[SerializeField] private GameObject[] tileTypes;
	
	[SerializeField] int mapWidth = 160;
	[SerializeField] int mapHeight = 90;

	// recommend 4 to 20
	[SerializeField]float magnification = 7.0f;

	int x_offset = 0; // <- +>
	int y_offset = 0; // v- +^

    void Start()
    {
        CreateTileset();
        CreateTileGroups();
        GenerateMap();
    }

    void CreateTileset()
    {
    	tileset = new Dictionary<int, GameObject>();
        for (int i = 0; i < tileTypes.Length; i++)
        {
	        tileset.Add(i, tileTypes[i]);
        }
    }

    void CreateTileGroups()
    {
    	tile_groups = new Dictionary<int, GameObject>();
    	foreach(KeyValuePair<int, GameObject> prefabPair in tileset)
    	{
    		GameObject tileGroup = new GameObject(prefabPair.Value.name);
    		tileGroup.transform.parent = gameObject.transform;
    		tileGroup.transform.localPosition = new Vector3(0, 0, 0);
    		tile_groups.Add(prefabPair.Key, tileGroup);
    	}
    }

    void GenerateMap()
    {
	    for(int x = 0; x < mapWidth; x++)
    	{
    		for(int y = 0; y < mapHeight; y++)
    		{
    			int tile_id = GetIdUsingPerlin(x, y);
    			CreateTile(tile_id, x, y);
    		}
    	}
    }

    int GetIdUsingPerlin(int x, int y)
    {
	    float rawPerlin = Mathf.PerlinNoise(
    		(x - x_offset) / magnification,
    		(y - y_offset) / magnification
    	);
    	float clampPerlin = Mathf.Clamp01(rawPerlin);
    	float scaledPerlin = clampPerlin * tileset.Count;

		
    	if(scaledPerlin == tileset.Count)
    	{
    		scaledPerlin = (tileset.Count - 1);
    	}
    	return Mathf.FloorToInt(scaledPerlin);
    }

    void CreateTile(int tile_id, int x, int y)
    {
	    GameObject tile_prefab = tileset[tile_id];
    	GameObject tile_group = tile_groups[tile_id];
    	GameObject tile = Instantiate(tile_prefab, tile_group.transform);

    	tile.name = string.Format("tile_x{0}_y{1}", x, y);

        
        
    	tile.transform.localPosition = new Vector3( x - (mapWidth * 0.5f) , y - (mapHeight * 0.5f), 0);

    }
}