using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.ShowFile;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.StateOfFileSystemMode;

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
        if (_fileInfo is not null && _fileInfo.Exists && _fileInfo.Directory is not null)
        {
            DirectoryInfo? directoryInfo = _fileInfo.Directory;
            Console.WriteLine($"Contents of {directoryInfo.FullName}:");

            foreach (FileInfo fileInfo in directoryInfo.GetFiles())
            {
                Console.WriteLine(fileInfo.Name);
            }
        }
    }

    public void ShowFile(IPrintFile printFileMode, string path)
    {
        if (_fileInfo is not null)
        {
            Console.WriteLine($"Content of {_fileInfo.FullName}:");
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
}