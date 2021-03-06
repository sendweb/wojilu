﻿using System;
using System.Collections.Generic;
using System.Text;
using wojilu.Apps.Blog.Domain;
using wojilu.Web.Controller.Blog.Caching;
using wojilu.Web.Controller.Content.Caching;
using wojilu.Apps.Content.Domain;
using wojilu.Web.Controller.Forum.Caching;
using wojilu.Apps.Forum.Domain;

namespace wojilu.Web.Controller.Common.Caching {

    public class EntityInterceptorDB {

        private static Dictionary<String, IEntityInterceptor> dic = getMaps();

        private static Dictionary<String, IEntityInterceptor> getMaps() {

            Dictionary<String, IEntityInterceptor> maps = new Dictionary<String, IEntityInterceptor>();

            maps.Add( typeof( BlogPost ).FullName, new BlogPostInterceptor() );
            maps.Add( typeof( BlogCategory ).FullName, new BlogCategoryInterceptor() );
            maps.Add( typeof( BlogPostComment ).FullName, new BlogPostCommentInterceptor() );

            maps.Add( typeof( ContentPost ).FullName, new ContentPostInterceptor() );
            maps.Add( typeof( ContentSection ).FullName, new ContentSectionInterceptor() );


            maps.Add( typeof( ForumTopic ).FullName, new ForumTopicInterceptor() );
            maps.Add( typeof( ForumPost ).FullName, new ForumPostInterceptor() );
            maps.Add( typeof( ForumBoard ).FullName, new ForumBoardInterceptor() );
            maps.Add( typeof( ForumLink ).FullName, new ForumLinkInterceptor() );
            maps.Add( typeof( ForumApp ).FullName, new ForumAppInterceptor() );


            return maps;
        }

        public static Dictionary<String, IEntityInterceptor> GetMap() {
            return dic;
        }

        public static void AddUpdater( String typeName, IEntityInterceptor obj ) {
            dic.Add( typeName, obj );
        }

        public static IEntityInterceptor Get( IEntity entity ) {

            IEntityInterceptor obj;
            dic.TryGetValue( entity.GetType().FullName, out obj );
            return obj;
        }

        public static IEntityInterceptor Get( Type t ) {

            IEntityInterceptor obj;
            dic.TryGetValue( t.FullName, out obj );
            return obj;
        }

    }
}
