using System;
using UnityEngine;

namespace Game.Scripts.Map
{
    public class MapGenerator : MonoBehaviour
    {
        public int mapHeight, mapWidth;
        public Vector2 offset;
        public float magnification;
        public int varietyAmount;

        private float[,] noiseMap;

        [SerializeField] private TileNodeData[] tileNodeData;

        private void Start()
        {
            GenerateMap();
        }

        public void GenerateMap()
        {
            noiseMap = Noise.GenerateNoiseMap(mapWidth, mapHeight, offset, magnification, varietyAmount);

            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    Debug.Log(noiseMap[x,y]);
                }
            }
        }

        public void PlaceTiles(int x, int y)
        {
            
        }
    }
}