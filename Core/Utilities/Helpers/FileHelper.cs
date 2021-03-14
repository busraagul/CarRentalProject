using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public IDataResult<string> Upload(IFormFile file, string path, string fileType)
        {
            var resultFileRotates = FileExtensionRotates(fileType);
            if (resultFileRotates.Success)
            {
                var resultFileControl = FileControl(file, resultFileRotates.Data);
                if (resultFileControl.Success)
                {
                    string replaceFileName = resultFileControl.Data;
                    var files = Path.Combine(path + replaceFileName);
                    using (var fileStream = new FileStream(files, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    return new SuccessDataResult<string>(replaceFileName, "");
                }
                return new ErrorDataResult<string>(resultFileControl.Message);
            }
            return new ErrorDataResult<string>(resultFileRotates.Message);

        }

        public IResult Delete(string path, string file)
        {
            if (file != null)
            {
                if (file == "logo.JPG")
                {
                    return new SuccessResult();
                }
                System.IO.File.Delete(path + file);
                return new SuccessResult();
            }
            return new SuccessResult();
        }


        public IDataResult<string[]> FileExtensionRotates(string FileType)
        {
            if (FileType.ToUpper() == "IMAGE")
            {
                string[] extensions = { "Images", ".jpg", ".tif", ".png", ".jpeg", ".bmp" };
                return new SuccessDataResult<string[]>(extensions);
            }

            return new ErrorDataResult<string[]>();

        }

        public IDataResult<string> FileControl(IFormFile file, string[] fileExtentions)
        {
            var getFileExtensions = Path.GetExtension(file.FileName).ToLower();
            for (int i = 1; i < fileExtentions.Length; i++)
            {
                if (fileExtentions[i].ToLower() == getFileExtensions)
                {
                    string fileName = "\\" + fileExtentions[0] + "\\" + Guid.NewGuid().ToString() + getFileExtensions;
                    return new SuccessDataResult<string>(fileName.Replace('\\', '/'), "");       
                }
            }
            return new ErrorDataResult<string>("Gönderilen dosya türü hatalı !");
        }
    }
}
