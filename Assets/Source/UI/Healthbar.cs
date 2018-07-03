using UnityEngine;

namespace DAZ4.UI
{
    public class Healthbar : MonoBehaviour
    {
        
        [SerializeField]
        private Color backgroundFill;

        [SerializeField]
        private Color foregroundFill;

        [SerializeField]
        private Rect shape;

        private float percentage = 1;
        private Texture2D backgroundTexture;
        private Texture2D foregroundTexture;
        private GUIStyle backgroundStyle;
        private GUIStyle foregroundStyle;

        public float Percent
        {
            get
            {
                return percentage;
            }

            set
            {
                percentage = Mathf.Clamp(value, 0, 1);
            }
        }

        protected virtual void OnGUI()
        {
            //shape.x = gameObject.transform.position.x;
            //shape.y = gameObject.transform.position.y;

            backgroundTexture = CreateTexture(backgroundFill);
            backgroundStyle = new GUIStyle();
            backgroundStyle.normal.background = backgroundTexture;

            foregroundTexture = CreateTexture(foregroundFill);
            foregroundStyle = new GUIStyle();
            foregroundStyle.normal.background = foregroundTexture;

            GUI.Box(shape, GUIContent.none, foregroundStyle);
        }

        private Texture2D CreateTexture(Color color)
        {
            Texture2D texture = new Texture2D(1, 1);

            texture.SetPixel(0, 0, color);
            texture.Apply();

            return texture;
        }
    }
}