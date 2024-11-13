using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionaryExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Dictionary<key,Values> key tương ứng vói values
        Dictionary<string, int> myDictionary = new Dictionary<string, int>();
        myDictionary.Add("apple", 1);
        myDictionary.Add("coconote", 4);
        myDictionary.Add("bnanner", 5);

        Debug.Log("______________________________");    


    }

    // Update is called once per frame
    void Update()
    {

    }
}
