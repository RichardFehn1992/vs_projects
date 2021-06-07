using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Text.RegularExpressions;

class FileHandler
{
    // return execution direction path --> example: 'C\projects'
    public string exeDir()
    {
        string str = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);

        // str needs to be filtered to be in desired format
        return str.Substring(6);
    }

    // check if file exist
    public bool fileExist(string path)
    {
        return File.Exists(path);
    }

    // check if directory exist
    public bool directoryExist(string path)
    {
        return Directory.Exists(path);
    }

    public FileInfo[] get_dirFileList(string path)
    {
        DirectoryInfo dir = new DirectoryInfo(path);
        return dir.GetFiles();
    }

    public DirectoryInfo[] get_dirFolderList(string path)
    {
        DirectoryInfo dir = new DirectoryInfo(path);
        return dir.GetDirectories();
    }

    // read file line by line and fill strList
    public void readFile_lineByLine(string path, List<string> strList)
    {
        StreamReader sr = new StreamReader(path);

        String line = sr.ReadLine();

        while (line != null)
        {
            strList.Add(line);
            line = sr.ReadLine();
        }

        sr.Close();
    }

    // read file and return the content
    public string readFile_complete(string path)
    {
        StreamReader sr = new StreamReader(path);
        String content = sr.ReadToEnd();
        sr.Close();

        return content;
    }

    // create file, note: existing files will be overritten
    public bool createFile(string path)
    {
        File.CreateText(path);
        return fileExist(path);
    }

    // delete file
    public void deleteFile(string path)
    {
        File.Delete(path);
    }

    // delete directory
    public void deleteDirectory(string path)
    {
        if (!directoryExist(path))
        {
            return;
        }

        DirectoryInfo dir = new DirectoryInfo(path);
        dir.Delete(true);
    }

    public void renameFile(string path, string newPath)
    {
        if (!fileExist(path))
        {
            return;
        }

        System.IO.File.Move(path, newPath);
    }

    public void cpyFile(string pathSrc, string pathDst)
    {
        if (!fileExist(pathSrc))
        {
            return;
        }

        System.IO.File.Copy(pathSrc, pathDst, true);
    }

    // write file
    public void writeFile(string path, string str, bool addNextLine)
    {
        if (!fileExist(path))
        {
            return;
        }

        using (StreamWriter sw = File.AppendText(path))
        {
            if (addNextLine)
            {
                sw.WriteLine(str);
            }
            else
            {
                sw.Write(str);
            }
        }

    }
}