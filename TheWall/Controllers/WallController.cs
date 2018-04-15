using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using TheWall.Models;
using Microsoft.AspNetCore.Http;
namespace TheWall.Controllers
{
    public class WallController: Controller
    {
        private readonly DbConnector _dbConnector;
        public WallController(DbConnector connect)
        {
            _dbConnector = connect;
        }

        [HttpGet, Route("")]
        public IActionResult Wall()
        {
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            ViewBag.UserId = (int?)HttpContext.Session.GetInt32("UserId");
            
            if(ViewBag.UserId != null)
            {
                var allMessagesQuery = _dbConnector.Query($"SELECT messages.id AS MessageId, MessageContext, messages.CreatedAt, messages.UpdatedAt, users.id as UserId, CONCAT(users.FirstName, ' ', users.LastName) AS FullName FROM messages JOIN users ON Users.id = messages.users_id ORDER BY CreatedAt DESC");

                var allCommentsQuery = _dbConnector.Query($"SELECT comments.id AS CommentId, CommentContext, users.id AS UserId, CONCAT(FirstName, ' ', LastName) AS Commenter, comments.messages_id AS MessageId, comments.CreatedAt FROM users JOIN comments ON comments.users_id = users.id");

                foreach(var message in allMessagesQuery)
                {
                    int MessageId = (int)message["MessageId"];
                    var messageComments = new List<CommentModel>();
                    foreach(var comment in allCommentsQuery)
                    {
                        if (MessageId == (int)comment["MessageId"])
                        {
                            
                            messageComments.Add(new CommentModel {
                                CommentId = (int)comment["CommentId"],
                                CommentContext = (string)comment["CommentContext"],
                                messages_id = (int)comment["MessageId"],
                                users_id = (int)comment["UserId"],
                                CommenterName = (string)comment["Commenter"],
                                CreatedAt = (DateTime)comment["CreatedAt"]
                            });
                        }
                    }
                    message["MessageComments"] = messageComments;

                }
                ViewBag.allMessages = allMessagesQuery;
            }
            else
            {
                return RedirectToAction("Login", "Users");
            }

            return View("Wall");
        }

        [HttpPost, Route("messages")]
        public IActionResult AddMessage(MessageModel message)
        {
            _dbConnector.Execute($"INSERT INTO Messages (MessageContext, CreatedAt, UpdatedAt, users_id) VALUES ('{message.MessageContext}', NOW(), NOW(), {message.users_id})");
            
            return RedirectToAction("Wall");
        }

        [HttpPost, Route("comments")]
        public IActionResult AddComment(CommentModel comment)
        {
            _dbConnector.Execute($"INSERT INTO comments (CommentContext, messages_id, users_id, CreatedAt, UpdatedAt) VALUES ('{comment.CommentContext}', '{comment.messages_id}', '{comment.users_id}', NOW(), NOW())");

            return RedirectToAction("Wall");
        }

        [HttpGet, Route("comments/delete/{commentId}")]
        public IActionResult DeleteComment(int commentId)
        {
            _dbConnector.Execute($"DELETE FROM comments WHERE id = {commentId}");
            return RedirectToAction("Wall");
        }

        [HttpGet, Route("messages/delete/{messageId}")]
        public IActionResult DeleteMessage(int messageId)
        {
            _dbConnector.Execute($"DELETE FROM comments WHERE messages_id = {messageId}");
            _dbConnector.Execute($"DELETE FROM messages WHERE id = {messageId}");
            return RedirectToAction("Wall");
        }
    }
}
