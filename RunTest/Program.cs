using static GameWiki.Core.DataAccess;

namespace RunTest { 
static class Program
{
    public static void Main(string[] args)
    {
            string query = "USE [GAMEAPP] EXEC dbo.GET_GAME_LIST";
            string connection = "Data Source=(local);Integrated Security=sspi";
            string returnInfo;
            returnInfo = CreateCommand(query, connection);
            Console.Write(returnInfo);
    }
}
}