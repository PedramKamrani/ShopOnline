using CorService.Services.IService;
using DataLayer.Context;
using DataLayer.Entites.Proprty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CorService.Services.ProprtySevice
{
    public class ProprtyService : IProprtyService
    {
        DigikalaContext _context;
        public ProprtyService(DigikalaContext context)
        {
            _context = context;
        }
        #region Groups
        public List<ProprtyGroup> GetProprtyGroups(int pagenumber)
        {
            int skip = (pagenumber - 1) * 4;
            return _context.ProprtyGroups.Where(g=>g.IsDelete==false).Skip(skip).Take(4).ToList();
        }
        public int GetProprtyGroupCount()
        {
           
            return _context.ProprtyGroups.Count();
        }
        public List<ProprtyGroup> GetProprtyGroupsForAdmin()
        {
            return _context.ProprtyGroups.ToList();
        }
        public ProprtyGroup FindProprtyGroup(int id)
        {
            return _context.Find<ProprtyGroup>(id);
        }
        public bool AddGroupProprty(ProprtyGroup group)
        {
            _context.Add(group);
            int res = _context.SaveChanges();
            if (res > 0)
                return true;
            return false;
        }
        public List<ProprtyGroup> GetProprtyGroupsForEdit()
        {
            
            return _context.ProprtyGroups.ToList();
        }
       public bool EditeGroupProprty(ProprtyGroup group)
        {
            _context.Update(group);
            int res = _context.SaveChanges();
            if (res > 0)
                return true;
            return false;
        }
        #endregion
        #region Name
        public List<ProprtyName> GetProprtyNamesForAdmin()
        {
            return _context.ProprtyNames.ToList();
        }
        public int AddPropertyName(ProprtyName name)
        {
            _context.Add(name);
           _context.SaveChanges();
            return name.PropertyNameId;
                
        }
        public bool AddNameCategory(List<PropertyCategory> propertyCategories)
        {
            try
            {
                _context.PropertyCategories.AddRange(propertyCategories);
                _context.SaveChanges();
                return true;
            }
            catch
            {

                return false;
            }
        }
        public ProprtyName FindProprtyNameByAdmin(int id)
        {
            return _context.Find<ProprtyName>(id);
        }
        public bool EditProprtyName(ProprtyName name)
        {
            _context.Update(name);
            int res = _context.SaveChanges();
            if (res > 0)
                return true;
            return false;
        }
        public bool DeleteProprtyGruop(ProprtyGroup group)
        {
            _context.Update(group);
            int res = _context.SaveChanges();
            if (res > 0)
                return true;
            return false;

        }

        #endregion
        #region Value
        public List<PropertyValue> GetPropertyValuesForAdmin()
        {
            return _context.PropertyValues.Where(p=>p.ISDelete==false).ToList();
        }
        public bool AddProprtyValue(PropertyValue value)
        {
            _context.Add(value);
            int res = _context.SaveChanges();
            if (res > 0)
                return true;
            return false;
        }
        public PropertyValue FindProprtyValueByAdmin(int id)
        {
            return _context.Find<PropertyValue>(id);
        }
        public bool EditValue(PropertyValue value)
        {
            _context.Update(value);
            int res = _context.SaveChanges();
            if (res > 0)
                return true;
            return false;
        }
        public bool DeleteProprtyValue(PropertyValue values)
        {
            _context.Update(values);
            int res = _context.SaveChanges();
            if (res > 0)
                return true;
            return false;

        }
        #endregion
    }

}
