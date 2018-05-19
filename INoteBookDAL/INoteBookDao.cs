using Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INoteBookDAL
{
    public interface INoteBookDao
    {
        int Add(Note value);

        void Remove(int index);

        IEnumerable<Note> GetAll();

        IEnumerable<Note> SearchByName(string Name);

        IEnumerable<Note> SearchByLastName(string LastName);

        IEnumerable<Note> SearchByPhoneNum(string PhoneNum);

        IEnumerable<Note> SortByLastName();

        IEnumerable<Note> SortByYear();

        Note GetById(int? id);

        void Edit(Note noteBook);
    }
}
