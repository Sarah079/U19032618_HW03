using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace U19032618_HW03.Models
{
    public class FileModel
    {
        public string mFileName;
        public string _documentlink;
        public string _imagelink;
        public string _videolink;
        public string _filetype;
        public FileModel()
        {

        }
        public FileModel(string FileName, string documentlink, string imagelink, string videolink, string FileType)
        {
            mFileName = FileName;
            _documentlink = documentlink;
            _imagelink = imagelink;
            _videolink = videolink;
            _filetype = FileType;
        }

        public string FileName
        {
            get { return mFileName; }
            set { mFileName = value; }
        }
        public string Documentlink
        {
            get { return _documentlink; }
            set { _documentlink = value; }
        }
        public string Imagelink
        {
            get { return _imagelink; }
            set { _imagelink = value; }
        }
        public string Videolink
        {
            get { return _videolink; }
            set { _videolink = value; }
        }
        public string filetype
        {
            get { return _filetype; }
            set { _filetype = value; }
        }
    }
}