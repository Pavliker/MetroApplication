using MetroApplication.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MetroApplication.Services
{
    public interface IRegistrationService
    {
        void RegisterWorker(string login, SecureString password, string пароль);
        void AssignRoleToWorker(Работники user, string roleName);
    }
    public class RegistrationService : IRegistrationService
    {
        private readonly MetroContext _dbContext;
        IDialogService _dialog;  
        IItemsService itemsService;
        public MessageBoxViewModel MessageBoxViewModel;
        public MessageBoxCorrectViewModel MessageBoxCorrectViewModel;
        public RegistrationService(MetroContext dbContext, IDialogService _dialogs, IItemsService itemsService)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            itemsService = itemsService;
            _dialog = _dialogs;
        }
        //Регистрация работника
        public void RegisterWorker(string login, SecureString password, string пароль)
        {
            try
            {
                string plainTextPassword = ConvertSecureStringToString(password);
                if (_dbContext.Workers.Any(u => u.Логин == login))
                {
                    MessageBoxViewModel = new MessageBoxViewModel(_dialog, "Работник с таким логином уже существует.");
                    MessageBoxViewModel.Show();
                    return;
                }
                else
                {
                    var newWorker = new Работники
                    {
                        ДатаДобавления = DateTime.Now,
                        Логин = login,
                        ХэшированныйПароль = HashPassword(password),
                        Пароль = plainTextPassword,
                        Роли = new List<Роли>()
                    };
                    AssignRoleToWorker(newWorker, "Работник");

                    _dbContext.Workers.Add(newWorker);
                    _dbContext.SaveChanges();
                    MessageBoxCorrectViewModel = new MessageBoxCorrectViewModel(_dialog,"Работник успешно зарегистрирован!");
                    MessageBoxCorrectViewModel.Show();
                }
            }
            catch (Exception e)
            {
                itemsService.ErrorMessage = e.Message;
            }
        }
        //присваивание роли работнику
        public void AssignRoleToWorker(Работники user, string roleName)
        {
            try
            {
                var role = _dbContext.Roles.SingleOrDefault(r => r.НазваниеРоли == roleName);
                if (role == null)
                {
                    role = new Роли { НазваниеРоли = roleName };
                    _dbContext.Roles.Add(role);
                    _dbContext.SaveChanges();
                    MessageBoxCorrectViewModel = new MessageBoxCorrectViewModel(_dialog,"Роль \"Работник\" успешно назначена!");
                    MessageBoxCorrectViewModel.Show();
                }
            }
            catch (Exception ex)
            {
                itemsService.ErrorMessage = ex.Message;
            }
        }
        //создание хэш значения
        private string HashPassword(SecureString password)
        {
            IntPtr unmanagedPassword = IntPtr.Zero;
            try
            {
                unmanagedPassword = Marshal.SecureStringToBSTR(password);
                string plainTextPassword = Marshal.PtrToStringBSTR(unmanagedPassword);
                return BCrypt.Net.BCrypt.HashPassword(plainTextPassword);
            }
            finally
            {
                if (unmanagedPassword != IntPtr.Zero)
                {
                    Marshal.ZeroFreeBSTR(unmanagedPassword);
                }
            }
        }
        //перевод в обычную строку
        private string ConvertSecureStringToString(SecureString secureString)
        {
            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToBSTR(secureString);
                return Marshal.PtrToStringBSTR(unmanagedString);
            }
            finally
            {
                if (unmanagedString != IntPtr.Zero)
                {
                    Marshal.ZeroFreeBSTR(unmanagedString);
                }
            }
        }
    }
}
