using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platform
{
    public class PlatformMovement : MonoBehaviour
    {
        [SerializeField] private GameObject[] wayPoints;
        [SerializeField] private float speed = 2f;
        private int currentIndex;

        private void Update()
        {
            Movement();
        }

        private void Movement()
        {
            if (Vector2.Distance(wayPoints[currentIndex].transform.position, transform.position) < 0.1f)
            {
                currentIndex++;
                if (currentIndex >= wayPoints.Length)
                {
                    currentIndex = 0;
                }
            }
            transform.position = Vector2.MoveTowards(transform.position, wayPoints[currentIndex].transform.position, Time.deltaTime * speed);
        }
    }
}