using UnityEngine;

public class Assets : MonoBehaviour {

    [SerializeField]
    private GameObject healthbar;

    private static Assets instance;

    public static GameObject Healthbar
    {
        get
        {
            return instance.healthbar;
        }
    }


    public Assets()
    {
        instance = this;
    }

}
