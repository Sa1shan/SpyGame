using System;
using _Source.GameOptionsMenu;
using UnityEngine;

namespace _Source.PlayerCard
{
    public class PlayerCard : MonoBehaviour
    {
        [SerializeField] private int receivedScore;

        private void Update()
        {
            receivedScore = PlayersCountTracker.Instance.GetCurrentCount();
        }
    }
}