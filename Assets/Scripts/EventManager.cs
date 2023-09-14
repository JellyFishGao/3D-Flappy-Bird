using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Author: Zheyuan Gao
namespace GaoZheyuan.Lab6
{
    public class EventManager : MonoBehaviour
    {

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Display the game over text when the event is triggered
        private void OnGUI()
        {
            if (SparrowBehavior.gameOver)
            {
                GUIStyle style = new GUIStyle();
                style.fontSize = 40;
                GUI.Label(new Rect(Screen.width / 8 + 30, Screen.height / 2 - 50, 100, 20),
                    "Game Over!", style);
                GUI.Label(new Rect(Screen.width / 8 + 30, Screen.height / 2 + 10, 100, 20),
                    $"Final Score: {PipeGenerator.score}", style);
            }
            /*
             * Add a Score and floating score points to the screen
             */
            else
            {
                GUIStyle style = new GUIStyle();
                style.fontSize = 30;
                GUI.Label(new Rect(Screen.width / 8 - 30, Screen.height / 2 - 50, 100, 20),
                    $"Score: {PipeGenerator.score}", style);
                style.fontSize = 20;
                GUI.Label(new Rect(Screen.width / 8 - 30, Screen.height / 2 - 100, 100, 20),
                    "Press Space key to jump ", style);

            }
        }

        // Update is called once per frame
        void Update()
        {
 
        }
    }
}
