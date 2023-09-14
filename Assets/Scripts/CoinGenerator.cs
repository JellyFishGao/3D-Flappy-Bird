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
    public class CoinGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject coinPrefab;
        [SerializeField] private GameObject player;
        private float coinSpacing = 8f;
        private float coinSpeed = -4f;
        private float destroyDelay = 2f;

        private float spawnZ = 0f;
        private float spawnX = 10f;
        private float minY = 1f;
        private float maxY = 7.5f;

        private void Start()
        {
            StartCoroutine(SpawnCoinCoroutine());
        }

        private IEnumerator SpawnCoinCoroutine()
        {
            while (!SparrowBehavior.gameOver)
            {
                // Spawn a coin every 3s if the game is not over
                SpawnCoin();
                yield return new WaitForSeconds(1.5f);
            }
        }

        private void Update()
        {
            if (!SparrowBehavior.gameOver)
            {
                foreach (Transform coin in transform)
                {
                    // Move the coins towards the player
                    coin.position += new Vector3(0f, 0f, coinSpeed * Time.deltaTime);

                    //Check if the coins passes the player and destry the coin 
                    if (coin.position.z < player.transform.position.z - destroyDelay)
                    {
                        Destroy(coin.gameObject);
                    }
                }                        
            }
        }

        private void SpawnCoin()
        {
            Vector3 spawnPos = new Vector3(spawnX, Random.Range(minY, maxY), spawnZ);
            GameObject newCoin = Instantiate(coinPrefab, spawnPos, Quaternion.identity, transform);
            //Update the spawn position
            spawnZ += coinSpacing;
        }
    }
}
