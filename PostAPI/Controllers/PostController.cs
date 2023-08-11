using Microsoft.AspNetCore.Mvc;
using PostAPI.Models;
using PostAPI.Repository;

namespace PostAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetallPost() {
            try 
            {
                return Ok(await _postRepository.GetAllPostAsync());            
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetPostByID(int id)
        {
            try 
            {
                var post = await _postRepository.GetPostAsync(id);
                return post == null ? BadRequest() : Ok(post) ;
            } catch (Exception ex)
            { 
                return BadRequest(ex.Message);
            }        
        }
        [HttpPost("addpost")]
        public async Task<IActionResult> AddNewPost(PostModels models)
        {
            try 
            {
                var newpost = await _postRepository.AddPostAsync(models);
                var post = await _postRepository.GetPostAsync(newpost);
                return post == null ? BadRequest() : Ok(post);

            } catch (Exception ex) 
            { 
                return BadRequest(ex.Message); 
            }
        }
        [HttpPut("updatepost/{id}")]
        public async Task<IActionResult> UpdatePost(int id, [FromBody] PostModels post) 
        {
            try 
            { 
                if(id != post.PostID)
                {
                    return NotFound();
                }
                else
                {
                    await _postRepository.UpdatePostAsync(id, post) ;
                    return Ok();
                }
            } catch (Exception ex) 
            { 
                return BadRequest(ex.Message); 
            }
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeletePost([FromRoute] int id) {
            await _postRepository.DeletePostAsync(id);
            return Ok();
        }
    }
}
