using NMS.Domain.Entities;
using NMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMS.Application
{
    public interface INoteService
    {
        List<Note> GetNoteList(string userName);
        List<NoteType> GetNoteTypeList();
        bool AddNote(Note note);
        bool UpdateNote(long noteId, Note note);
        bool DeleteNote(long noteId);
    }
}
