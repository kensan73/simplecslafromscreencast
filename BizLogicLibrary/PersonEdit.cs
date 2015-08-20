using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Csla;

namespace BizLogicLibrary
{
    [Serializable]
    public class PersonEdit : BusinessBase<PersonEdit> //readonlybase, 6 total
    {
        public static readonly PropertyInfo<int> IdProperty = RegisterProperty<int>(c => c.Id);
        public int Id
        {
            get { return GetProperty(IdProperty); }
            set { SetProperty(IdProperty, value); }
        }

        public static readonly PropertyInfo<string> NameProperty = RegisterProperty<string>(c => c.Name);
        [Required]
        [StringLength(50)]
        public string Name
        {
            get { return GetProperty(NameProperty); }
            set { SetProperty(NameProperty, value); }
        }

        public static async Task<PersonEdit> NewPersonEditAsync()
        {
            return await DataPortal.CreateAsync<PersonEdit>();
        }

        public static async Task<PersonEdit> GetPersonEditAsync(int id)
        {
            return await DataPortal.FetchAsync<PersonEdit>(id);
        }

        public static void NewPersonEdit(EventHandler<DataPortalResult<PersonEdit>> callback)
        {
            DataPortal.BeginCreate<PersonEdit>(callback);
        }

        public static void GetPersonEdit(int id, EventHandler<DataPortalResult<PersonEdit>> callback)
        {
            DataPortal.BeginFetch<PersonEdit>(id, callback);
        }

#if !SILVERLIGHT
        public static PersonEdit NewPersonEdit()
        {
            return DataPortal.Create<PersonEdit>();
        }

        public static PersonEdit GetPersonEdit(int id)
        {
            return DataPortal.Fetch<PersonEdit>(id);
        }

        public static void DeletePersonEdit(int id)
        {
            DataPortal.Delete<PersonEdit>(id);
        }

        private void DataPortal_Fetch(int id)
        {
            using (BypassPropertyChecks)
            {
                Id = id;
                Name = "Raymund Tapon";
            }
        }
#endif
    }
}
