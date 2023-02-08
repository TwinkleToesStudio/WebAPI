using GameWiki.Host.Interfaces;
using GameWiki.Host.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameWiki.Core.DataAccess;

namespace GameWiki.Host
{
    internal class CoreCommand : ICoreCommand
    {
        //implement get, set, update functions comming from app

        //remove game from wiki
        public string removeGame(string gameName)
        {
            
            throw new NotImplementedException();
        }

        //return games for wiki homepage
        public string returnGameList()
        {
            string query = "USE [GAMEAPP] EXEC [dbo].[GET_GAME_LIST]";
            string connection = Constants.CONNECTION_STRING;
            string returnInfo;
            returnInfo = CreateCommand(query, connection);
            return returnInfo;
        }

        //update game to wiki
        public string updateGame(string gameName)
        {
            throw new NotImplementedException();
        }

        //update game to wiki
        public string addGame(string gameName)
        {
            throw new NotImplementedException();
        }
    }
}
