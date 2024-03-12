using System;
using System.Collections.Generic;

public class Board
{
    public List<BoardObject> objs;
    public List<Player> players;
    public List<Map> maps;

    public Board()
    {
        objs = new List<BoardObject>();
        players = new List<Player>();
        maps = new List<Map>();
    }

    public void BroadcastMessage(string msg)
    {
        UnityEngine.Debug.Log(msg);
    }

    public void AddPlayer(Player p)
    {
        players.Add(p);
    }

    public void RemovePlayer(Player p)
    {
        players.Remove(p);
    }

    public void AddBoardObject(BoardObject o)
    {
        objs.Add(o);
    }

    public void RemoveBoardObject(BoardObject o)
    {
        objs.Remove(o);
    }

    public void LoadMap(Map m)
    {

    }
}