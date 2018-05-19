using DAL.DB;
using DAL.ListCollection;
using Entites;
using INoteBookBLL;
using INoteBookDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBook.BLL
{
    public class NoteBookLogic : INoteBookLogic
    {

        private INoteBookDao noteBookDao;

        public NoteBookLogic()
        {
            noteBookDao = new NoteDaoDB();
        }

        public int Add(Note value)
        {
            return noteBookDao.Add(value);
        }

        public void Edit(Note noteBook)
        {
            noteBookDao.Edit(noteBook);
        }

        public IEnumerable<Note> GetAll()
        {
            return noteBookDao.GetAll();
        }

        public Note GetById(int? id)
        {
            return noteBookDao.GetById(id);
        }

        public void Remove(int index)
        {
            noteBookDao.Remove(index);
        }

        public IEnumerable<Note> SearchByLastName(string LastName)
        {
            return noteBookDao.SearchByLastName(LastName);
        }

        public IEnumerable<Note> SearchByName(string Name)
        {
            return noteBookDao.SearchByName(Name);
        }

        public IEnumerable<Note> SearchByPhoneNum(string PhoneNum)
        {
            return noteBookDao.SearchByPhoneNum(PhoneNum);
        }

        public IEnumerable<Note> SortByLastName()
        {
            return noteBookDao.SortByLastName();
        }

        public IEnumerable<Note> SortByYear()
        {
            return noteBookDao.SortByYear();
        }

    }
}
