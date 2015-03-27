using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace JustCopIt.Util
{
    public class FileHelper
    {
        public static List<string> GetDataFromFile( string fileName )
        {
            try
            {
                if ( !File.Exists( fileName ) )
                    return null;

                var arrText = new List<string>();
                var file = new FileStream( fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite );
                using ( var objReader = new StreamReader( file ) )
                {
                    var sLine = "";
                    while ( sLine != null )
                    {
                        sLine = objReader.ReadLine();
                        if ( sLine != null && !string.IsNullOrEmpty( sLine ) )
                            arrText.Add( sLine.Trim() );
                    }
                    objReader.Close();
                    return arrText;
                }
            }
            catch ( Exception ex )
            {
                return null;
            }
        }

        public static bool CheckExistCookieFromFile(string fileName, string cookieName)
        {
            try
            {
                if (!File.Exists(fileName))
                    return false;

                var file = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                using (var objReader = new StreamReader(file))
                {
                    var sLine = "";
                    while (sLine != null)
                    {
                        sLine = objReader.ReadLine();
                        if (sLine != null && !string.IsNullOrEmpty(sLine))
                        {
                            if (sLine.Contains(cookieName))
                            {
                                objReader.Close();
                                return true;
                            }
                        }
                            
                    }
                    objReader.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}