using Entites;
using INoteBookDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ListCollection
{
    public class NoteDaoList : INoteBookDao
    {

        private List<Note> noteBook;

        public NoteDaoList()
        {
            this.noteBook = new List<Note>();
        }

        public int Add(Note value)
        {
            // Adding with LastIndex
            int lastId = 0;
            if (noteBook.Any())
            {
                lastId = noteBook.Max(item => item.Id).Value;
            }
            
            value.Id = lastId + 1;

            noteBook.Add(value);

            return value.Id.Value;
        }

        public void Edit(Note note)
        {
            
            noteBook[(int)note.Id].FirstName = note.FirstName;
            noteBook[(int)note.Id].LastName = note.LastName;
            noteBook[(int)note.Id].YearOfBirth = note.YearOfBirth;
            noteBook[(int)note.Id].PhoneNumber = note.PhoneNumber;
        }

        public IEnumerable<Note> GetAll()
        {
            return noteBook.ToList();
        }

        public Note GetById(int? id)
        {
            if (id != null)
                return noteBook[(int)id];
            return null;
        }

        public void Remove(int index)
        {
            if (noteBook.Count > index)
                this.noteBook.RemoveAt(index);
        }

        public IEnumerable<Note> SearchByLastName(string LastName)
        {
            return noteBook.FindAll(item => item.LastName == LastName);
        }

        public IEnumerable<Note> SearchByName(string FirstName)
        {
            return noteBook.FindAll(item => item.FirstName == FirstName);
        }

        public IEnumerable<Note> SearchByPhoneNum(string PhoneNum)
        {
            return noteBook.FindAll(item => item.PhoneNumber == PhoneNum);
        }

        public IEnumerable<Note> SortByLastName()
        {
            noteBook.Sort(delegate (Note nt1, Note nt2)
            { return nt1.LastName.CompareTo(nt2.LastName); });
            return noteBook.ToList();
        }

        public IEnumerable<Note> SortByYear()
        {
            noteBook.Sort(delegate (Note nt1, Note nt2)
            { return nt1.YearOfBirth.CompareTo(nt2.YearOfBirth); });
            return noteBook.ToList();
        }

    }
}
