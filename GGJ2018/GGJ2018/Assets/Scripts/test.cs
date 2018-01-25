/*using UnityEngine;
using System.Collections;

public class test : MonoBehaviour
{
    private Vector3 initialPosition;
    // Use this for initialization
    void Start()
    {
        initialPosition = transform.position;
        GameManager.OnLevelFail += () => {
            ReplaceCube();
        };
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            GameManager.singleton.LevelFail();
        }
        
    }

    public void ReplaceCube()
    {
        transform.position = initialPosition;
    }
}*/
