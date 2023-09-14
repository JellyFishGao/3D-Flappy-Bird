using GaoZheyuan.Input;
using UnityEngine;

// Author: Zheyuan Gao
namespace GaoZheyuan.Lab6
{
    public class InputManager : MonoBehaviour
    {
        private PlayerInputActions inputScheme;
        [SerializeField] private SparrowBehavior sparrowBehavior;

        private void Awake()
        {
            inputScheme = new PlayerInputActions();
            sparrowBehavior.Initialize(inputScheme.Player.Fly);
        }
        private void OnEnable()
        {
            var _ = new QuitHandler(inputScheme.Player.Quit);
        }
    }
}

