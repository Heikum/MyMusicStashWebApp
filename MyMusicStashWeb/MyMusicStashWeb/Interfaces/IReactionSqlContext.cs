using System.Collections.Generic;
using MyMusicStashWeb.Models;

namespace MyMusicStashWeb.Interfaces
{
    public interface IReactionSqlContext
    {
        List<Reaction> GetSpecificReactions(int postId);
        List<Reaction> GetAllReactions();
        bool InsertReaction(Reaction reaction);
        bool DeleteReaction(Reaction reaction);
        bool EditReaction(Reaction reaction);
    }
}