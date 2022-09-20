using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDictionary : MonoBehaviour
{
    public static Dictionary<string, int[]> ascii = new Dictionary<string, int[]>()
        {
            {"engLowerCase", new int[]{97,122}},
            {"engUpperCase", new int[]{65,90}},
            {"numbers", new int[]{48,57}},
            {"symbols", new int[]{33,42}}
        };
}
