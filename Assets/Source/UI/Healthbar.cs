using UnityEngine;
using DAZ4.Creatures;

namespace DAZ4.UI
{
    public class Healthbar : MonoBehaviour
    {
        private float percentage = 1;

        private SpriteRenderer background;
        private SpriteRenderer fill;
        private CreatureStats stats;

        public GameObject Owner;

        public float Percentage
        {
            get
            {
                return percentage;
            }

            set
            {
                percentage = Mathf.Clamp(value, 0, 1);
                fill.transform.localScale = new Vector3(percentage, fill.transform.localScale.y);
            }
        }

        protected void Start()
        {
            background = transform.Find("Background").GetComponent<SpriteRenderer>();
            fill = transform.Find("Fill").GetComponent<SpriteRenderer>();

            if (Owner)
            {
                stats = Owner.GetComponent<CreatureStats>();
            }
        }

        protected void Update()
        {
            if (stats)
            {
                Debug.Log(stats.Health);
                Debug.Log(stats.MaxHealth);
                Debug.Log((float)stats.Health / (float)stats.MaxHealth);
                percentage = (float)stats.Health / (float)stats.MaxHealth;
            }

            transform.position = Owner.transform.position;
        }
    }
}