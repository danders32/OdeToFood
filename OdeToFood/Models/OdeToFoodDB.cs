﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OdeToFood.Models
{

    public interface IOdeToFoodDb : IDisposable
    {
        IQueryable<T> Query<T>() where T : class;
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Remove<T>(T entity) where T : class;
        void SaveChanges();
    }


    public class OdeToFoodDB : DbContext, IOdeToFoodDb
    {
        public OdeToFoodDB()  : base("name=DefaultConnection")
        {

        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantReview> Reviews { get; set; }

        IQueryable<T> IOdeToFoodDb.Query<T>()
        {
            return Set<T>();
        }

        void IOdeToFoodDb.Add<T>(T entity)
        {
            Set<T>().Add(entity);
        }

        void IOdeToFoodDb.Update<T>(T entity)
        {
            Entry(entity).State = System.Data.EntityState.Modified;
        }

        void IOdeToFoodDb.Remove<T>(T entity)
        {
            Set<T>().Remove(entity);
        }

        void IOdeToFoodDb.SaveChanges()
        {
            SaveChanges();
        }
    }

}