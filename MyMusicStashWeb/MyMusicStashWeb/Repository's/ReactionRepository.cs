﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyMusicStashWeb.database_Acces_layer;
using MyMusicStashWeb.Database_Acces_Layer;
using MyMusicStashWeb.Interfaces;
using MyMusicStashWeb.Models;

namespace MyMusicStashWeb
{
    public class ReactionRepository
    {
        private IReactionSqlContext context;

        public ReactionRepository(IReactionSqlContext context)
        {
            this.context = context;
        }

        public List<Reaction> GetSpecificReactions(int postId)
        {
            return this.context.GetSpecificReactions(postId);
        }

        public List<Reaction> GetAllReactions()
        {
            return this.context.GetAllReactions();
        }

        public bool InsertReaction(Reaction reaction)
        {
            return this.context.InsertReaction(reaction); 
        }

        public bool DeleteReaction(Reaction reaction)
        {
            return this.context.DeleteReaction(reaction);
        }

        public bool EditReaction(Reaction reaction)
        {
            return this.context.EditReaction(reaction); 
        }



    }
}