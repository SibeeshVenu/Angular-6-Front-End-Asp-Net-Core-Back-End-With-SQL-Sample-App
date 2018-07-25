using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Constants
{
    public static class ApiConstants
    {
        public static readonly string baseUrl = "https://newsapi.org/v2/";
        public static readonly string apiKey = "?apiKey=86717122ecab434ab6d43d80034f2498";
        public static readonly string getNews = "top-headlines?country=us";
        public static readonly string newsAlreadyExists = "News is already there in favorite list";
    }
}
