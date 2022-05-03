using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteRoom : MonoBehaviour
{
    [SerializeField] private Button button;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(KillRoom);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void KillRoom()
    {
        Destroy(transform.parent.parent.gameObject);
        transform.parent = null;
    }
}
