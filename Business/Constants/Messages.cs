using Core6.Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public class Messages
    {
        public static string UserRegistered = "Kayit basarili!";
        public static string PasswordError = "Hatali parola!";

        public static string SuccessfulLogin = "Basarili giris!";

        public static string AccountExist = "Bu Tc No ile zaten bir hesap var!";
        public static string NotRealInfos = "Lutfen gercek bilgilerinizi giriniz!";
        public static string UserNotFound = "Uzgunuz, kullanici bulunamadi!";

        public static string RoleAlredyExist = "Bu rol zaten kullaniciya daha once atanmis.";

        public static string SuccessRoleOperation = "Rol basariyla atandi.";

        public static string AuthorizationDenied = "Yetkiniz yok.";

        public static string UserAlreadyExists = "Kullanici zaten kayitli.";

        public static string AccessTokenCreated = "Token olusturuldu.";

        public static string PasswordChanged = "Password changed";

        public static string MailChanged = "Mail changed";
        public static string WrongInfos = "Lutfen dogru bilgilerinizi giriniz.";
        internal static string MailExists = "Bu mail ile zaten bir kayit mevcut.";
        internal static string LengthErrorForNationalityId = "Tc. No 11 haneli olmalidir.";
        internal static string NotFoundPeopleWhoApplied = "Uzgunuz. Henuz basvuru yapan yok.";
        internal static string NotFoundJobsWhoYouApplied = "Hey, henuz hic bir ilana basvurmadin.";
    }
}
