using UnityEngine;
using System;

public class BoardObject
{
    public GameObject model; // Placeholder
    public Transform tf;
    public BoardObjectState state;

    public BoardObject()
    {
        state = BoardObjectState.NORMAL;
    }
}

public enum BoardObjectState
{
    NORMAL
};