using UnityEngine;

// Author: Zheyuan Gao
namespace GaoZheyuan.Lab6
{
    class FollowWithOffset : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 offset;
        private void Update()
        {
            // Make the camera follow the player with offset
            transform.position = target.transform.position + offset;
        }
    }
}
