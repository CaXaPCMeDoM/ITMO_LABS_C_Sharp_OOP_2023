using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.ShowFile;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.StrategyOfFileSystemMode;

public class FileCommandLocal : IFileCommand
{
    private FileInfo? _fileInfo;
    public void Connect(string address)
    {
        _fileInfo = new FileInfo(address);
    }

    public void Disconnect()
    {
        _fileInfo = null;
    }

    public void NavigateToDirectory(string path)
    {
        if (_fileInfo is not null)
        {
            string fullPath = Path.Combine(_fileInfo.FullName, path);
            _fileInfo = new FileInfo(fullPath);
        }
    }

    public void ListDirectoryContents(int depth)
    {
        if (_fileInfo is not null && _fileInfo.Directory is not null)
        {
            ListDirectory(_fileInfo.FullName, depth);
        }
    }

    public void ShowFile(IPrintFile printFileMode, string path)
    {
        if (_fileInfo is not null)
        {
            printFileMode.PrintFile(File.ReadAllText(_fileInfo.FullName));
        }
    }

    public void MoveFile(string sourcePath, string destinationPath)
    {
        if (_fileInfo is not null)
        {
            string sourceFullPath = Path.Combine(_fileInfo.FullName, sourcePath);
            string destinationFullPath = Path.Combine(_fileInfo.FullName, destinationPath);
            File.Move(sourceFullPath, destinationFullPath);
        }
    }

    public void CopyFile(string sourcePath, string destinationPath)
    {
        if (_fileInfo is not null)
        {
            string fullSourcePath = Path.Combine(_fileInfo.FullName, sourcePath);
            string fullDestinationPath = Path.Combine(_fileInfo.FullName, destinationPath);

            if (File.Exists(fullSourcePath))
            {
                File.Copy(fullSourcePath, fullDestinationPath);
            }
        }
    }

    public void DeleteFile(string path)
    {
        if (_fileInfo is not null)
        {
            string fullPath = Path.Combine(_fileInfo.FullName, path);

            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
        }
    }

    public void RenameFile(string path, string newName)
    {
        if (_fileInfo is not null)
        {
            string fullSourcePath = Path.Combine(_fileInfo.FullName, path);
            string fullDestinationPath = Path.Combine(_fileInfo.FullName, newName);

            if (File.Exists(fullSourcePath))
            {
                File.Move(fullSourcePath, fullDestinationPath);
            }
        }
    }

    private void ListDirectory(string path, int depth)
    {
        Console.Write(new string(' ', depth * 4));

        var directoryInfo = new DirectoryInfo(path);
        Console.WriteLine(directoryInfo.Name + "\\");

        FileInfo[] files = directoryInfo.GetFiles();
        foreach (FileInfo file in files)
        {
            Console.Write(new string(' ', (depth + 1) * 4));
            Console.WriteLine(file.Name);
        }

        DirectoryInfo[] subDirectories = directoryInfo.GetDirectories();
        foreach (DirectoryInfo subDirectory in subDirectories)
        {
            ListDirectory(subDirectory.FullName, depth + 1);
        }
    }
}