﻿using Kwitter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kwitter.Data
{
    public class SqlCommentRepo : ICommentRepo
    {
        private readonly DatabaseContext _context;

        public SqlCommentRepo(DatabaseContext context)
        {
            _context = context;
        }

        public void CreateComment(Comment comment)
        {
            if (comment == null)
            {
                throw new ArgumentNullException(nameof(comment));
            }
            comment.Created = DateTime.Now;
            comment.LikeQuantity = 0;
            
            _context.Comments.Add(comment);
        }

        public void DeleteComment(Comment comment)
        {
            if (comment == null)
            {
                throw new ArgumentNullException(nameof(comment));
            }
            _context.Comments.Remove(comment);
        }

        public IEnumerable<Comment> GetAllComments()
        {
            return _context.Comments.ToList();
        }

        public Comment GetCommentById(int id)
        {
            return _context.Comments.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateComment(Comment comment)
        {
           //Nothing
        }
        public IEnumerable<Comment> GetCommentsByPostId(int postId)
        {
            return _context.Comments.Where(i => i.KweetId == postId).ToList();
        }

        public User GetUserOfComment(int id)
        {
            var userId = _context.Comments.FirstOrDefault(p => p.Id == id).UserId;
            return _context.Users.FirstOrDefault(i => i.Id == userId);
        }
        public void AddLike(int id)
        {
            _context.Comments.FirstOrDefault(p => p.Id == id).LikeQuantity += 1;
        }
    }
}
