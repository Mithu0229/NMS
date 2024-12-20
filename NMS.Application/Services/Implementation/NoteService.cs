﻿using NMS.Domain.Entities;
using NMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMS.Application
{
    public class NoteService : INoteService
    {
        private readonly List<Note> _noteList = new();
        private static long _noteId = 1;
        public bool AddNote(Note model)
        {
            model.NoteId = _noteId++;
            _noteList.Add(model);
            return true;
        }

        public bool DeleteNote(long noteId)
        {
            var note = _noteList.FirstOrDefault(x => x.NoteId == noteId);
            if (note is not null)
            {
                _noteList.Remove(note);
            }
            return true;
        }

        public List<Note> GetNoteList(string userName)
        {
            return _noteList.Where(x => x.UserName == userName).ToList();
        }
        public List<NoteType> GetNoteTypeList()
        {
            return new List<NoteType>()
            {
                new NoteType()
                {
                    NoteTypeId=1,
                    NoteTypeName="Regular"
                },
                new NoteType()
                {
                    NoteTypeId=2,
                    NoteTypeName="Reminder"
                },
                new NoteType()
                {
                    NoteTypeId=3,
                    NoteTypeName="Todo"
                },
                new NoteType()
                {
                    NoteTypeId=4,
                    NoteTypeName="Bookmark"
                }
            };
        }

        public bool UpdateNote(long noteId, Note model)
        {
            var note = _noteList.FirstOrDefault(x => x.NoteId == noteId);
            if (note is not null)
            {
                note.NoteType = model.NoteType;
                note.NoteContent = model.NoteContent;
                note.IsComplete = model.IsComplete;
                note.ReminderTimeDate = model.ReminderTimeDate;
                note.DueTimeDate = model.DueTimeDate;
            }
            return true;
        }
    }
}
