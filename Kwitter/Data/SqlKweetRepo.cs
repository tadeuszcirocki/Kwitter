﻿using Kwitter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kwitter.Data
{
    public class SqlKweetRepo : IKweetRepo
    {
        private readonly DatabaseContext _context;

        public SqlKweetRepo(DatabaseContext context)
        {
            _context = context;
        }

        public void CreateKweet(Kweet kweet)
        {
            if (kweet == null)
            {
                throw new ArgumentNullException(nameof(kweet));
            }
            kweet.Created = DateTime.Now;
            kweet.LikeQuantity = 0;

            _context.Kweets.Add(kweet);
        }

        public IEnumerable<Kweet> GetAllKweets()
        {
            return _context.Kweets.ToList();
        }

        public Kweet GetKweetById(int id)
        {
            return _context.Kweets.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public ICollection<Comment> GetKweetByIdComments(int id)    //naming comes from GET kweet/{id}/comments
        {
            Kweet kweet = _context.Kweets.FirstOrDefault(p => p.Id == id);
            return _context.Comments.Where(p => p.KweetId == kweet.Id).ToList();
        }

        public void UpdateKweet(Kweet kweet)
        {
            //Nothing
        }

        public void DeleteKweet(Kweet kweet)
        {
            if (kweet == null)
            {
                throw new ArgumentNullException(nameof(kweet));
            }
            _context.Kweets.Remove(kweet);
        }

        public User GetUserOfKweet(int id)
        {
            var userId = _context.Kweets.FirstOrDefault(p => p.Id == id).UserId;
            return _context.Users.FirstOrDefault(i => i.Id == userId);
        }

        public void AddLike(int id)
        {
            _context.Kweets.FirstOrDefault(p => p.Id == id).LikeQuantity += 1;
        }
    }
}
