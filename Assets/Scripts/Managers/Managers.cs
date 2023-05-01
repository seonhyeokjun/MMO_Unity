using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Input = UnityEngine.Windows.Input;

public class Managers : MonoBehaviour
{
    static Managers s_instance; // 유일성이 보장된다.

    // 유일한 매니저를 갖고온다.
    public static Managers Instance
    {
        get
        {
            init();
            return s_instance;
        }
    }  
    
    // Start is called before the first frame update
    void Start()
    {
        init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static void init()
    {
        if (s_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if (go == null)
            {
                go = new GameObject {name = "@Managers"};
                go.AddComponent<Managers>();
            }
            
            DontDestroyOnLoad(go);
            s_instance = go.GetComponent<Managers>();
        }
    }
}
