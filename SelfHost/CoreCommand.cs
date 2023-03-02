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
        string connection = Constants.CONNECTION_STRING;
        string returnInfo;
        //remove game from wiki
        public string removeGame(int id)
        {
            throw new NotImplementedException();
        }

        //return games for wiki homepage
        public string returnGameList()
        {
            string query = "USE [GAMEAPP] EXEC [dbo].[GET_GAME_LIST]";
            returnInfo = CreateCommand(query, connection);
            return returnInfo;
        }

        //return games for wiki homepage
        public string returnGame(int id)
        {
            string query = "USE [GAMEAPP] EXEC [dbo].[GET_GAME] " + id;
            returnInfo = CreateCommand(query, connection);
            returnInfo = returnInfo.Substring(1, returnInfo.Length-2);
            return returnInfo;
        }

        //update game to wiki
        public string updateGame(int id, string newName)
        {
            string query = "USE [GAMEAPP] EXEC [dbo].[UPDATE_GAME] " + id + ", '" + newName + "'";
            returnInfo = CreateCommand(query, connection);
            return returnInfo;
        }

        //update game to wiki
        public string addGame(int id, string name, string description)
        {
            throw new NotImplementedException();
        }
    }
}
