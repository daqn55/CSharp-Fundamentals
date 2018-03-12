using Forum.App.UserInterface.ViewModels;
using Forum.Data;
using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forum.App.Services
{
    public class ReplyService
    {
        public static bool TrySaveReply(ReplyViewModel replyView)
        {
            bool emptyContent = !replyView.Content.Any();

            if (emptyContent)
            {
                return false;
            }

            ForumData forumData = new ForumData();

            int replyId = forumData.Replies.Any() ? forumData.Replies.Last().Id + 1 : 1;
            int postId = forumData.Posts.Any() ? forumData.Posts.Last().Id + 1 : 1;

            User author = UserService.GetUser(replyView.Author);

            int authorId = author.Id;
            string content = string.Join("", replyView.Content);

            Reply reply = new Reply(replyId, content, authorId, postId);

            forumData.Replies.Add(reply);
            author.PostIds.Add(postId);
            forumData.SaveChanges();

            return true;
        }
    }
}
