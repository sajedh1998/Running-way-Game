using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class RotateTrap : MonoBehaviour
    {
        [SerializeField] private float speed = 2f;
        float timer = 0;

        private void Update()
        {
            float angle = Mathf.Sin(timer) * 45;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            timer += (speed * Time.deltaTime);
        }
    }
}