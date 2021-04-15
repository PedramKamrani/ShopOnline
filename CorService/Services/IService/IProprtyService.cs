using CorService.ViewModels.Product;
using DataLayer.Entites.Proprty;
using System;
using System.Collections.Generic;
using System.Text;

namespace CorService.Services.IService
{
   public interface IProprtyService
    {
        List<ProprtyGroup> GetProprtyGroups(int pagenumber);
        int GetProprtyGroupCount();
        List<ProprtyGroup> GetProprtyGroupsForAdmin();
        ProprtyGroup FindProprtyGroup(int id);
        List<ProprtyGroup> GetProprtyGroupsForEdit();
        bool EditeGroupProprty(ProprtyGroup group);
        bool DeleteProprtyGruop(ProprtyGroup group);
        bool AddGroupProprty(ProprtyGroup group);
        #region Name
        List<ProprtyName> GetProprtyNamesForAdmin();
       int AddPropertyName(ProprtyName name);
        bool AddNameCategory(List<PropertyCategory> propertyCategories);
        ProprtyName FindProprtyNameByAdmin(int id);
        bool EditProprtyName(ProprtyName name);
        #endregion
        #region Value
        List<PropertyValue> GetPropertyValuesForAdmin();
        bool AddProprtyValue(PropertyValue value);
        PropertyValue FindProprtyValueByAdmin(int id);
        bool EditValue(PropertyValue value);
        bool DeleteProprtyValue(PropertyValue values);
        #endregion
    }
}
