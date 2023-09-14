using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

// Author: Zheyuan Gao
namespace GaoZheyuan.Lab6
{
    /*
     * Generate the pipes as obstacles in the game
     */
    public class PipeGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject PipeSetPrefab;
        [SerializeField] private GameObject player;
        private int pipeCount = 20;
        private float pipeSpacing = 8f;
        private float pipeSpeed = -4f;
        private float spawnDelay = 2f;
        private float spawnOffset = 10f;

        private float spawnZ = -3f;
        private float spawnX = 10f;
        private float minY = 1f;
        private float maxY = 7.5f;

        //Dispay the score as the number of obstacle passed
        public static int score = 0;

        private void Start()
        {
           // Spawn the initial set of pipes
           for(int i = 0; i < pipeCount; i++)
            {
                SpawnPipeSets();
            }

        }

        private void Update()
        {
            if (!SparrowBehavior.gameOver)
            {
                foreach (Transform pipeSet in transform)
                {
                    // Move the pipesets towards the player
                    pipeSet.position += new Vector3(0f, 0f, pipeSpeed * Time.deltaTime);

                    //Check if the pipeset passes the player and respawn the sets at its initial position
                    if (pipeSet.position.z < player.transform.position.z - spawnDelay)
                    {
                        score++;
                        Debug.Log("Score: " + score);
                        pipeSet.position = new Vector3(spawnX, Random.Range(minY, maxY), spawnZ - spawnOffset);
                    }
                }
            }
        }

        private void SpawnPipeSets()
        {
            // Spawn a new pipe sets at its initial position
            Vector3 spawnPos = new Vector3(spawnX, Random.Range(minY, maxY), spawnZ);
            GameObject newPipeSets = Instantiate(PipeSetPrefab, spawnPos, Quaternion.identity, transform);

            //Update the spawn position
            spawnZ += pipeSpacing;
        }
    }
}
