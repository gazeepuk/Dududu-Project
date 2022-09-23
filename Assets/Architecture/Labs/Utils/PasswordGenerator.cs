using UnityEngine;

public class PasswordGenerator
{
    public static char GenerateSymbol(int[] asciiCodes) => (char)Random.Range(asciiCodes[0], asciiCodes[1]);
}
