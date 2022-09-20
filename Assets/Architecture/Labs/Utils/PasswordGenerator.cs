using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswordGenerator : MonoBehaviour
{
    public static char GenerateSymbol(int[] asciiCodes) => (char)Random.Range(asciiCodes[0], asciiCodes[1]);
}
