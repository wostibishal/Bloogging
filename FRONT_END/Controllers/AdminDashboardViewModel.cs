﻿namespace FRONT_END.Controllers
{
    public class AdminDashboardViewModel
    {
        public int AllTimeBlogPostCount { get; set; }
        public int AllTimeCommentCount { get; set; }
        public int AllTimeDownvoteCount { get; set; }
        public int AllTimeUpvoteCount { get; set; }
        public int DailyBlogPostCount { get; set; }
        public int DailyCommentCount { get; set; }
        public int DailyDownvoteCount { get; set; }
        public int DailyUpvoteCount { get; set; }
        public List<string> Top10PopularPosts { get; set; }
        public List<string> GetTop10PopularPostsByMonth { get; set; }
        public List<string> Top10PopularBloggers { get; set; }






    }
}
