using System.Collections.Generic;

namespace _Source.UI
{
    [System.Serializable]
    public class CardData
    {
        public string Name;
    }
    
    [System.Serializable]
    public class CardListWrapper
    {
        public List<CardData> cards;
    }
}