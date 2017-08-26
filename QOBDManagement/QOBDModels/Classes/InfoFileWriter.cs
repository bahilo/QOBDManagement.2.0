using QOBDCommon.Classes;
using QOBDCommon.Enum;
using QOBDManagement.Helper;
using QOBDModels.Abstracts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QOBDModels.Classes
{
    public class InfoFileWriter : InfoBase
    {
        private string _content;
        private string _subject;
        private string _fullPath;
        private string _fileName;
        private string _ftpHost;
        private string _remotePath;
        private string _baseRemotePath;
        private string _localPath;
        private string _fileNameWithoutExtension;
        private string _typeOfFile;

        public InfoFileWriter(string fileName, EOption typeOfFile, string ftpLogin = "", string ftpPassword = "")
        {
            _typeOfFile = typeOfFile.ToString();
            _login = ftpLogin;
            _password = ftpPassword;
            _fileNameWithoutExtension = fileName;
            _content = "Message here";
        }

        public InfoFileWriter(string fileName, EOption typeOfFile, string ftpPath, string ftpLogin = "", string ftpPassword = "")
            : this(fileName, typeOfFile, ftpLogin, ftpPassword)
        {
            _baseRemotePath = ftpPath;
        }

        public string TxtLogin
        {
            get { return _login; }
            set { setProperty(ref _login, value); }
        }

        public string TxtPassword
        {
            get { return _password; }
            set { setProperty(ref _password, value); }
        }

        public string TxtContent
        {
            get { return _content; }
            set { setProperty(ref _content, value); }
        }

        public string TxtSubject
        {
            get { return _subject; }
            set { setProperty(ref _subject, value); }
        }

        public string TxtFileName
        {
            get { return _fileName; }
            set { setProperty(ref _fileName, value); }
        }

        public string TxtFileNameWithoutExtension
        {
            get { return _fileNameWithoutExtension; }
            set { setProperty(ref _fileNameWithoutExtension, value); }
        }

        public string TxtFileFullPath
        {
            get { return _fullPath; }
            set { setProperty(ref _fullPath, value); }
        }

        public string TxtFtpUrl { get; private set; }

        public void setup()
        {
            string lang = CultureInfo.CurrentCulture.Name.Split('-').FirstOrDefault() ?? "en";
            _ftpHost = ConfigurationManager.AppSettings["ftp"];
            _baseRemotePath = (!string.IsNullOrEmpty(_remotePath) ? _remotePath : ConfigurationManager.AppSettings["ftp_doc_base_folder"]);
            _remotePath = _baseRemotePath + lang + "/" + _typeOfFile + "/";
            _localPath = Utility.getOrCreateDirectory("Docs", _typeOfFile);

            TxtFileName = TxtFileNameWithoutExtension + ".txt";
            TxtFtpUrl = _ftpHost + _remotePath + TxtFileName;
            TxtFileFullPath = Path.Combine(_localPath, TxtFileName);

            if (!Directory.Exists(_localPath))
                Directory.CreateDirectory(_localPath);
        }

        public bool save()
        {
            bool isSavedSuccessfully = false;

            if (!string.IsNullOrEmpty(TxtFileFullPath))
            {
                File.WriteAllText(TxtFileFullPath, TxtContent);
                isSavedSuccessfully = WPFHelper.ftpSendFile(TxtFtpUrl, TxtFileFullPath, _login, _password);
                TxtContent = File.ReadAllText(TxtFileFullPath);
            }

            return isSavedSuccessfully;
        }

        public void read()
        {
            bool isFileFound = false;

            setup();

            if (!string.IsNullOrEmpty(TxtFtpUrl)
                && !string.IsNullOrEmpty(TxtFileFullPath)
                    && !string.IsNullOrEmpty(TxtLogin)
                        && !string.IsNullOrEmpty(TxtPassword))
                isFileFound = WPFHelper.ftpGetFile(TxtFtpUrl, TxtFileFullPath, TxtLogin, TxtPassword);


            if (isFileFound && File.Exists(TxtFileFullPath))
                TxtContent = File.ReadAllText(TxtFileFullPath);
            else
                TxtContent = "";

        }
    }
}
