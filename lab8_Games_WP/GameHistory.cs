using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lab8_Games_WP
{
    public static class GameHistory
    {
        public static List<string> History = new();

        public static void AddHistory(string text)
        {
            History.Add(text);
        }

        public static void ClearHistory()
        {
            History.Clear();
        }
    }
}
