using System.Collections.Generic;

public class ItemParser 
{    
    public ItemInfo[] ParseFromJson(string json)
    {
        var result = JsonHelper.FromJson<ItemInfo>(json);
        return result;
    }

    [System.Serializable]
    public class ItemInfoList
    {
        public List<ItemInfo> Items;
    }
}
