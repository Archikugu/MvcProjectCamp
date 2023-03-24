﻿using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class DraftManager : IDraftService
    {
        IDraftDal _draftDal;

        public DraftManager(IDraftDal draftDal)
        {
            _draftDal = draftDal;
        }

        public void DraftAdd(Draft draft)
        {
            _draftDal.Insert(draft);
        }

        public void DraftDelete(Draft draft)
        {
            _draftDal.Delete(draft);
        }

        public void DraftUpdate(Draft draft)
        {
            _draftDal.Update(draft);
        }

        public Draft GetByID(int id)
        {
            return _draftDal.GetById(d => d.DraftID == id);
        }

        public List<Draft> GetList()
        {
            return _draftDal.GetList();
        }
    }
}
