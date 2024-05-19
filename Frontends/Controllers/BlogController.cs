using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Text;

namespace Front_End.Controllers
{
    public class BlogController : Controller
    {
        private readonly IWebHostEnvironment _env;
        public BlogController(IWebHostEnvironment env)
        {
            _env = env;

        }
        public async Task<IActionResult> Index()
        {
            List<Blogging> blogList = new List<Blogging>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7130/api/Blog/GetBlogs"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    blogList = JsonConvert.DeserializeObject<List<Blogging>>(apiResponse);
                }
            }
            return View(blogList);

        }
        public async Task<IActionResult> Blogs(string sortField = "random", int pageNumber = 1, int pageSize = 9)
        {

            List<Blogging> blogList = new List<Blogging>();
            string apiUrl = $"https://localhost:7250/api/Blog/GetBlogspag?pageNumber={pageNumber}&pageSize={pageSize}&sortField={sortField}";
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(apiUrl))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    blogList = JsonConvert.DeserializeObject<List<Blogging>>(apiResponse);
                }
            }
            ViewBag.PageNumber = pageNumber;
            ViewBag.PageSize = pageSize;

            var totalBlogsCount = await GetTotalBlogsCount();
            ViewBag.PageCount = (int)Math.Ceiling((double)totalBlogsCount / pageSize);

            return View(blogList);
        }
        private async Task<int> GetTotalBlogsCount()
        {
            var apiUrl = "https://localhost:7130/api/Blog/GetBlogs";

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(apiUrl))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        // Deserialize the JSON response into a collection of objects
                        var blogs = JsonConvert.DeserializeObject<List<Blogging>>(apiResponse);

                        // Get the count of objects
                        int count = blogs.Count;

                        // You can return the count or do any other processing with it
                        return count;
                    }
                    else
                    {
                        // Handle error if needed
                        return 0;
                    }
                }
            }

        }

        public async Task<IActionResult> SingleBlog(Guid id)
        {
            Blogging blog;
            List<Comment> comments;

            // Fetch the blog data
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"https://localhost:7130/api/Blog/GetBlog?id={id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    blog = JsonConvert.DeserializeObject<Blogging>(apiResponse);
                }
            }

            // Fetch the comments associated with the blog
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"https://localhost:7130/api/Comment/GetComments?id={id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    comments = JsonConvert.DeserializeObject<List<Comment>>(apiResponse);
                }
            }

            // Assign comments to the blog model
            blog.Comments = comments;

            return View(blog);
        }

        public IActionResult CreateBlog()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog(Blogging blog, IFormFile? ImageFile)
        {
            // If user is authenticated, assign user ID to the blog
            if (User.Identity.IsAuthenticated)
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                blog.User = userId;
            }

            // If an image file is provided, save it to the server
            if (ImageFile != null)
            {
                string filename = Guid.NewGuid() + Path.GetExtension(ImageFile.FileName);
                string imgpath = Path.Combine(_env.WebRootPath, "Images/Blogs/", filename);

                // Save the image file to the server
                using (FileStream streamread = new FileStream(imgpath, FileMode.Create))
                {
                    ImageFile.CopyTo(streamread);
                }

                // Set the image filename in the blog model
                blog.ImageName = filename;
            }

            // Send the blog data to the API endpoint
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(blog), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:7130/api/Blog/AddBlog", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    // Handle API response if needed
                }
            }

            // Redirect to the blog index page
            return RedirectToAction("Index", "Blog");
        }


        [HttpGet]
        public async Task<IActionResult> Update(Guid Id)
        {
            Blogging reservation = new Blogging();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7130/api/Blog/GetBlog?id=" + Id))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        reservation = JsonConvert.DeserializeObject<Blogging>(apiResponse);
                    }
                    else
                        ViewBag.StatusCode = response.StatusCode;
                }
            }
            return View(reservation);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Blogging blog, IFormFile? ImageFile)
        {
            if (ImageFile != null)
            {
                string filename = Guid.NewGuid() + Path.GetExtension(ImageFile.FileName);
                string imgpath = Path.Combine(_env.WebRootPath, "Images/Blogs/", filename);
                using (FileStream streamread = new FileStream(imgpath, FileMode.Create))
                {
                    ImageFile.CopyTo(streamread);
                }
                blog.ImageName = filename;
            }

            using (var httpClient = new HttpClient())
            {

                StringContent content = new StringContent(JsonConvert.SerializeObject(blog), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PutAsync("https://localhost:7130/api/Blog/UpdateBlog", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    //blog = JsonConvert.DeserializeObject<Blog>(apiResponse);
                }
            }
            return RedirectToAction("Index", "Blog");
        }




        [HttpPost]
        public async Task<IActionResult> Delete(Guid Id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:7130/api/Blog/DeleteBlog?Id=" + Id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("Index");
        }
        


        [HttpPost]
        public async Task<IActionResult> UpvoteLike(ReactionBlog like)
        {
            like.ReactionType = true;

            using (var httpClient = new HttpClient())
            {


                StringContent content = new StringContent(JsonConvert.SerializeObject(like), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:7130/api/ReactionBlog/Upvote", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                }
            }
            return RedirectToAction("SingleBlog", "Blog", new { id = like.Blog });

        }

        [HttpPost]
        public async Task<IActionResult> DownvoteLike(ReactionBlog like)
        {
            like.ReactionType = false;

            using (var httpClient = new HttpClient())
            {


                StringContent content = new StringContent(JsonConvert.SerializeObject(like), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:7130/api/ReactionBlog/Downvote", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                }
            }
            return RedirectToAction("SingleBlog", "Blog", new { id = like.Blog });

        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(Comment comment)
        {
            // You can add validation here if needed
            comment.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            // Set the PostedAt property of the comment
            comment.PostedAt = DateTime.UtcNow;

            // Add the comment to the database
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(comment), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:7130/api/Comment/AddComment", content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        // Comment added successfully, redirect to the blog page
                        return RedirectToAction("SingleBlog", "Blog", new { id = comment.BlogId });
                    }
                    else
                    {
                        // Handle error
                        ModelState.AddModelError(string.Empty, "Failed to add comment");
                    }
                }
            }

            // If the comment was not added successfully, return to the blog page
            return RedirectToAction("SingleBlog", "Blog", new { id = comment.BlogId });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteComment(Guid Id, Guid BlogId)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:7130/api/Comment/DeleteComment?Id=" + Id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("SingleBlog", "Blog", new { id = BlogId });
            //return View();
        }



        [HttpGet]
        public async Task<IActionResult> UpdateComment(Guid Id)
        {
            Comment reservation = new Comment();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7130/api/Comment/GetComment?id=" + Id))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        reservation = JsonConvert.DeserializeObject<Comment>(apiResponse);
                    }
                    else
                        ViewBag.StatusCode = response.StatusCode;
                }
            }
            return View(reservation);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateComment(Comment comment)
        {
            using (var httpClient = new HttpClient())
            {

                StringContent content = new StringContent(JsonConvert.SerializeObject(comment), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PutAsync("https://localhost:7130/api/Comment/UpdateComment", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    //blog = JsonConvert.DeserializeObject<Blog>(apiResponse);
                }
            }
            return RedirectToAction("Index", "Home");
        }



        [HttpPost]
        public async Task<IActionResult> UpvoteCommentLike(ReactionComment likeComment, Guid id)
        {
            likeComment.ReactionType = true;

            using (var httpClient = new HttpClient())
            {


                StringContent content = new StringContent(JsonConvert.SerializeObject(likeComment), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:7130/api/ReactionComment/UpvoteCmt", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                }
            }
            return RedirectToAction("SingleBlog", "Blog", new { id = id });

        }

        [HttpPost]
        public async Task<IActionResult> DownvoteCommentLike(ReactionBlog like, Guid id)
        {
            like.ReactionType = false;

            using (var httpClient = new HttpClient())
            {


                StringContent content = new StringContent(JsonConvert.SerializeObject(like), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:7130/api/LikeComment/DownvoteComment", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                }
            }
            return RedirectToAction("SingleBlog", "Blog", new { id = id });

        }

    }
}

