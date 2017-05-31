using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyMusicStashWeb.database_Acces_layer;
using MyMusicStashWeb.Database_Acces_Layer;
using MyMusicStashWeb.Interfaces;

namespace MyMusicStashWeb
{
    public class ReactionRepository
    {
        private IReactionSqlContext context;

        public ReactionRepository(IReactionSqlContext context)
        {
            this.context = context;
        }
    }
}