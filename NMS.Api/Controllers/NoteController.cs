using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NMS.Application;
using NMS.Domain;
using System.Security.Claims;

namespace NMS.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;
        ApiResponse response = new ApiResponse();
        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet("get-note-list")]
        public IActionResult GetNoteList()
        {
            try
            {
              
                var username = User.Identity?.Name;
                var data = _noteService.GetNoteList(username);
                if (data.Any())
                {
                    response.Data = data;
                    return Ok(response);
                }
                else
                {
                    response.Data = null;
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Data = null;
                return Ok(response);
            }

        }

        [HttpGet("get-noteType-list")]
        public IActionResult GetNoteTypeList()
        {
            try
            {
                var list = _noteService.GetNoteTypeList();
                if (list.Any())
                {
                    response.Data = list;
                    return Ok(response);
                }
                else
                {
                    response.Data = null;
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Data = null;
                return Ok(response);
            }

        }

        [HttpPost("add")]
        public IActionResult Add(Note note)
        {

            try
            {
                var data = _noteService.AddNote(note);
                if (data)
                {

                    response.Data = true;

                    return Ok(response);
                }
                else
                {

                    response.Data = null;
                    return Ok(response);
                }
            }
            catch (Exception)
            {
                response.Data = null;
                return Ok(response);
            }

        }

        [HttpPut("update/{noteId}")]
        public IActionResult Update(long noteId, Note note)
        {

            try
            {
                var result = _noteService.UpdateNote(noteId, note);
                if (result)
                {

                    response.Data = true;

                    return Ok(response);
                }
                else
                {
                    response.Data = null;
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Data = null;
                return Ok(response);
            }


        }

        [HttpGet("delete/{noteId}")]
        public IActionResult Delete(long noteId)
        {
            var data = _noteService.DeleteNote(noteId);
            if (data)
            {
                response.Data = true;

                return Ok(response);
            }
            else
            {
                response.Data = null;
                return Ok(response);
            }
        }
    }
}
