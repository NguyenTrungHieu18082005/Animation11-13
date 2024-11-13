using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayListExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ArrayList myArrayList  = new ArrayList();
        myArrayList.Add(1);
        myArrayList.Add("hello");
        myArrayList.Add(3.234);
        
        foreach(var item in myArrayList){
            Debug.Log(item);
        }

        // for (int i = 0 ; i <myArrayList.Count ; i++){
        //     Debug.Log(myArrayList);
        // }

        Debug.Log("______________________________");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
