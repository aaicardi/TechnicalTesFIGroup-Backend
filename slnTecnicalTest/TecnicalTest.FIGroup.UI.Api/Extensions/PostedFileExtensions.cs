using System.Text;
using System.Text.RegularExpressions;

namespace TecnicalTest.FIGroup.UI.Api.Extensions;

public static class PostedFileExtensions
{
    private const int ImageMinimumBytes = 100;

    private const long ImageMaximumBytes = 10485760;

    public static bool IsImage(this IFormFile? postedFile)
    {
        if (postedFile == null) return false;

        //-------------------------------------------
        //  Check the image extension
        //-------------------------------------------
        var postedFileExtension = Path.GetExtension(postedFile.FileName);
        if (!string.Equals(postedFileExtension, ".jpg", StringComparison.OrdinalIgnoreCase)
            && !string.Equals(postedFileExtension, ".png", StringComparison.OrdinalIgnoreCase)
            && !string.Equals(postedFileExtension, ".gif", StringComparison.OrdinalIgnoreCase)
            && !string.Equals(postedFileExtension, ".jpeg", StringComparison.OrdinalIgnoreCase)
            && !string.Equals(postedFileExtension, ".heic", StringComparison.OrdinalIgnoreCase)
            && !string.Equals(postedFileExtension, ".raw", StringComparison.OrdinalIgnoreCase))
            return false;

        //-------------------------------------------
        //  Attempt to read the file and check the first bytes
        //-------------------------------------------
        try
        {
            if (!postedFile.OpenReadStream().CanRead) return false;
            //------------------------------------------
            //   Check whether the image size exceeding the limit or not
            //------------------------------------------ 
            if (postedFile.Length < ImageMinimumBytes) return false;

            var buffer = new byte[ImageMinimumBytes];
            var unused = postedFile.OpenReadStream().Read(buffer, 0, ImageMinimumBytes);
            var content = Encoding.UTF8.GetString(buffer);
            if (Regex.IsMatch(content,
                    @"<script|<html|<head|<title|<body|<pre|<table|<a\s+href|<img|<plaintext|<cross\-domain\-policy",
                    RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Multiline))
                return false;
        }
        catch (Exception)
        {
            return false;
        }

        return true;
    }

    public static bool IsValidSize(this IFormFile? postedFile)
    {
        if (postedFile == null) return false;

        return postedFile.Length <= ImageMaximumBytes;
    }
}

