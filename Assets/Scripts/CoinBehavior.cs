using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GaoZheyuan.Lab6
{
    public class CoinBehavior : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed = 25f;
        private Vector3 startPosition;
        /*
         *  Play a sound 
         */
        private bool collected = false;

        private void Start()
        {
            startPosition = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            if (!collected)
            {
                // Rotate around the y-axis
                transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
            }
        }
    }
}
