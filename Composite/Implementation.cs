using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    public abstract class FileSystemItem
    {
        public string Name { get; }
        public abstract long GetSize();
        public FileSystemItem(string name)
        {
            Name = name;
        }
    }

    public class File : FileSystemItem
    {
        private readonly long _size;

        public File(string name, long size) : base(name)
        {
            _size = size;
        }
        public override long GetSize()
        {
            return _size; ;
        }
    }

    public class Directory : FileSystemItem
    {
        private readonly List<FileSystemItem> _directories = new List<FileSystemItem>();
        private readonly long _size;

        public Directory(string name, long size) : base(name)
        {
            _size = size;
        }
        public void Add(FileSystemItem itemToAdd)
        {
            _directories.Add(itemToAdd);
        }
        public void Remove(FileSystemItem itemToRemove)
        {
            _directories.Remove(itemToRemove);
        }
        public override long GetSize()
        {
            var size = _size;
            foreach (var directory in _directories)
            {
                size += directory.GetSize();
            }
            return size;
        }
    }
}
