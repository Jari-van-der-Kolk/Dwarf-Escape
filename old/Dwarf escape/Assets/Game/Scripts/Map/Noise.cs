using Unity.Mathematics;
using UnityEngine;

namespace Game.Scripts.Map
{
    public class Noise
    {

        public static float[,] GenerateNoiseMap(int mapWidth, int mapHeight, Vector2 offset, float magnification, int varietyAmount)
        {
            float[,] noiseMap = new float[mapWidth, mapHeight];

            if (magnification <= 0)
            {
                magnification = 0.0001f;
            }

            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    float rawPerlin = Mathf.PerlinNoise
                    (
                        (x - offset.x) / magnification,
                        (y - offset.y) / magnification
                    );
                    float clampPerlin = Mathf.Clamp(rawPerlin, 0.0f, 1.0f);
                    float scalePerlin = clampPerlin * varietyAmount;
                    //TODO hier moet misschien een clamp check voor scalePerlin
                    scalePerlin = Mathf.FloorToInt(scalePerlin);
                    noiseMap[x, y] = scalePerlin;
                }
            }

            return noiseMap;
        }

    }
}
