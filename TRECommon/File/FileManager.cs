using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TRECommon
{
    public class FileManager
    {
        /// <summary>
        /// 根录径
        /// </summary>
        protected string _path = "";
        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }

        protected string _rootPath = "";
        public string RootPath
        {
            get { return _rootPath; }
            set { this._rootPath = value; }
        }

        public FileManager() { }
        public FileManager(string rootpath)
        {
            RootPath = rootpath;
        }  //传根目目录
        public FileManager(string path, string rootPath)
        {
            Path = path;
            RootPath = rootPath;
        }

        /// <summary>
        /// 新建件夹
        /// </summary>
        /// <param name="name"></param>
        /// <param name="parentName"></param>
        /// <returns>0失败 1：成功;</returns>
        public static int CreateFolder(string name, string parentName)
        {
            return CreateFolder(name, parentName, false);
        }

        /// <summary>
        /// 新建文件夹
        /// </summary>
        /// <param name="name">文件夹名称</param>
        /// <param name="parentName">路径</param>
        /// <param name="fullpath">是否创建符合参数完整路径</param>
        /// <param name="path">路径</param>
        /// <returns>0失败 1：成功;</returns>
        public static int CreateFolder(string name, string path, bool fullpath)
        {
            if (fullpath)
            {
                path = path + "//" + name;
                DirectoryInfo di = new DirectoryInfo(path);
                di.Create();
                if (Directory.Exists(path))
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                DirectoryInfo di = new DirectoryInfo(path);
                if (di.Exists)
                {
                    di.CreateSubdirectory(name);
                    return 1;
                }
                else
                {
                    return 0;

                }
            }


        }

        /// <summary>
        /// 删除文件夹
        /// </summary>
        /// <param name="path"></param>
        public static int DeleteFolder(string path)
        {
            return DeleteFolder(path, false);
        }

        /// <summary>
        /// 删除文件夹
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="recursive">True 删除 子目录及文件 False 如有子目录则不删除</param>
        /// <returns></returns>
        public static int DeleteFolder(string path, bool recursive)
        {
            if (Directory.Exists(path))
            {
                try
                {
                    Directory.Delete(path, recursive);
                    return 1;
                }
                catch (Exception e)
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 移动文件夹 如果目标文件夹存在则在该目录下创建原文件夹名,如果目标文件夹不存在。则创建目径文件夹;
        /// </summary>
        /// <param name="oldPath"></param>
        /// <param name="newPath"></param>
        public static int MoveFolder(string oldPath, string newPath)
        {
            if (Directory.Exists(oldPath))
            {
                if (Directory.Exists(newPath))
                {
                    oldPath = oldPath.EndsWith("\\") ? oldPath.Substring(0, oldPath.Length - 2) : oldPath;
                    newPath = newPath.EndsWith("\\") ? newPath : newPath + "\\";
                    string tmp = "";
                    tmp = oldPath.Substring(oldPath.LastIndexOf("\\") + 1, oldPath.Length - oldPath.LastIndexOf("\\") - 1);
                    tmp = newPath + tmp + "\\";
                    Directory.Move(oldPath, tmp);
                    return 1;
                }
                else
                {
                    Directory.Move(oldPath, newPath);
                    return 0;
                }
            }
            else
            {
                return 1;
            }

        }

        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="path"></param>
        public static int CreateFile(string filename, string path)
        {
            return CreateFile(filename, path, "");
        }

        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="path"></param>
        /// <param name="contents">内容</param>
        public static int CreateFile(string filename, string path, string contents)
        {
            string fullfilename = path.EndsWith("\\") ? path + filename : path + "\\" + filename;
            if (File.Exists(fullfilename))
            {
                return 0; ;
            }
            else
            {
                if (contents == null || contents.Length == 0)
                {
                    try
                    {
                        FileStream fs = File.Create(fullfilename);
                        fs.Close();
                    }
                    catch (Exception ex) { }
                    return 1;
                }
                else
                {
                    try
                    {
                        FileStream fs = File.Create(path + "\\" + filename);
                        byte[] data = new UTF8Encoding().GetBytes(contents);
                        fs.Write(data, 0, data.Length);
                        fs.Close();
                    }
                    catch (Exception ex)
                    { }

                    return 0;
                }
            }
        }

        /// <summary>
        /// 读取文件
        /// </summary>
        /// <param name="name"></param>
        /// <param name="parentName"></param>
        public static string OpenText(string filename, string path)
        {
            path = path.EndsWith("\\") ? path + filename : path + "\\" + filename;
            StreamReader sr = File.OpenText(path);
            StringBuilder output = new StringBuilder();
            string rl;
            while ((rl = sr.ReadLine()) != null)
            {
                output.Append(rl);
            }
            sr.Close();
            return output.ToString();
        }

        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="filename">文件名</param>
        /// <param name="path">路径</param>
        /// <param name="existCreate">文件名果存在是否进行操作,True操作 Flase 不操作</param>
        /// <param name="existSave">如果存在是否覆盖 True,覆盖,False,新增</param>
        /// <param name="overlay">方式。True,直接覆盖，false,追加至末尾</param>
        /// <param name="contents">内容</param>
        /// <returns></returns>
        public static int SaveFile(string filename, string path, bool existCreate, bool existSave, bool overlay, string contents)
        {
            string fullfilename = path.EndsWith("\\") ? path + filename : path + "\\" + filename;
            if (File.Exists(fullfilename) && !existCreate)
            {
                return 0;
            }
            else
            {
                if (File.Exists(fullfilename))
                {
                    //如果存在及新增保存--新文件名
                    if (!existSave)
                    {
                        string newfullfilename = fullfilename.Substring(0, fullfilename.LastIndexOf(".") - 1);
                        string ext = fullfilename.Substring(fullfilename.LastIndexOf(".") + 1, fullfilename.Length - fullfilename.LastIndexOf(".") - 1);

                        int i = 1;
                        while (true)
                        {
                            if (!File.Exists(newfullfilename + "新建文件" + i.ToString() + "." + ext))
                            {
                                fullfilename = newfullfilename + "新建文件" + i.ToString() + "." + ext;
                                break;
                            }
                            i++;
                        }

                    }

                    //如果覆盖。直接保存
                    if (overlay)
                    {
                        FileStream fs = File.Create(fullfilename);
                        byte[] data = new UTF8Encoding().GetBytes(contents);
                        fs.Write(data, 0, data.Length);
                        fs.Flush();
                        fs.Close();
                    }
                    else
                    {
                        ///追加保存
                        StreamWriter sw = File.AppendText(fullfilename);
                        sw.WriteLine(contents);
                        sw.Flush();
                        sw.Close();
                    }
                }
                else
                {
                    //如果文件不存在直接保存
                    FileStream fs = File.Create(fullfilename);
                    byte[] data = new UTF8Encoding().GetBytes(contents);
                    fs.Write(data, 0, data.Length);
                    fs.Flush();
                    fs.Close();

                }

                return 1;

            }
        }


        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="path"></param>
        public static int DeleteFile(string filename, string path)
        {
            string fullname = path.EndsWith("\\") ? path + filename : path + "\\" + filename;
            if (File.Exists(fullname))
            {
                try
                {
                    File.Delete(fullname);
                    return 1;
                }
                catch(Exception ex)
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 移动文件
        /// </summary>
        /// <param name="oldPath"></param>
        /// <param name="newPath"></param>
        public static int MoveFile(string oldPath, string newPath)
        {
            if (File.Exists(oldPath))
            {
                if (File.Exists(newPath))
                {
                    return 0; ///目标存在同名文件。不允许移动
                }

                string newName = "";
                if (Directory.Exists(newPath))
                {
                    FileInfo fi = new FileInfo(oldPath);
                    newName = newPath + fi.Name;
                }
                else
                {
                    newName = newPath;
                }

                File.Move(oldPath, newName);

                return 1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 复制文件夹
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public static bool CopyFolder(string source, string destination)
        {
            try
            {
                String[] files;
                if (destination[destination.Length - 1] != System.IO.Path.DirectorySeparatorChar)
                    destination += System.IO.Path.DirectorySeparatorChar;
                if (!Directory.Exists(destination)) Directory.CreateDirectory(destination);
                files = Directory.GetFileSystemEntries(source);
                foreach (string element in files)
                {
                    if (Directory.Exists(element))
                        CopyFolder(element, destination + System.IO.Path.GetFileName(element));
                    else
                        File.Copy(element, destination + System.IO.Path.GetFileName(element), true);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// 查看路径下所有文件及文件夹
        /// </summary>
        /// <param name="path">Server.MapPath(@"~/Upload/")</param>
        /// <param name="serarch">按名称搜索 为空不执行 不搜索：该值必须为""</param>
        /// <param name="searchOption">搜索时是否包含子目录,1：，0：其它不包含 不搜索该值必须为 0</param>
        /// <returns></returns>
        public List<FileManagerInfo> GetFileAndFolderList(string path, string serarch, int searchOption)
        {
            if (path == "") { path = RootPath; }

            List<FileManagerInfo> list = new List<FileManagerInfo>();

            if (Directory.Exists(path))
            {
                if (RootPath != path)
                {
                    FileManagerInfo pm = new FileManagerInfo(); //parentModel 根目连接地址
                    pm.FullName = RootPath;
                    pm.Name = "根目录";
                    pm.IsFolder = true;
                    pm.CreationTime = DateTime.Now;
                    list.Add(pm);

                    FileManagerInfo um = new FileManagerInfo(); // upper 上层
                    um.Name = "上级";
                    um.FullName = Directory.GetParent(path).FullName;
                    um.IsFolder = true;
                    um.CreationTime = DateTime.Now;
                    list.Add(um);
                }
                else
                {
                    FileManagerInfo pm = new FileManagerInfo(); //parentModel 根目连接地址
                    pm.FullName = RootPath;
                    pm.Name = "根目录";
                    pm.IsFolder = true;
                    pm.CreationTime = DateTime.Now;
                    list.Add(pm);
                }

                FileInfo[] fileList = GetFileInfoList(path, serarch, searchOption);
                DirectoryInfo[] dirList = GetFileFolderInfoList(path, serarch, searchOption);


                if (dirList.Length > 0)
                {
                    foreach (DirectoryInfo dm in dirList)
                    {
                        FileManagerInfo model = new FileManagerInfo();
                        model.RootPath = RootPath;
                        model.FullName = dm.FullName;
                        model.Name = dm.Name;
                        model.Extension = dm.Extension;
                        model.CreationTime = dm.CreationTime;
                        model.LastAccessTime = dm.LastAccessTime;
                        model.LastWriteTime = dm.LastWriteTime;
                        model.IsFolder = true;
                        list.Add(model);
                    }
                }


                if (fileList.Length > 0)
                {
                    foreach (FileInfo fm in fileList)
                    {
                        FileManagerInfo model = new FileManagerInfo();
                        model.RootPath = RootPath;
                        model.FullName = fm.FullName;
                        model.Name = fm.Name;
                        model.Extension = fm.Extension;
                        model.CreationTime = fm.CreationTime;
                        model.LastAccessTime = fm.LastAccessTime;
                        model.LastWriteTime = fm.LastWriteTime;
                        model.Length = fm.Length;
                        model.IsFolder = false;
                        list.Add(model);
                    }
                }
            }


            return list;
        }

        /// <summary>
        /// 查看路径下的所有文件
        /// </summary>
        /// <param name="path">完整的文件目录路径</param>
        /// <param name="serarch">按名称搜索 为空不执行 不搜索：该值必须为""</param>
        /// <param name="searchOption">搜索时是否包含子目录,1：，0：其它不包含 不搜索该值必须为 0</param>
        /// <returns> FileInfo[](不为NULL，无数据时返length=0)</returns>
        public FileInfo[] GetFileInfoList(string path, string serarch, int searchOption)
        {
            if (path == "") { path = RootPath; }

            if (Directory.Exists(path))
            {
                DirectoryInfo DirInfo = new DirectoryInfo(path);
                FileInfo[] list = DirInfo.GetFiles();

                if (serarch == "" && searchOption == 0)
                {
                    list = DirInfo.GetFiles();
                }
                else
                {
                    list = DirInfo.GetFiles(serarch, searchOption == 1 ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
                }

                return list;
            }
            return new FileInfo[0];
        }

        /// <summary>
        /// 查看路径下的子目录
        /// </summary>
        /// <param name="path">完整的文件目录路径</param>
        /// <param name="serarch">按名称搜索 为空不执行 不搜索：该值必须为""</param>
        /// <param name="searchOption">搜索时是否包含子目录,1：，0：其它不包含 不搜索该值必须为 0</param>
        /// <returns> DirectoryInfo[](不为NULL，无数据时返length=0)</returns>
        public DirectoryInfo[] GetFileFolderInfoList(string path, string serarch, int searchOption)
        {

            if (path == "") { path = RootPath; }

            if (Directory.Exists(path))
            {
                DirectoryInfo DirInfo = new DirectoryInfo(path);
                DirectoryInfo[] list = DirInfo.GetDirectories();
                if (serarch == "" && searchOption == 0)
                {
                    list = DirInfo.GetDirectories();
                }
                else
                {
                    list = DirInfo.GetDirectories(serarch, searchOption == 1 ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
                }

                return list;
            }
            return new DirectoryInfo[0];
        }

        public string ShowMessage(string key, string value)
        {
            return key + "," + value;
        }

    }


    [Serializable]
    public class FileManagerInfo
    {
        protected string _rootPath = "";
        protected string _fullName = "";
        protected string _name = "";
        protected string _extension = "";
        protected DateTime _creationTime = DateTime.Now;
        protected DateTime _lastAccessTime = DateTime.Now; //上次访问
        protected DateTime _lastWriteTime = DateTime.Now;  //上次写入
        protected long _length = 0;
        protected bool _isFolder = false;

        public string RootPath
        {
            get { return _rootPath; }
            set { this._rootPath = value; }
        }
        public string FullName
        {
            get { return _fullName; }
            set { this._fullName = value; }
        }
        public string Name
        {
            get { return _name; }
            set { this._name = value; }
        }
        public string Extension
        {
            get { return _extension; }
            set { this._extension = value; }
        }
        public DateTime CreationTime
        {
            get { return _creationTime; }
            set { this._creationTime = value; }
        }
        public DateTime LastAccessTime
        {
            get { return _lastAccessTime; }
            set { this._lastAccessTime = value; }
        }
        public DateTime LastWriteTime
        {
            get { return _lastWriteTime; }
            set { this._lastWriteTime = value; }
        }
        public long Length
        {
            get { return _length; }
            set { this._length = value; }
        }
        public bool IsFolder
        {
            get { return _isFolder; }
            set { this._isFolder = value; }
        }

    }

}