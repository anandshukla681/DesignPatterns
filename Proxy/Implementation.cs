using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public interface IDocument
    {
        void DisplayContent();
    }
    public class Document : IDocument
    {
        private readonly string _fileName;

        public string? Title { get; private set; }
        public string? Content { get; private set; }
        public int AuthorId { get; private set; }
        public DateTimeOffset LastAccessed { get; private set; }
        public Document(string fileName)
        {
            _fileName = fileName;
            LoadDocument(_fileName);
        }

        private void LoadDocument(string fileName)
        {
            Console.WriteLine("Loadin docs");

        }
        public void DisplayContent()
        {
            Console.WriteLine("Displaying content");
        }
    }

    public class DocumentProxy : IDocument
    {
        private readonly string _fileName;
        private Lazy<Document> _document;
        public DocumentProxy(string fileName)
        {
            _fileName = fileName;
            _document = new Lazy<Document>(() => new Document(_fileName));
        }
        public void DisplayContent()
        {
            _document.Value.DisplayContent();
        }
    }

    public class ProtectedDocumentProxy : IDocument
    {
        private readonly string _fileName;
        readonly string Permission = "Viewer";
        readonly DocumentProxy documentProxy;
        public ProtectedDocumentProxy(string fileName, string permission)
        {
            _fileName = fileName;
            Permission = permission;
            documentProxy = new DocumentProxy(_fileName);

        }
        public void DisplayContent()
        {
            if (Permission != "Viewer")
            {
                throw new UnauthorizedAccessException(Permission);
            }
            documentProxy.DisplayContent();
        }
    }

}
