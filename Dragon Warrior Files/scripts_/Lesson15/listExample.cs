using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class listExample : MonoBehaviour
{
    [SerializeField] private List<int> myList;
    // Start is called before the first frame update
    void Start()
    {
        myList.Add(1);
        myList.Add(23);
        myList.Add(33);

        foreach (var item in myList)
        {
            Debug.Log(item);
        }

        Debug.Log("______________________________");


    }

    // Update is called once per frame
    void Update()
    {

    }
}
