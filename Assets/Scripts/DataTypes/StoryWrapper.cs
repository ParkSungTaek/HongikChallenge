using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Story
{
    public string Script = "";
    public Define.ActionData Action = Define.ActionData.None;
    public int To = -1;
}

public class StoryWrapper 
{
    Dictionary<int,List<Story>>[] stories = new Dictionary<int,List<Story>>[(int)Define.StoryInteractOBJs.MaxCount];

    public Dictionary<int, List<Story>> this[Define.StoryInteractOBJs idx]
    {
        get {
            if (stories[(int)idx] == null)
            {
                stories[(int)idx] = new Dictionary<int, List<Story>>(); 
            }
            return stories[(int)idx]; 
        }

        //get => stories[(int)idx];
    }

}
