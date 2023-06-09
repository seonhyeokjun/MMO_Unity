using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Input = UnityEngine.Windows.Input;

public class Managers : MonoBehaviour
{
    static Managers s_instance; // 유일성이 보장된다.

    // 유일한 매니저를 갖고온다.
    static Managers Instance
    {
        get
        {
            init();
            return s_instance;
        }
    }

    InputManager _input = new InputManager();
    ResourceManager _resource = new ResourceManager();
    private UIManager _ui = new UIManager();

    public static InputManager Input { get { return Instance._input; } }
    public static ResourceManager Resource { get { return Instance._resource; } }
    public static UIManager UI { get { return Instance._ui; } }
    
    void Start()
    {
        init();
    }

    void Update()
    {
        _input.OnUpdate();
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
