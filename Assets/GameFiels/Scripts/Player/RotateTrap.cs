using UnityEngine;

namespace Player
{
    public class RotateTrap : MonoBehaviour
    {
        // Variables
        [SerializeField] private float speed = 2f;
        private float timer = 0f;

        // Update is called once per frame
        private void Update()
        {
            Rotate();
        }

        // Rotate the trap based on the sine of the timer
        private void Rotate()
        {
            float angle = Mathf.Sin(timer) * 45f;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            timer += speed * Time.deltaTime;
        }
    }
}