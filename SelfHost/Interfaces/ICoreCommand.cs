using System;

namespace GameWiki.Host.Interfaces
{
    public interface ICoreCommand
    {
        public string returnGameList();
        public string updateGame(int id, string newName);
        public string removeGame(int id);
        public string addGame(int id, string name, string description);
        public string returnGame(int id);
    }
}
