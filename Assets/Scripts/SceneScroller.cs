using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

// Author: Zheyuan Gao
namespace GaoZheyuan.Lab6
{
    public class SceneScroller : MonoBehaviour
    {
        [SerializeField] private GameObject scene1;
        [SerializeField] private GameObject scene2;
        [SerializeField] private GameObject scene3;
        [SerializeField] private GameObject scene4;
        [SerializeField] private GameObject scene5;
        [SerializeField] private GameObject scene6;
        [SerializeField] private GameObject player;
        private Vector3 scene6InitialPosiiton;
        private float sceneMoveSpeed = -4f;
        private float sceneRespawnOffset = 18f;

        private void Start()
        {
            scene6InitialPosiiton = scene6.transform.position;

        }

        private void Update()
        {
            if (!SparrowBehavior.gameOver)
            {
                // Move the different game scene towards the player, make the player looks like 
                // flying forward
                scene1.transform.position += new Vector3(0, 0, sceneMoveSpeed * Time.deltaTime);
                scene2.transform.position += new Vector3(0, 0, sceneMoveSpeed * Time.deltaTime);
                scene3.transform.position += new Vector3(0, 0, sceneMoveSpeed * Time.deltaTime);
                scene4.transform.position += new Vector3(0, 0, sceneMoveSpeed * Time.deltaTime);
                scene5.transform.position += new Vector3(0, 0, sceneMoveSpeed * Time.deltaTime);
                scene6.transform.position += new Vector3(0, 0, sceneMoveSpeed * Time.deltaTime);

                // Move the scene at the right side of the game so that the world is infinite
                if (scene1.transform.position.z < player.transform.position.z - sceneRespawnOffset)
                {
                    scene1.transform.position = scene6InitialPosiiton;
                }
                else if (scene2.transform.position.z < player.transform.position.z - sceneRespawnOffset)
                {
                    scene2.transform.position = scene6InitialPosiiton;
                }
                else if (scene3.transform.position.z < player.transform.position.z - sceneRespawnOffset)
                {
                    scene3.transform.position = scene6InitialPosiiton;
                }
                else if (scene4.transform.position.z < player.transform.position.z - sceneRespawnOffset)
                {
                    scene4.transform.position = scene6InitialPosiiton;
                }
                else if (scene5.transform.position.z < player.transform.position.z - sceneRespawnOffset)
                {
                    scene5.transform.position = scene6InitialPosiiton;
                }
                else if (scene6.transform.position.z < player.transform.position.z - sceneRespawnOffset)
                {
                    scene6.transform.position = scene6InitialPosiiton;
                }
            }

        }
    }
}