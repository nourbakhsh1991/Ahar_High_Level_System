using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AharHighLevel.Common
{
    public class CryptoService
    {
        private const int SaltSize = 8;

        public static void Encrypt(FileInfo targetFile, string password, dynamic data)
        {
            var keyGenerator = new Rfc2898DeriveBytes(password, SaltSize);
            var rijndael = Rijndael.Create();

            // BlockSize, KeySize in bit --> divide by 8
            rijndael.IV = keyGenerator.GetBytes(rijndael.BlockSize / 8);
            rijndael.Key = keyGenerator.GetBytes(rijndael.KeySize / 8);

            using (var fileStream = targetFile.Create())
            {
                // write random salt
                fileStream.Write(keyGenerator.Salt, 0, SaltSize);

                using (var cryptoStream = new CryptoStream(fileStream, rijndael.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    byte[] ProjectNum = BitConverter.GetBytes(data.ProjectNum);
                    cryptoStream.Write(ProjectNum, 0, ProjectNum.Length);
                    byte[] UnitNum = BitConverter.GetBytes(data.UnitNum);
                    cryptoStream.Write(UnitNum, 0, UnitNum.Length);
                    byte[] UnitCap = BitConverter.GetBytes(data.UnitCap);
                    cryptoStream.Write(UnitCap, 0, UnitCap.Length);
                    byte[] SelectedDate = BitConverter.GetBytes(((DateTime)data.SelectedDate).Ticks);
                    cryptoStream.Write(SelectedDate, 0, SelectedDate.Length);
                    byte[] Username = new byte[100];
                    string tmpStr = (data.Username == null ? "" : data.Username).ToString();
                    Array.Copy(Encoding.ASCII.GetBytes(tmpStr), Username, tmpStr.Length);
                    cryptoStream.Write(Username, 0, Username.Length);
                    byte[] Description = new byte[1000];
                    tmpStr = (data.Description == null ? "" : data.Description).ToString();
                    Array.Copy(Encoding.ASCII.GetBytes(tmpStr), Description, tmpStr.Length);
                    cryptoStream.Write(Description, 0, Description.Length);

                }
            }
        }

        public static bool CreateProject(FileInfo targetFile, string password, dynamic data)
        {
            try
            {
                var keyGenerator = new Rfc2898DeriveBytes(password, SaltSize);
                var rijndael = Rijndael.Create();
                AharProjectType prj = data.project;
                if (prj == null)
                {
                    return false;
                }

                // BlockSize, KeySize in bit --> divide by 8
                rijndael.IV = keyGenerator.GetBytes(rijndael.BlockSize / 8);
                rijndael.Key = keyGenerator.GetBytes(rijndael.KeySize / 8);
                var allStr = "";
                using (var fileStream = targetFile.Create())
                {
                    // write random salt
                    fileStream.Write(keyGenerator.Salt, 0, SaltSize);

                    using (var cryptoStream =
                        new CryptoStream(fileStream, rijndael.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        byte[] bytes = null;
                        var len = 0;
                        var str = "";
                        var encryptedStr = "";
                        // write project number
                        bytes = new byte[500];
                        str = string.IsNullOrEmpty(prj.ProjectNumber) ? "" : prj.ProjectNumber;
                        if (str.Length > 500 - 36)
                            str = str.Substring(0, 500 - 36);
                        len = str.Length;
                        encryptedStr = CreateMD5(str);
                        var lenData = BitConverter.GetBytes(len);
                        Array.Copy(lenData, 0, bytes, 0, 4);
                        var encryptedData = Encoding.ASCII.GetBytes(encryptedStr);
                        Array.Copy(encryptedData, 0, bytes, 4, 32);
                        byte[] ProjectNum = Encoding.ASCII.GetBytes(str);
                        Array.Copy(ProjectNum, 0, bytes, 36, ProjectNum.Length);
                        cryptoStream.Write(bytes, 0, 500);
                        allStr += str;

                        // write unit number
                        bytes = new byte[500];
                        str = string.IsNullOrEmpty(prj.UnitNumber) ? "" : prj.UnitNumber;
                        if (str.Length > 500 - 36)
                            str = str.Substring(0, 500 - 36);
                        len = str.Length;
                        encryptedStr = CreateMD5(str);
                        lenData = BitConverter.GetBytes(len);
                        Array.Copy(lenData, 0, bytes, 0, 4);
                        encryptedData = Encoding.ASCII.GetBytes(encryptedStr);
                        Array.Copy(encryptedData, 0, bytes, 4, 32);
                        byte[] UnitNum = Encoding.ASCII.GetBytes(str);
                        Array.Copy(UnitNum, 0, bytes, 36, UnitNum.Length);
                        cryptoStream.Write(bytes, 0, 500);
                        allStr += str;

                        // write unit capacity
                        bytes = new byte[500];
                        str = string.IsNullOrEmpty(prj.UnitCapacity) ? "" : prj.UnitCapacity;
                        if (str.Length > 500 - 36)
                            str = str.Substring(0, 500 - 36);
                        len = str.Length;
                        encryptedStr = CreateMD5(str);
                        lenData = BitConverter.GetBytes(len);
                        Array.Copy(lenData, 0, bytes, 0, 4);
                        encryptedData = Encoding.ASCII.GetBytes(encryptedStr);
                        Array.Copy(encryptedData, 0, bytes, 4, 32);
                        byte[] UnitCap = Encoding.ASCII.GetBytes(str);
                        Array.Copy(UnitCap, 0, bytes, 36, UnitCap.Length);
                        cryptoStream.Write(bytes, 0, 500);
                        allStr += str;

                        // write Installation Date
                        bytes = new byte[500];
                        byte[] SelectedDate = BitConverter.GetBytes(prj.InstallationDate);
                        encryptedStr = CreateMD5(prj.InstallationDate.ToString());
                        encryptedData = Encoding.ASCII.GetBytes(encryptedStr);
                        Array.Copy(encryptedData, 0, bytes, 0, 32);
                        Array.Copy(SelectedDate, 0, bytes, 32, SelectedDate.Length);
                        cryptoStream.Write(bytes, 0, 500);
                        allStr += prj.InstallationDate.ToString();
                        // write EmployerName
                        bytes = new byte[500];
                        str = string.IsNullOrEmpty(prj.EmployerName) ? "" : prj.EmployerName;
                        if (str.Length > 500 - 36)
                            str = str.Substring(0, 500 - 36);
                        len = str.Length;
                        encryptedStr = CreateMD5(str);
                        lenData = BitConverter.GetBytes(len);
                        Array.Copy(lenData, 0, bytes, 0, 4);
                        encryptedData = Encoding.ASCII.GetBytes(encryptedStr);
                        Array.Copy(encryptedData, 0, bytes, 4, 32);
                        byte[] EmployerName = Encoding.ASCII.GetBytes(str);
                        Array.Copy(EmployerName, 0, bytes, 36, EmployerName.Length);
                        cryptoStream.Write(bytes, 0, 500);
                        allStr += str;

                        // write Description
                        bytes = new byte[500];
                        str = string.IsNullOrEmpty(prj.Description) ? "" : prj.Description;
                        if (str.Length > 500 - 36)
                            str = str.Substring(0, 500 - 36);
                        len = str.Length;
                        encryptedStr = CreateMD5(str);
                        lenData = BitConverter.GetBytes(len);
                        Array.Copy(lenData, 0, bytes, 0, 4);
                        encryptedData = Encoding.ASCII.GetBytes(encryptedStr);
                        Array.Copy(encryptedData, 0, bytes, 4, 32);
                        byte[] Description = Encoding.ASCII.GetBytes(str);
                        Array.Copy(Description, 0, bytes, 36, Description.Length);
                        cryptoStream.Write(bytes, 0, 500);
                        allStr += str;

                        // write Change Date
                        bytes = new byte[500];
                        byte[] ChangeDate = BitConverter.GetBytes(prj.LastModify);
                        encryptedStr = CreateMD5(prj.LastModify.ToString());
                        encryptedData = Encoding.ASCII.GetBytes(encryptedStr);
                        Array.Copy(encryptedData, 0, bytes, 0, 32);
                        Array.Copy(ChangeDate, 0, bytes, 32, ChangeDate.Length);
                        cryptoStream.Write(bytes, 0, 500);
                        allStr += prj.LastModify.ToString();

                        // write Device
                        bytes = new byte[500];
                        str = string.IsNullOrEmpty(prj.Device) ? "" : prj.Device;
                        if (str.Length > 500 - 36)
                            str = str.Substring(0, 500 - 36);
                        len = str.Length;
                        encryptedStr = CreateMD5(str);
                        lenData = BitConverter.GetBytes(len);
                        Array.Copy(lenData, 0, bytes, 0, 4);
                        encryptedData = Encoding.ASCII.GetBytes(encryptedStr);
                        Array.Copy(encryptedData, 0, bytes, 4, 32);
                        byte[] Device = Encoding.ASCII.GetBytes(str);
                        Array.Copy(Device, 0, bytes, 36, Device.Length);
                        cryptoStream.Write(bytes, 0, 500);
                        allStr += str;

                        // write Username
                        bytes = new byte[500];
                        str = string.IsNullOrEmpty(prj.Username) ? "" : prj.Username;
                        if (str.Length > 500 - 36)
                            str = str.Substring(0, 500 - 36);
                        len = str.Length;
                        encryptedStr = CreateMD5(str);
                        lenData = BitConverter.GetBytes(len);
                        Array.Copy(lenData, 0, bytes, 0, 4);
                        encryptedData = Encoding.ASCII.GetBytes(encryptedStr);
                        Array.Copy(encryptedData, 0, bytes, 4, 32);
                        byte[] Username = Encoding.ASCII.GetBytes(str);
                        Array.Copy(Username, 0, bytes, 36, Username.Length);
                        cryptoStream.Write(bytes, 0, 500);
                        allStr += str;

                        // Write Params
                        var counter = 0;
                        foreach (var Params in ConfigParams.AllParams.Where(a => !a.IsReadOnly).OrderBy(a => a.FormId))
                        {
                            if (Params is RealVariable real)
                            {
                                var val = float.Parse(string.IsNullOrEmpty(real.Value) ? "0" : real.Value);
                                bytes = BitConverter.GetBytes(val);
                                cryptoStream.Write(bytes, 0, 4);
                                allStr += val;
                                counter++;
                            }

                            if (Params is BoolVariable Bool)
                            {
                                var val = Bool.Value ? 1 : 0;
                                bytes = BitConverter.GetBytes(val);
                                cryptoStream.Write(bytes, 0, 4);
                                allStr += val;
                                counter++;
                            }

                            if (Params is EnumVariable Enum)
                            {
                                var val = Enum.Value;
                                bytes = BitConverter.GetBytes(val);
                                cryptoStream.Write(bytes, 0, 4);
                                allStr += val;
                                counter++;
                            }
                        }
                        bytes = BitConverter.GetBytes(counter);
                        cryptoStream.Write(bytes, 0, 4);
                        encryptedStr = CreateMD5(allStr);
                        bytes = Encoding.ASCII.GetBytes(encryptedStr);
                        cryptoStream.Write(bytes, 0, 32);
                        AppStatics.CurrentParams = new List<NetVariable>();
                        AppStatics.CurrentParams.AddRange(ConfigParams.AllParams.Select(a => (NetVariable)a.Clone()));
                        AppStatics.SaveParams = new List<NetVariable>();
                        AppStatics.SaveParams.AddRange(ConfigParams.AllParams.Select(a => (NetVariable)a.Clone()));
                        // close Strem
                        cryptoStream.Flush();
                        cryptoStream.Close();

                    }
                }
            }
            catch (Exception ex)
            {
                //AppStatics.FileHandler.GenerateLog(new[] { ex.Message });
                return false;
            }

            return true;
        }

        public static bool SaveProject(FileInfo targetFile, string password, dynamic data, List<NetVariable> variables)
        {
            try
            {
                var keyGenerator = new Rfc2898DeriveBytes(password, SaltSize);
                var rijndael = Rijndael.Create();
                AharProjectType prj = data.project;
                if (prj == null)
                {
                    return false;
                }

                // BlockSize, KeySize in bit --> divide by 8
                rijndael.IV = keyGenerator.GetBytes(rijndael.BlockSize / 8);
                rijndael.Key = keyGenerator.GetBytes(rijndael.KeySize / 8);
                var allStr = "";
                using (var fileStream = targetFile.Create())
                {
                    // write random salt
                    fileStream.Write(keyGenerator.Salt, 0, SaltSize);

                    using (var cryptoStream =
                        new CryptoStream(fileStream, rijndael.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        byte[] bytes = null;
                        var len = 0;
                        var str = "";
                        var encryptedStr = "";
                        // write project number
                        bytes = new byte[500];
                        str = string.IsNullOrEmpty(prj.ProjectNumber) ? "" : prj.ProjectNumber;
                        if (str.Length > 500 - 36)
                            str = str.Substring(0, 500 - 36);
                        len = str.Length;
                        encryptedStr = CreateMD5(str);
                        var lenData = BitConverter.GetBytes(len);
                        Array.Copy(lenData, 0, bytes, 0, 4);
                        var encryptedData = Encoding.ASCII.GetBytes(encryptedStr);
                        Array.Copy(encryptedData, 0, bytes, 4, 32);
                        byte[] ProjectNum = Encoding.ASCII.GetBytes(str);
                        Array.Copy(ProjectNum, 0, bytes, 36, ProjectNum.Length);
                        cryptoStream.Write(bytes, 0, 500);
                        allStr += str;

                        // write unit number
                        bytes = new byte[500];
                        str = string.IsNullOrEmpty(prj.UnitNumber) ? "" : prj.UnitNumber;
                        if (str.Length > 500 - 36)
                            str = str.Substring(0, 500 - 36);
                        len = str.Length;
                        encryptedStr = CreateMD5(str);
                        lenData = BitConverter.GetBytes(len);
                        Array.Copy(lenData, 0, bytes, 0, 4);
                        encryptedData = Encoding.ASCII.GetBytes(encryptedStr);
                        Array.Copy(encryptedData, 0, bytes, 4, 32);
                        byte[] UnitNum = Encoding.ASCII.GetBytes(str);
                        Array.Copy(UnitNum, 0, bytes, 36, UnitNum.Length);
                        cryptoStream.Write(bytes, 0, 500);
                        allStr += str;

                        // write unit capacity
                        bytes = new byte[500];
                        str = string.IsNullOrEmpty(prj.UnitCapacity) ? "" : prj.UnitCapacity;
                        if (str.Length > 500 - 36)
                            str = str.Substring(0, 500 - 36);
                        len = str.Length;
                        encryptedStr = CreateMD5(str);
                        lenData = BitConverter.GetBytes(len);
                        Array.Copy(lenData, 0, bytes, 0, 4);
                        encryptedData = Encoding.ASCII.GetBytes(encryptedStr);
                        Array.Copy(encryptedData, 0, bytes, 4, 32);
                        byte[] UnitCap = Encoding.ASCII.GetBytes(str);
                        Array.Copy(UnitCap, 0, bytes, 36, UnitCap.Length);
                        cryptoStream.Write(bytes, 0, 500);
                        allStr += str;

                        // write Installation Date
                        bytes = new byte[500];
                        byte[] SelectedDate = BitConverter.GetBytes(prj.InstallationDate);
                        encryptedStr = CreateMD5(prj.InstallationDate.ToString());
                        encryptedData = Encoding.ASCII.GetBytes(encryptedStr);
                        Array.Copy(encryptedData, 0, bytes, 0, 32);
                        Array.Copy(SelectedDate, 0, bytes, 32, SelectedDate.Length);
                        cryptoStream.Write(bytes, 0, 500);
                        allStr += prj.InstallationDate.ToString();
                        // write EmployerName
                        bytes = new byte[500];
                        str = string.IsNullOrEmpty(prj.EmployerName) ? "" : prj.EmployerName;
                        if (str.Length > 500 - 36)
                            str = str.Substring(0, 500 - 36);
                        len = str.Length;
                        encryptedStr = CreateMD5(str);
                        lenData = BitConverter.GetBytes(len);
                        Array.Copy(lenData, 0, bytes, 0, 4);
                        encryptedData = Encoding.ASCII.GetBytes(encryptedStr);
                        Array.Copy(encryptedData, 0, bytes, 4, 32);
                        byte[] EmployerName = Encoding.ASCII.GetBytes(str);
                        Array.Copy(EmployerName, 0, bytes, 36, EmployerName.Length);
                        cryptoStream.Write(bytes, 0, 500);
                        allStr += str;

                        // write Description
                        bytes = new byte[500];
                        str = string.IsNullOrEmpty(prj.Description) ? "" : prj.Description;
                        if (str.Length > 500 - 36)
                            str = str.Substring(0, 500 - 36);
                        len = str.Length;
                        encryptedStr = CreateMD5(str);
                        lenData = BitConverter.GetBytes(len);
                        Array.Copy(lenData, 0, bytes, 0, 4);
                        encryptedData = Encoding.ASCII.GetBytes(encryptedStr);
                        Array.Copy(encryptedData, 0, bytes, 4, 32);
                        byte[] Description = Encoding.ASCII.GetBytes(str);
                        Array.Copy(Description, 0, bytes, 36, Description.Length);
                        cryptoStream.Write(bytes, 0, 500);
                        allStr += str;

                        // write Change Date
                        bytes = new byte[500];
                        byte[] ChangeDate = BitConverter.GetBytes(prj.LastModify);
                        encryptedStr = CreateMD5(prj.LastModify.ToString());
                        encryptedData = Encoding.ASCII.GetBytes(encryptedStr);
                        Array.Copy(encryptedData, 0, bytes, 0, 32);
                        Array.Copy(ChangeDate, 0, bytes, 32, ChangeDate.Length);
                        cryptoStream.Write(bytes, 0, 500);
                        allStr += prj.LastModify.ToString();

                        // write Device
                        bytes = new byte[500];
                        str = string.IsNullOrEmpty(prj.Device) ? "" : prj.Device;
                        if (str.Length > 500 - 36)
                            str = str.Substring(0, 500 - 36);
                        len = str.Length;
                        encryptedStr = CreateMD5(str);
                        lenData = BitConverter.GetBytes(len);
                        Array.Copy(lenData, 0, bytes, 0, 4);
                        encryptedData = Encoding.ASCII.GetBytes(encryptedStr);
                        Array.Copy(encryptedData, 0, bytes, 4, 32);
                        byte[] Device = Encoding.ASCII.GetBytes(str);
                        Array.Copy(Device, 0, bytes, 36, Device.Length);
                        cryptoStream.Write(bytes, 0, 500);
                        allStr += str;

                        // write Username
                        bytes = new byte[500];
                        str = string.IsNullOrEmpty(prj.Username) ? "" : prj.Username;
                        if (str.Length > 500 - 36)
                            str = str.Substring(0, 500 - 36);
                        len = str.Length;
                        encryptedStr = CreateMD5(str);
                        lenData = BitConverter.GetBytes(len);
                        Array.Copy(lenData, 0, bytes, 0, 4);
                        encryptedData = Encoding.ASCII.GetBytes(encryptedStr);
                        Array.Copy(encryptedData, 0, bytes, 4, 32);
                        byte[] Username = Encoding.ASCII.GetBytes(str);
                        Array.Copy(Username, 0, bytes, 36, Username.Length);
                        cryptoStream.Write(bytes, 0, 500);
                        allStr += str;
                        // Write Params
                        var counter = 0;
                        foreach (var Params in variables.Where(a => !a.IsReadOnly).OrderBy(a => a.FormId))
                        {

                            if (Params is RealVariable real)
                            {
                                var val = float.Parse(string.IsNullOrEmpty(real.Value) ? "0" : real.Value);
                                bytes = BitConverter.GetBytes(val);
                                cryptoStream.Write(bytes, 0, 4);
                                allStr += val;
                                counter++;
                            }

                            if (Params is BoolVariable Bool)
                            {
                                var val = Bool.Value ? 1 : 0;
                                bytes = BitConverter.GetBytes(val);
                                cryptoStream.Write(bytes, 0, 4);
                                allStr += val;
                                counter++;
                            }

                            if (Params is EnumVariable Enum)
                            {
                                var val = Enum.Value;
                                bytes = BitConverter.GetBytes(val);
                                cryptoStream.Write(bytes, 0, 4);
                                allStr += val;
                                counter++;
                            }

                        }

                        bytes = BitConverter.GetBytes(counter);
                        cryptoStream.Write(bytes, 0, 4);
                        encryptedStr = CreateMD5(allStr);
                        bytes = Encoding.ASCII.GetBytes(encryptedStr);
                        cryptoStream.Write(bytes, 0, 32);
                        AppStatics.SaveParams = new List<NetVariable>();
                        AppStatics.SaveParams.AddRange(AppStatics.CurrentParams.Select(a => (NetVariable)a.Clone()));
                        // close Strem
                        cryptoStream.Flush();
                        cryptoStream.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                AppStatics.FileHandler.GenerateLog(new[] { ex.Message });
                return false;
            }

            return true;
        }

        public static bool SaveDownload(FileInfo targetFile, string password, dynamic data, List<NetVariable> variables)
        {
            try
            {
                var keyGenerator = new Rfc2898DeriveBytes(password, SaltSize);
                var rijndael = Rijndael.Create();
                AharProjectType prj = data.project;
                if (prj == null)
                {
                    return false;
                }
                string TitleDl = string.IsNullOrEmpty(data.Title) ? "" : data.Title;
                string DescriptionDl = string.IsNullOrEmpty(data.Description) ? "" : data.Description;
                // BlockSize, KeySize in bit --> divide by 8
                rijndael.IV = keyGenerator.GetBytes(rijndael.BlockSize / 8);
                rijndael.Key = keyGenerator.GetBytes(rijndael.KeySize / 8);
                var allStr = "";
                using (var fileStream = targetFile.Create())
                {
                    // write random salt
                    fileStream.Write(keyGenerator.Salt, 0, SaltSize);

                    using (var cryptoStream =
                        new CryptoStream(fileStream, rijndael.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        byte[] bytes = null;
                        var len = 0;
                        var str = "";
                        var encryptedStr = "";
                        // write project number
                        bytes = new byte[500];
                        str = string.IsNullOrEmpty(prj.ProjectNumber) ? "" : prj.ProjectNumber;
                        if (str.Length > 500 - 36)
                            str = str.Substring(0, 500 - 36);
                        len = str.Length;
                        encryptedStr = CreateMD5(str);
                        var lenData = BitConverter.GetBytes(len);
                        Array.Copy(lenData, 0, bytes, 0, 4);
                        var encryptedData = Encoding.ASCII.GetBytes(encryptedStr);
                        Array.Copy(encryptedData, 0, bytes, 4, 32);
                        byte[] ProjectNum = Encoding.ASCII.GetBytes(str);
                        Array.Copy(ProjectNum, 0, bytes, 36, ProjectNum.Length);
                        cryptoStream.Write(bytes, 0, 500);
                        allStr += str;

                        // write unit number
                        bytes = new byte[500];
                        str = string.IsNullOrEmpty(prj.UnitNumber) ? "" : prj.UnitNumber;
                        if (str.Length > 500 - 36)
                            str = str.Substring(0, 500 - 36);
                        len = str.Length;
                        encryptedStr = CreateMD5(str);
                        lenData = BitConverter.GetBytes(len);
                        Array.Copy(lenData, 0, bytes, 0, 4);
                        encryptedData = Encoding.ASCII.GetBytes(encryptedStr);
                        Array.Copy(encryptedData, 0, bytes, 4, 32);
                        byte[] UnitNum = Encoding.ASCII.GetBytes(str);
                        Array.Copy(UnitNum, 0, bytes, 36, UnitNum.Length);
                        cryptoStream.Write(bytes, 0, 500);
                        allStr += str;

                        // write unit capacity
                        bytes = new byte[500];
                        str = string.IsNullOrEmpty(prj.UnitCapacity) ? "" : prj.UnitCapacity;
                        if (str.Length > 500 - 36)
                            str = str.Substring(0, 500 - 36);
                        len = str.Length;
                        encryptedStr = CreateMD5(str);
                        lenData = BitConverter.GetBytes(len);
                        Array.Copy(lenData, 0, bytes, 0, 4);
                        encryptedData = Encoding.ASCII.GetBytes(encryptedStr);
                        Array.Copy(encryptedData, 0, bytes, 4, 32);
                        byte[] UnitCap = Encoding.ASCII.GetBytes(str);
                        Array.Copy(UnitCap, 0, bytes, 36, UnitCap.Length);
                        cryptoStream.Write(bytes, 0, 500);
                        allStr += str;

                        // write Installation Date
                        bytes = new byte[500];
                        byte[] SelectedDate = BitConverter.GetBytes(prj.InstallationDate);
                        encryptedStr = CreateMD5(prj.InstallationDate.ToString());
                        encryptedData = Encoding.ASCII.GetBytes(encryptedStr);
                        Array.Copy(encryptedData, 0, bytes, 0, 32);
                        Array.Copy(SelectedDate, 0, bytes, 32, SelectedDate.Length);
                        cryptoStream.Write(bytes, 0, 500);
                        allStr += prj.InstallationDate.ToString();
                        // write EmployerName
                        bytes = new byte[500];
                        str = string.IsNullOrEmpty(prj.EmployerName) ? "" : prj.EmployerName;
                        if (str.Length > 500 - 36)
                            str = str.Substring(0, 500 - 36);
                        len = str.Length;
                        encryptedStr = CreateMD5(str);
                        lenData = BitConverter.GetBytes(len);
                        Array.Copy(lenData, 0, bytes, 0, 4);
                        encryptedData = Encoding.ASCII.GetBytes(encryptedStr);
                        Array.Copy(encryptedData, 0, bytes, 4, 32);
                        byte[] EmployerName = Encoding.ASCII.GetBytes(str);
                        Array.Copy(EmployerName, 0, bytes, 36, EmployerName.Length);
                        cryptoStream.Write(bytes, 0, 500);
                        allStr += str;

                        // write Description
                        bytes = new byte[500];
                        str = string.IsNullOrEmpty(prj.Description) ? "" : prj.Description;
                        if (str.Length > 500 - 36)
                            str = str.Substring(0, 500 - 36);
                        len = str.Length;
                        encryptedStr = CreateMD5(str);
                        lenData = BitConverter.GetBytes(len);
                        Array.Copy(lenData, 0, bytes, 0, 4);
                        encryptedData = Encoding.ASCII.GetBytes(encryptedStr);
                        Array.Copy(encryptedData, 0, bytes, 4, 32);
                        byte[] Description = Encoding.ASCII.GetBytes(str);
                        Array.Copy(Description, 0, bytes, 36, Description.Length);
                        cryptoStream.Write(bytes, 0, 500);
                        allStr += str;

                        // write Change Date
                        bytes = new byte[500];
                        byte[] ChangeDate = BitConverter.GetBytes(prj.LastModify);
                        encryptedStr = CreateMD5(prj.LastModify.ToString());
                        encryptedData = Encoding.ASCII.GetBytes(encryptedStr);
                        Array.Copy(encryptedData, 0, bytes, 0, 32);
                        Array.Copy(ChangeDate, 0, bytes, 32, ChangeDate.Length);
                        cryptoStream.Write(bytes, 0, 500);
                        allStr += prj.LastModify.ToString();

                        // write Device
                        bytes = new byte[500];
                        str = string.IsNullOrEmpty(prj.Device) ? "" : prj.Device;
                        if (str.Length > 500 - 36)
                            str = str.Substring(0, 500 - 36);
                        len = str.Length;
                        encryptedStr = CreateMD5(str);
                        lenData = BitConverter.GetBytes(len);
                        Array.Copy(lenData, 0, bytes, 0, 4);
                        encryptedData = Encoding.ASCII.GetBytes(encryptedStr);
                        Array.Copy(encryptedData, 0, bytes, 4, 32);
                        byte[] Device = Encoding.ASCII.GetBytes(str);
                        Array.Copy(Device, 0, bytes, 36, Device.Length);
                        cryptoStream.Write(bytes, 0, 500);
                        allStr += str;

                        // write Username
                        bytes = new byte[500];
                        str = string.IsNullOrEmpty(prj.Username) ? "" : prj.Username;
                        if (str.Length > 500 - 36)
                            str = str.Substring(0, 500 - 36);
                        len = str.Length;
                        encryptedStr = CreateMD5(str);
                        lenData = BitConverter.GetBytes(len);
                        Array.Copy(lenData, 0, bytes, 0, 4);
                        encryptedData = Encoding.ASCII.GetBytes(encryptedStr);
                        Array.Copy(encryptedData, 0, bytes, 4, 32);
                        byte[] Username = Encoding.ASCII.GetBytes(str);
                        Array.Copy(Username, 0, bytes, 36, Username.Length);
                        cryptoStream.Write(bytes, 0, 500);
                        allStr += str;

                        // write TitleDl
                        bytes = new byte[500];
                        str = string.IsNullOrEmpty(TitleDl) ? "" : TitleDl;
                        if (str.Length > 500 - 36)
                            str = str.Substring(0, 500 - 36);
                        len = str.Length;
                        encryptedStr = CreateMD5(str);
                        lenData = BitConverter.GetBytes(len);
                        Array.Copy(lenData, 0, bytes, 0, 4);
                        encryptedData = Encoding.ASCII.GetBytes(encryptedStr);
                        Array.Copy(encryptedData, 0, bytes, 4, 32);
                        byte[] title = Encoding.ASCII.GetBytes(str);
                        Array.Copy(title, 0, bytes, 36, title.Length);
                        cryptoStream.Write(bytes, 0, 500);
                        allStr += str;

                        // write DescriptionDl
                        bytes = new byte[500];
                        str = string.IsNullOrEmpty(DescriptionDl) ? "" : DescriptionDl;
                        if (str.Length > 500 - 36)
                            str = str.Substring(0, 500 - 36);
                        len = str.Length;
                        encryptedStr = CreateMD5(str);
                        lenData = BitConverter.GetBytes(len);
                        Array.Copy(lenData, 0, bytes, 0, 4);
                        encryptedData = Encoding.ASCII.GetBytes(encryptedStr);
                        Array.Copy(encryptedData, 0, bytes, 4, 32);
                        byte[] desc = Encoding.ASCII.GetBytes(str);
                        Array.Copy(desc, 0, bytes, 4, desc.Length);
                        cryptoStream.Write(bytes, 0, 500);
                        allStr += str;

                        // Write Params
                        var counter = 0;
                        foreach (var Params in variables.Where(a => !a.IsReadOnly).OrderBy(a => a.FormId))
                        {

                            if (Params is RealVariable real)
                            {
                                var val = float.Parse(string.IsNullOrEmpty(real.Value) ? "0" : real.Value);
                                bytes = BitConverter.GetBytes(val);
                                cryptoStream.Write(bytes, 0, 4);
                                allStr += val;
                                counter++;
                            }

                            if (Params is BoolVariable Bool)
                            {
                                var val = Bool.Value ? 1 : 0;
                                bytes = BitConverter.GetBytes(val);
                                cryptoStream.Write(bytes, 0, 4);
                                allStr += val;
                                counter++;
                            }

                            if (Params is EnumVariable Enum)
                            {
                                var val = Enum.Value;
                                bytes = BitConverter.GetBytes(val);
                                cryptoStream.Write(bytes, 0, 4);
                                allStr += val;
                                counter++;
                            }

                        }

                        bytes = BitConverter.GetBytes(counter);
                        cryptoStream.Write(bytes, 0, 4);
                        encryptedStr = CreateMD5(allStr);
                        bytes = Encoding.ASCII.GetBytes(encryptedStr);
                        cryptoStream.Write(bytes, 0, 32);
                        AppStatics.SaveParams = new List<NetVariable>();
                        AppStatics.SaveParams.AddRange(AppStatics.CurrentParams.Select(a => (NetVariable)a.Clone()));
                        // close Strem
                        cryptoStream.Flush();
                        cryptoStream.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                AppStatics.FileHandler.GenerateLog(new[] { ex.Message });
                return false;
            }

            return true;
        }

        public static bool SaveUpload(FileInfo targetFile, string password, dynamic data, List<NetVariable> variables)
        {
            try
            {
                var keyGenerator = new Rfc2898DeriveBytes(password, SaltSize);
                var rijndael = Rijndael.Create();
                AharProjectType prj = data.project;
                if (prj == null)
                {
                    return false;
                }
                string TitleDl = string.IsNullOrEmpty(data.Title) ? "" : data.Title;
                string DescriptionDl = string.IsNullOrEmpty(data.Description) ? "" : data.Description;
                // BlockSize, KeySize in bit --> divide by 8
                rijndael.IV = keyGenerator.GetBytes(rijndael.BlockSize / 8);
                rijndael.Key = keyGenerator.GetBytes(rijndael.KeySize / 8);
                var allStr = "";
                using (var fileStream = targetFile.Create())
                {
                    // write random salt
                    fileStream.Write(keyGenerator.Salt, 0, SaltSize);

                    using (var cryptoStream = new CryptoStream(fileStream, rijndael.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        byte[] bytes = null;
                        var len = 0;
                        var str = "";
                        var encryptedStr = "";
                        // write project number
                        bytes = new byte[500];
                        str = string.IsNullOrEmpty(prj.ProjectNumber) ? "" : prj.ProjectNumber;
                        if (str.Length > 500 - 36)
                            str = str.Substring(0, 500 - 36);
                        len = str.Length;
                        encryptedStr = CreateMD5(str);
                        var lenData = BitConverter.GetBytes(len);
                        Array.Copy(lenData, 0, bytes, 0, 4);
                        var encryptedData = Encoding.ASCII.GetBytes(encryptedStr);
                        Array.Copy(encryptedData, 0, bytes, 4, 32);
                        byte[] ProjectNum = Encoding.ASCII.GetBytes(str);
                        Array.Copy(ProjectNum, 0, bytes, 36, ProjectNum.Length);
                        cryptoStream.Write(bytes, 0, 500);
                        allStr += str;

                        // write unit number
                        bytes = new byte[500];
                        str = string.IsNullOrEmpty(prj.UnitNumber) ? "" : prj.UnitNumber;
                        if (str.Length > 500 - 36)
                            str = str.Substring(0, 500 - 36);
                        len = str.Length;
                        encryptedStr = CreateMD5(str);
                        lenData = BitConverter.GetBytes(len);
                        Array.Copy(lenData, 0, bytes, 0, 4);
                        encryptedData = Encoding.ASCII.GetBytes(encryptedStr);
                        Array.Copy(encryptedData, 0, bytes, 4, 32);
                        byte[] UnitNum = Encoding.ASCII.GetBytes(str);
                        Array.Copy(UnitNum, 0, bytes, 36, UnitNum.Length);
                        cryptoStream.Write(bytes, 0, 500);
                        allStr += str;

                        // write unit capacity
                        bytes = new byte[500];
                        str = string.IsNullOrEmpty(prj.UnitCapacity) ? "" : prj.UnitCapacity;
                        if (str.Length > 500 - 36)
                            str = str.Substring(0, 500 - 36);
                        len = str.Length;
                        encryptedStr = CreateMD5(str);
                        lenData = BitConverter.GetBytes(len);
                        Array.Copy(lenData, 0, bytes, 0, 4);
                        encryptedData = Encoding.ASCII.GetBytes(encryptedStr);
                        Array.Copy(encryptedData, 0, bytes, 4, 32);
                        byte[] UnitCap = Encoding.ASCII.GetBytes(str);
                        Array.Copy(UnitCap, 0, bytes, 36, UnitCap.Length);
                        cryptoStream.Write(bytes, 0, 500);
                        allStr += str;

                        // write Installation Date
                        bytes = new byte[500];
                        byte[] SelectedDate = BitConverter.GetBytes(prj.InstallationDate);
                        encryptedStr = CreateMD5(prj.InstallationDate.ToString());
                        encryptedData = Encoding.ASCII.GetBytes(encryptedStr);
                        Array.Copy(encryptedData, 0, bytes, 0, 32);
                        Array.Copy(SelectedDate, 0, bytes, 32, SelectedDate.Length);
                        cryptoStream.Write(bytes, 0, 500);
                        allStr += prj.InstallationDate.ToString();
                        // write EmployerName
                        bytes = new byte[500];
                        str = string.IsNullOrEmpty(prj.EmployerName) ? "" : prj.EmployerName;
                        if (str.Length > 500 - 36)
                            str = str.Substring(0, 500 - 36);
                        len = str.Length;
                        encryptedStr = CreateMD5(str);
                        lenData = BitConverter.GetBytes(len);
                        Array.Copy(lenData, 0, bytes, 0, 4);
                        encryptedData = Encoding.ASCII.GetBytes(encryptedStr);
                        Array.Copy(encryptedData, 0, bytes, 4, 32);
                        byte[] EmployerName = Encoding.ASCII.GetBytes(str);
                        Array.Copy(EmployerName, 0, bytes, 36, EmployerName.Length);
                        cryptoStream.Write(bytes, 0, 500);
                        allStr += str;

                        // write Description
                        bytes = new byte[500];
                        str = string.IsNullOrEmpty(prj.Description) ? "" : prj.Description;
                        if (str.Length > 500 - 36)
                            str = str.Substring(0, 500 - 36);
                        len = str.Length;
                        encryptedStr = CreateMD5(str);
                        lenData = BitConverter.GetBytes(len);
                        Array.Copy(lenData, 0, bytes, 0, 4);
                        encryptedData = Encoding.ASCII.GetBytes(encryptedStr);
                        Array.Copy(encryptedData, 0, bytes, 4, 32);
                        byte[] Description = Encoding.ASCII.GetBytes(str);
                        Array.Copy(Description, 0, bytes, 36, Description.Length);
                        cryptoStream.Write(bytes, 0, 500);
                        allStr += str;

                        // write Change Date
                        bytes = new byte[500];
                        byte[] ChangeDate = BitConverter.GetBytes(prj.LastModify);
                        encryptedStr = CreateMD5(prj.LastModify.ToString());
                        encryptedData = Encoding.ASCII.GetBytes(encryptedStr);
                        Array.Copy(encryptedData, 0, bytes, 0, 32);
                        Array.Copy(ChangeDate, 0, bytes, 32, ChangeDate.Length);
                        cryptoStream.Write(bytes, 0, 500);
                        allStr += prj.LastModify.ToString();

                        // write Device
                        bytes = new byte[500];
                        str = string.IsNullOrEmpty(prj.Device) ? "" : prj.Device;
                        if (str.Length > 500 - 36)
                            str = str.Substring(0, 500 - 36);
                        len = str.Length;
                        encryptedStr = CreateMD5(str);
                        lenData = BitConverter.GetBytes(len);
                        Array.Copy(lenData, 0, bytes, 0, 4);
                        encryptedData = Encoding.ASCII.GetBytes(encryptedStr);
                        Array.Copy(encryptedData, 0, bytes, 4, 32);
                        byte[] Device = Encoding.ASCII.GetBytes(str);
                        Array.Copy(Device, 0, bytes, 36, Device.Length);
                        cryptoStream.Write(bytes, 0, 500);
                        allStr += str;

                        // write Username
                        bytes = new byte[500];
                        str = string.IsNullOrEmpty(prj.Username) ? "" : prj.Username;
                        if (str.Length > 500 - 36)
                            str = str.Substring(0, 500 - 36);
                        len = str.Length;
                        encryptedStr = CreateMD5(str);
                        lenData = BitConverter.GetBytes(len);
                        Array.Copy(lenData, 0, bytes, 0, 4);
                        encryptedData = Encoding.ASCII.GetBytes(encryptedStr);
                        Array.Copy(encryptedData, 0, bytes, 4, 32);
                        byte[] Username = Encoding.ASCII.GetBytes(str);
                        Array.Copy(Username, 0, bytes, 36, Username.Length);
                        cryptoStream.Write(bytes, 0, 500);
                        allStr += str;

                        // write TitleDl
                        bytes = new byte[500];
                        str = string.IsNullOrEmpty(TitleDl) ? "" : TitleDl;
                        if (str.Length > 500 - 36)
                            str = str.Substring(0, 500 - 36);
                        len = str.Length;
                        encryptedStr = CreateMD5(str);
                        lenData = BitConverter.GetBytes(len);
                        Array.Copy(lenData, 0, bytes, 0, 4);
                        encryptedData = Encoding.ASCII.GetBytes(encryptedStr);
                        Array.Copy(encryptedData, 0, bytes, 4, 32);
                        byte[] title = Encoding.ASCII.GetBytes(str);
                        Array.Copy(title, 0, bytes, 36, title.Length);
                        cryptoStream.Write(bytes, 0, 500);
                        allStr += str;

                        // write DescriptionDl
                        bytes = new byte[500];
                        str = string.IsNullOrEmpty(DescriptionDl) ? "" : DescriptionDl;
                        if (str.Length > 500 - 36)
                            str = str.Substring(0, 500 - 36);
                        len = str.Length;
                        encryptedStr = CreateMD5(str);
                        lenData = BitConverter.GetBytes(len);
                        Array.Copy(lenData, 0, bytes, 0, 4);
                        encryptedData = Encoding.ASCII.GetBytes(encryptedStr);
                        Array.Copy(encryptedData, 0, bytes, 4, 32);
                        byte[] desc = Encoding.ASCII.GetBytes(str);
                        Array.Copy(desc, 0, bytes, 4, desc.Length);
                        cryptoStream.Write(bytes, 0, 500);
                        allStr += str;
                        // Write Params
                        var counter = 0;
                        foreach (var Params in variables.Where(a => !a.IsReadOnly).OrderBy(a => a.FormId))
                        {

                            if (Params is RealVariable real)
                            {
                                var val = float.Parse(string.IsNullOrEmpty(real.Value) ? "0" : real.Value);
                                bytes = BitConverter.GetBytes(val);
                                cryptoStream.Write(bytes, 0, 4);
                                allStr += val;
                                counter++;
                            }
                            if (Params is BoolVariable Bool)
                            {
                                var val = Bool.Value ? 1 : 0;
                                bytes = BitConverter.GetBytes(val);
                                cryptoStream.Write(bytes, 0, 4);
                                allStr += val;
                                counter++;
                            }
                            if (Params is EnumVariable Enum)
                            {
                                var val = Enum.Value;
                                bytes = BitConverter.GetBytes(val);
                                cryptoStream.Write(bytes, 0, 4);
                                allStr += val;
                                counter++;
                            }

                        }
                        bytes = BitConverter.GetBytes(counter);
                        cryptoStream.Write(bytes, 0, 4);
                        encryptedStr = CreateMD5(allStr);
                        bytes = Encoding.ASCII.GetBytes(encryptedStr);
                        cryptoStream.Write(bytes, 0, 32);
                        AppStatics.SaveParams = new List<NetVariable>();
                        AppStatics.SaveParams.AddRange(AppStatics.CurrentParams.Select(a => (NetVariable)a.Clone()));
                        // close Strem
                        cryptoStream.Flush();
                        cryptoStream.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                AppStatics.FileHandler.GenerateLog(new[] { ex.Message });
                return false;
            }

            return true;
        }

        public static AharProjectType OpenProject(FileInfo sourceFile, string password)
        {
            try
            {
                // read salt
                var fileStream = sourceFile.OpenRead();
                var salt = new byte[SaltSize];
                fileStream.Read(salt, 0, SaltSize);

                // initialize algorithm with salt
                var keyGenerator = new Rfc2898DeriveBytes(password, salt);
                var rijndael = Rijndael.Create();
                rijndael.IV = keyGenerator.GetBytes(rijndael.BlockSize / 8);
                rijndael.Key = keyGenerator.GetBytes(rijndael.KeySize / 8);
                var prj = new AharProjectType();
                // decrypt
                using (var cryptoStream =
                    new CryptoStream(fileStream, rijndael.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    byte[] bytes = null;
                    var len = 0;
                    var md5Data = "";
                    var encryptedStr = "";
                    var str = "";
                    var allStr = "";
                    // Read project number
                    bytes = new byte[500];
                    var readed = cryptoStream.Read(bytes, 0, 500);
                    if (readed != 500)
                    {
                        AppStatics.FileHandler.GenerateLog(new[] { "Corrupted file detected" });
                        return null;
                    }

                    len = BitConverter.ToInt32(bytes, 0);
                    md5Data = Encoding.ASCII.GetString(bytes, 4, 32);
                    str = Encoding.ASCII.GetString(bytes, 36, len);
                    encryptedStr = CreateMD5(str);
                    if (encryptedStr != md5Data)
                    {
                        AppStatics.FileHandler.GenerateLog(new[] { "Corrupted file detected" });
                        return null;
                    }
                    allStr += str;
                    prj.ProjectNumber = str;

                    // Read unit number 
                    bytes = new byte[500];
                    readed = cryptoStream.Read(bytes, 0, 500);
                    if (readed != 500)
                    {
                        AppStatics.FileHandler.GenerateLog(new[] { "Corrupted file detected" });
                        return null;
                    }

                    len = BitConverter.ToInt32(bytes, 0);
                    md5Data = Encoding.ASCII.GetString(bytes, 4, 32);
                    str = Encoding.ASCII.GetString(bytes, 36, len);
                    encryptedStr = CreateMD5(str);
                    if (encryptedStr != md5Data)
                    {
                        AppStatics.FileHandler.GenerateLog(new[] { "Corrupted file detected" });
                        return null;
                    }
                    allStr += str;
                    prj.UnitNumber = str;

                    // Read unit Capacity 
                    bytes = new byte[500];
                    readed = cryptoStream.Read(bytes, 0, 500);
                    if (readed != 500)
                    {
                        AppStatics.FileHandler.GenerateLog(new[] { "Corrupted file detected" });
                        return null;
                    }

                    len = BitConverter.ToInt32(bytes, 0);
                    md5Data = Encoding.ASCII.GetString(bytes, 4, 32);
                    str = Encoding.ASCII.GetString(bytes, 36, len);
                    encryptedStr = CreateMD5(str);
                    if (encryptedStr != md5Data)
                    {
                        AppStatics.FileHandler.GenerateLog(new[] { "Corrupted file detected" });
                        return null;
                    }
                    allStr += str;
                    prj.UnitCapacity = str;

                    // Read Installation Date
                    bytes = new byte[500];
                    readed = cryptoStream.Read(bytes, 0, 500);
                    if (readed != 500)
                    {
                        AppStatics.FileHandler.GenerateLog(new[] { "Corrupted file detected" });
                        return null;
                    }

                    md5Data = Encoding.ASCII.GetString(bytes, 0, 32);
                    str = BitConverter.ToInt64(bytes, 32).ToString();
                    encryptedStr = CreateMD5(str);
                    if (encryptedStr != md5Data)
                    {
                        AppStatics.FileHandler.GenerateLog(new[] { "Corrupted file detected" });
                        return null;
                    }
                    allStr += str;
                    prj.InstallationDate = long.Parse(str);

                    // Read EmployerName 
                    bytes = new byte[500];
                    readed = cryptoStream.Read(bytes, 0, 500);
                    if (readed != 500)
                    {
                        AppStatics.FileHandler.GenerateLog(new[] { "Corrupted file detected" });
                        return null;
                    }

                    len = BitConverter.ToInt32(bytes, 0);
                    md5Data = Encoding.ASCII.GetString(bytes, 4, 32);
                    str = Encoding.ASCII.GetString(bytes, 36, len);
                    encryptedStr = CreateMD5(str);
                    if (encryptedStr != md5Data)
                    {
                        AppStatics.FileHandler.GenerateLog(new[] { "Corrupted file detected" });
                        return null;
                    }
                    allStr += str;
                    prj.EmployerName = str;

                    // Read Description 
                    bytes = new byte[500];
                    readed = cryptoStream.Read(bytes, 0, 500);
                    if (readed != 500)
                    {
                        AppStatics.FileHandler.GenerateLog(new[] { "Corrupted file detected" });
                        return null;
                    }

                    len = BitConverter.ToInt32(bytes, 0);
                    md5Data = Encoding.ASCII.GetString(bytes, 4, 32);
                    str = Encoding.ASCII.GetString(bytes, 36, len);
                    encryptedStr = CreateMD5(str);
                    if (encryptedStr != md5Data)
                    {
                        AppStatics.FileHandler.GenerateLog(new[] { "Corrupted file detected" });
                        return null;
                    }
                    allStr += str;
                    prj.Description = str;


                    // Read Change Date
                    bytes = new byte[500];
                    readed = cryptoStream.Read(bytes, 0, 500);
                    if (readed != 500)
                    {
                        AppStatics.FileHandler.GenerateLog(new[] { "Corrupted file detected" });
                        return null;
                    }

                    md5Data = Encoding.ASCII.GetString(bytes, 0, 32);
                    str = BitConverter.ToInt64(bytes, 32).ToString();
                    encryptedStr = CreateMD5(str);
                    if (encryptedStr != md5Data)
                    {
                        AppStatics.FileHandler.GenerateLog(new[] { "Corrupted file detected" });
                        return null;
                    }
                    allStr += str;
                    prj.LastModify = long.Parse(str);

                    // Read Device
                    bytes = new byte[500];
                    readed = cryptoStream.Read(bytes, 0, 500);
                    if (readed != 500)
                    {
                        AppStatics.FileHandler.GenerateLog(new[] { "Corrupted file detected" });
                        return null;
                    }

                    len = BitConverter.ToInt32(bytes, 0);
                    md5Data = Encoding.ASCII.GetString(bytes, 4, 32);
                    str = Encoding.ASCII.GetString(bytes, 36, len);
                    encryptedStr = CreateMD5(str);
                    if (encryptedStr != md5Data)
                    {
                        AppStatics.FileHandler.GenerateLog(new[] { "Corrupted file detected" });
                        return null;
                    }
                    allStr += str;
                    prj.Device = str;

                    // Read Username
                    bytes = new byte[500];
                    readed = cryptoStream.Read(bytes, 0, 500);
                    if (readed != 500)
                    {
                        AppStatics.FileHandler.GenerateLog(new[] { "Corrupted file detected" });
                        return null;
                    }

                    len = BitConverter.ToInt32(bytes, 0);
                    md5Data = Encoding.ASCII.GetString(bytes, 4, 32);
                    str = Encoding.ASCII.GetString(bytes, 36, len);
                    encryptedStr = CreateMD5(str);
                    if (encryptedStr != md5Data)
                    {
                        AppStatics.FileHandler.GenerateLog(new[] { "Corrupted file detected" });
                        return null;
                    }
                    allStr += str;
                    prj.Username = str;



                    // Read Params
                    var counter = 0;
                    var wParams = new List<NetVariable>();
                    wParams.AddRange(ConfigParams.AllParams.Select(a => (NetVariable)a.Clone()));
                    foreach (var Params in wParams.Where(a => !a.IsReadOnly).OrderBy(a => a.FormId))
                    {
                        bytes = new byte[4];
                        readed = cryptoStream.Read(bytes, 0, 4);
                        if (readed != 4)
                        {
                            AppStatics.FileHandler.GenerateLog(new[] { "Corrupted file detected" });
                            return null;
                        }

                        if (Params is RealVariable real)
                        {
                            float tmp = BitConverter.ToSingle(bytes, 0);
                            var val = (decimal)BitConverter.ToSingle(bytes, 0);
                            real.NetValue = val;
                            allStr += tmp;
                            counter++;
                        }

                        if (Params is BoolVariable Bool)
                        {
                            int tmp = BitConverter.ToInt32(bytes, 0);
                            var val = BitConverter.ToInt32(bytes, 0) == 1;
                            Bool.NetValue = val;
                            allStr += tmp;
                            counter++;
                        }

                        if (Params is EnumVariable Enum)
                        {
                            var val = BitConverter.ToInt32(bytes, 0);
                            Enum.NetValue = val;
                            allStr += val;
                            counter++;
                        }

                    }

                    bytes = new byte[4];
                    readed = cryptoStream.Read(bytes, 0, 4);
                    if (readed != 4)
                    {
                        AppStatics.FileHandler.GenerateLog(new[] { "Corrupted file detected" });
                        return null;
                    }

                    var length = BitConverter.ToInt32(bytes, 0);
                    if (counter != length)
                    {
                        AppStatics.FileHandler.GenerateLog(new[] { "Corrupted file detected" });
                        return null;
                    }
                    bytes = new byte[32];
                    readed = cryptoStream.Read(bytes, 0, 32);
                    if (readed != 32)
                    {
                        AppStatics.FileHandler.GenerateLog(new[] { "Corrupted file detected" });
                        return null;
                    }

                    var md5Hash = CreateMD5(allStr);
                    md5Data = Encoding.ASCII.GetString(bytes, 0, 32);
                    if (md5Hash != md5Data)
                    {
                        AppStatics.FileHandler.GenerateLog(new[] { "Corrupted file detected" });
                        return null;
                    }
                    foreach (var Params in wParams.Where(a => !a.IsReadOnly).OrderBy(a => a.FormId))
                    {
                        if (!Params.IsValid)
                        {
                            if (Params.FormId >= 10000)
                            {
                                AppStatics.AddFaultForm(Params.FormId / 1000 * 10);
                            }
                            else
                            {
                                AppStatics.AddFaultForm(Params.FormId / 10);
                            }

                        }
                    }
                    AppStatics.CurrentParams = new List<NetVariable>();
                    AppStatics.CurrentParams.AddRange(wParams.Select(a => (NetVariable)a.Clone()));
                    AppStatics.SaveParams = new List<NetVariable>();
                    AppStatics.SaveParams.AddRange(wParams.Select(a => (NetVariable)a.Clone()));

                }

                return prj;
            }
            catch (Exception ex)
            {
                AppStatics.FileHandler.GenerateLog(new[] { "Can not open the file", ex.Message });
                return null;
            }


        }

        public static AharProjectType OpenProjectDownload(FileInfo sourceFile, string password, HistoryVariable history, List<NetVariable> paramList)
        {
            // read salt
            var fileStream = sourceFile.OpenRead();
            var salt = new byte[SaltSize];
            fileStream.Read(salt, 0, SaltSize);

            // initialize algorithm with salt
            var keyGenerator = new Rfc2898DeriveBytes(password, salt);
            var rijndael = Rijndael.Create();
            rijndael.IV = keyGenerator.GetBytes(rijndael.BlockSize / 8);
            rijndael.Key = keyGenerator.GetBytes(rijndael.KeySize / 8);
            var prj = new AharProjectType();
            // decrypt
            using (var cryptoStream = new CryptoStream(fileStream, rijndael.CreateDecryptor(), CryptoStreamMode.Read))
            {
                byte[] bytes = null;
                var len = 0;
                var md5Data = "";
                var encryptedStr = "";
                var str = "";
                var allStr = "";
                // Read project number
                bytes = new byte[500];
                var readed = cryptoStream.Read(bytes, 0, 500);
                if (readed != 500)
                {
                    AppStatics.FileHandler.GenerateLog(new[] { "Corrupted file detected" });
                    return null;
                }

                len = BitConverter.ToInt32(bytes, 0);
                md5Data = Encoding.ASCII.GetString(bytes, 4, 32);
                str = Encoding.ASCII.GetString(bytes, 36, len);
                encryptedStr = CreateMD5(str);
                if (encryptedStr != md5Data)
                {
                    AppStatics.FileHandler.GenerateLog(new[] { "Corrupted file detected" });
                    return null;
                }
                allStr += str;
                prj.ProjectNumber = str;

                // Read unit number 
                bytes = new byte[500];
                readed = cryptoStream.Read(bytes, 0, 500);
                if (readed != 500)
                {
                    AppStatics.FileHandler.GenerateLog(new[] { "Corrupted file detected" });
                    return null;
                }

                len = BitConverter.ToInt32(bytes, 0);
                md5Data = Encoding.ASCII.GetString(bytes, 4, 32);
                str = Encoding.ASCII.GetString(bytes, 36, len);
                encryptedStr = CreateMD5(str);
                if (encryptedStr != md5Data)
                {
                    AppStatics.FileHandler.GenerateLog(new[] { "Corrupted file detected" });
                    return null;
                }
                allStr += str;
                prj.UnitNumber = str;

                // Read unit Capacity 
                bytes = new byte[500];
                readed = cryptoStream.Read(bytes, 0, 500);
                if (readed != 500)
                {
                    AppStatics.FileHandler.GenerateLog(new[] { "Corrupted file detected" });
                    return null;
                }

                len = BitConverter.ToInt32(bytes, 0);
                md5Data = Encoding.ASCII.GetString(bytes, 4, 32);
                str = Encoding.ASCII.GetString(bytes, 36, len);
                encryptedStr = CreateMD5(str);
                if (encryptedStr != md5Data)
                {
                    AppStatics.FileHandler.GenerateLog(new[] { "Corrupted file detected" });
                    return null;
                }
                allStr += str;
                prj.UnitCapacity = str;

                // Read Installation Date
                bytes = new byte[500];
                readed = cryptoStream.Read(bytes, 0, 500);
                if (readed != 500)
                {
                    AppStatics.FileHandler.GenerateLog(new[] { "Corrupted file detected" });
                    return null;
                }

                md5Data = Encoding.ASCII.GetString(bytes, 0, 32);
                str = BitConverter.ToInt64(bytes, 32).ToString();
                encryptedStr = CreateMD5(str);
                if (encryptedStr != md5Data)
                {
                    AppStatics.FileHandler.GenerateLog(new[] { "Corrupted file detected" });
                    return null;
                }
                allStr += str;
                prj.InstallationDate = long.Parse(str);

                // Read EmployerName 
                bytes = new byte[500];
                readed = cryptoStream.Read(bytes, 0, 500);
                if (readed != 500)
                {
                    AppStatics.FileHandler.GenerateLog(new[] { "Corrupted file detected" });
                    return null;
                }

                len = BitConverter.ToInt32(bytes, 0);
                md5Data = Encoding.ASCII.GetString(bytes, 4, 32);
                str = Encoding.ASCII.GetString(bytes, 36, len);
                encryptedStr = CreateMD5(str);
                if (encryptedStr != md5Data)
                {
                    AppStatics.FileHandler.GenerateLog(new[] { "Corrupted file detected" });
                    return null;
                }
                allStr += str;
                prj.EmployerName = str;

                // Read Description 
                bytes = new byte[500];
                readed = cryptoStream.Read(bytes, 0, 500);
                if (readed != 500)
                {
                    AppStatics.FileHandler.GenerateLog(new[] { "Corrupted file detected" });
                    return null;
                }

                len = BitConverter.ToInt32(bytes, 0);
                md5Data = Encoding.ASCII.GetString(bytes, 4, 32);
                str = Encoding.ASCII.GetString(bytes, 36, len);
                encryptedStr = CreateMD5(str);
                if (encryptedStr != md5Data)
                {
                    AppStatics.FileHandler.GenerateLog(new[] { "Corrupted file detected" });
                    return null;
                }
                allStr += str;
                prj.Description = str;


                // Read Change Date
                bytes = new byte[500];
                readed = cryptoStream.Read(bytes, 0, 500);
                if (readed != 500)
                {
                    AppStatics.FileHandler.GenerateLog(new[] { "Corrupted file detected" });
                    return null;
                }

                md5Data = Encoding.ASCII.GetString(bytes, 0, 32);
                str = BitConverter.ToInt64(bytes, 32).ToString();
                encryptedStr = CreateMD5(str);
                if (encryptedStr != md5Data)
                {
                    AppStatics.FileHandler.GenerateLog(new[] { "Corrupted file detected" });
                    return null;
                }
                allStr += str;
                prj.LastModify = long.Parse(str);

                // Read Device
                bytes = new byte[500];
                readed = cryptoStream.Read(bytes, 0, 500);
                if (readed != 500)
                {
                    AppStatics.FileHandler.GenerateLog(new[] { "Corrupted file detected" });
                    return null;
                }

                len = BitConverter.ToInt32(bytes, 0);
                md5Data = Encoding.ASCII.GetString(bytes, 4, 32);
                str = Encoding.ASCII.GetString(bytes, 36, len);
                encryptedStr = CreateMD5(str);
                if (encryptedStr != md5Data)
                {
                    AppStatics.FileHandler.GenerateLog(new[] { "Corrupted file detected" });
                    return null;
                }
                allStr += str;
                prj.Device = str;

                // Read Username
                bytes = new byte[500];
                readed = cryptoStream.Read(bytes, 0, 500);
                if (readed != 500)
                {
                    AppStatics.FileHandler.GenerateLog(new[] { "Corrupted file detected" });
                    return null;
                }

                len = BitConverter.ToInt32(bytes, 0);
                md5Data = Encoding.ASCII.GetString(bytes, 4, 32);
                str = Encoding.ASCII.GetString(bytes, 36, len);
                encryptedStr = CreateMD5(str);
                if (encryptedStr != md5Data)
                {
                    AppStatics.FileHandler.GenerateLog(new[] { "Corrupted file detected" });
                    return null;
                }
                allStr += str;
                prj.Username = str;


                // Read DownloadTitle
                bytes = new byte[500];
                if (readed != 500)
                {
                    AppStatics.FileHandler.GenerateLog(new[] { "Corrupted file detected" });
                    return null;
                }

                len = BitConverter.ToInt32(bytes, 0);
                md5Data = Encoding.ASCII.GetString(bytes, 4, 32);
                str = Encoding.ASCII.GetString(bytes, 36, len);
                encryptedStr = CreateMD5(str);
                if (encryptedStr != md5Data)
                {
                    AppStatics.FileHandler.GenerateLog(new[] { "Corrupted file detected" });
                    return null;
                }
                allStr += str;
                history.Title = str;

                // Read Download Desc
                bytes = new byte[500];
                readed = cryptoStream.Read(bytes, 0, 500);
                if (readed != 500)
                {
                    AppStatics.FileHandler.GenerateLog(new[] { "Corrupted file detected" });
                    return null;
                }

                len = BitConverter.ToInt32(bytes, 0);
                md5Data = Encoding.ASCII.GetString(bytes, 4, 32);
                str = Encoding.ASCII.GetString(bytes, 36, len);
                encryptedStr = CreateMD5(str);
                if (encryptedStr != md5Data)
                {
                    AppStatics.FileHandler.GenerateLog(new[] { "Corrupted file detected" });
                    return null;
                }
                allStr += str;
                history.Description = str;

                // Read Params
                var counter = 0;
                foreach (var Params in paramList.Where(a => !a.IsReadOnly).OrderBy(a => a.FormId))
                {
                    bytes = new byte[4];
                    readed = cryptoStream.Read(bytes, 0, 4);
                    if (readed != 4)
                    {
                        AppStatics.FileHandler.GenerateLog(new[] { "Corrupted file detected" });
                        return null;
                    }
                    if (Params is RealVariable real)
                    {
                        float tmp = BitConverter.ToSingle(bytes, 0);
                        var val = (decimal)BitConverter.ToSingle(bytes, 0);
                        real.NetValue = val;
                        allStr += tmp;
                        counter++;
                    }
                    if (Params is BoolVariable Bool)
                    {
                        int tmp = BitConverter.ToInt32(bytes, 0);
                        var val = BitConverter.ToInt32(bytes, 0) == 1;
                        Bool.NetValue = val;
                        allStr += tmp;
                        counter++;
                    }
                    if (Params is EnumVariable Enum)
                    {
                        var val = BitConverter.ToInt32(bytes, 0);
                        Enum.NetValue = val;
                        allStr += val;
                        counter++;
                    }

                }
                bytes = new byte[4];
                readed = cryptoStream.Read(bytes, 0, 4);
                if (readed != 4)
                {
                    AppStatics.FileHandler.GenerateLog(new[] { "Corrupted file detected" });
                    return null;
                }

                var length = BitConverter.ToInt32(bytes, 0);
                if (counter != length)
                {
                    AppStatics.FileHandler.GenerateLog(new[] { "Corrupted file detected" });
                    return null;
                }
                bytes = new byte[32];
                readed = cryptoStream.Read(bytes, 0, 32);
                if (readed != 32)
                {
                    AppStatics.FileHandler.GenerateLog(new[] { "Corrupted file detected" });
                    return null;
                }

                var md5Hash = CreateMD5(allStr);
                md5Data = Encoding.ASCII.GetString(bytes, 0, 32);
                if (md5Hash != md5Data)
                {
                    AppStatics.FileHandler.GenerateLog(new[] { "Corrupted file detected" });
                    return null;
                }
              

            }
            return prj;
        }

        public static void Decrypt(FileInfo sourceFile, string password)
        {
            // read salt
            var fileStream = sourceFile.OpenRead();
            var salt = new byte[SaltSize];
            fileStream.Read(salt, 0, SaltSize);

            // initialize algorithm with salt
            var keyGenerator = new Rfc2898DeriveBytes(password, salt);
            var rijndael = Rijndael.Create();
            rijndael.IV = keyGenerator.GetBytes(rijndael.BlockSize / 8);
            rijndael.Key = keyGenerator.GetBytes(rijndael.KeySize / 8);

            // decrypt
            using (var cryptoStream = new CryptoStream(fileStream, rijndael.CreateDecryptor(), CryptoStreamMode.Read))
            {
                // read data
            }
        }

        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
