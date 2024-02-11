using Azure;
using MetroApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MetroApplication.Services
{
    public interface IAuthService
    {
        int? AuthenticateOperator(string login, SecureString password);
        int? AuthenticateWorker(string login, SecureString password);
        void AssignRoleToOperator(Операторы @operator, string roleName);
    }
    public class AuthService : IAuthService
    {
        private readonly MetroContext _dbContext;

        public AuthService(MetroContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        //Авторизация оператора
        public int? AuthenticateOperator(string login, SecureString password)
        {
            string plainTextPassword = ConvertSecureStringToString(password);
            var authenticatedOperator = _dbContext.Operators.SingleOrDefault(o => o.Логин == login);
            if (authenticatedOperator != null && PasswordHashMatches(plainTextPassword, authenticatedOperator.Пароль))
                {
                    return authenticatedOperator.КодОператора;
                }
            return null;
        }
        //Назначение роли
        public void AssignRoleToOperator(Операторы @operator, string roleName)
        {
            try
            {
                var role = _dbContext.Roles.SingleOrDefault(r => r.НазваниеРоли == roleName);
                if (role == null)
                {
                    role = new Роли { НазваниеРоли = roleName };
                    _dbContext.Roles.Add(role);
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
        }
        //Авторизация работника
        public int? AuthenticateWorker(string login, SecureString password)
        {
            IntPtr unmanagedPassword = IntPtr.Zero;
            try
            {
                unmanagedPassword = Marshal.SecureStringToBSTR(password);
                string plainTextPassword = Marshal.PtrToStringBSTR(unmanagedPassword);
                var authenticatedUser = _dbContext.Workers.SingleOrDefault(u => u.Логин == login);
                if (authenticatedUser != null)
                {
                    string hashedPasswordFromDatabase = authenticatedUser.ХэшированныйПароль;
                    bool passwordsMatch = BCrypt.Net.BCrypt.Verify(plainTextPassword, hashedPasswordFromDatabase);
                    if (passwordsMatch)
                    {
                        return authenticatedUser.КодРаботника;
                    }
                }
            }
            finally
            {
                if (unmanagedPassword != IntPtr.Zero)
                {
                    Marshal.ZeroFreeBSTR(unmanagedPassword);
                }
            }
            return null;
        }
        //перевод в обычную строку
        private static string ConvertSecureStringToString(SecureString secureString)
        {
            if (secureString == null)
            {
                return null; 
            }
            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
        //сравнение хэш значений
        private bool PasswordHashMatches(string plainTextPassword, string hashedPasswordFromDatabase)
        {
            bool passwordMatches = BCrypt.Net.BCrypt.Verify(plainTextPassword, hashedPasswordFromDatabase);
            return passwordMatches;
        }
    }
}
