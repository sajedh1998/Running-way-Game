using UnityEngine;

namespace UI
{
    public class MouseCursor : MonoBehaviour
    {
        public Texture2D cursorImage;
        public Vector2 hotspot;

        void Start()
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            ChangeCursour(cursorImage);
        }

        void ChangeCursour(Texture2D cursorType)
        {
            hotspot = new Vector2(cursorType.width / 3, cursorType.height / 3);
            Cursor.SetCursor(cursorType, hotspot, CursorMode.Auto);
        }
    }
}