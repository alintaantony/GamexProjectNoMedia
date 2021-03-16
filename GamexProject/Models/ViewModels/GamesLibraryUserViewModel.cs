using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamexProject.Models.ViewModels
{
    public class GamesLibraryUserViewModel
    {
        public GamesLibraryUserViewModel()
        {

        }
        public GamesLibraryUserViewModel(string gameId,string gameName,double? gameResaleValue,string username,int? inLibraryGameStatus)
        {
            GameId = gameId;
            GameName = gameName;
            GameResaleValue = gameResaleValue;
            Username = username;
            InLibraryGameStatus = inLibraryGameStatus;
        }
        public string GameId { get; set; }
        public string GameName { get; set; }
        public Nullable<double> GameResaleValue { get; set; }
        public string Username { get; set; }
        public Nullable<int> InLibraryGameStatus { get; set; }
    }
}