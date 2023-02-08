using System;

namespace GameWiki.Host.Interfaces
{
    public interface ICoreCommand
    {
        public string returnGameList();
        public string updateGame(string gameName);
        public string removeGame(string gameName);
        public string addGame(string gameName);
    }
}
