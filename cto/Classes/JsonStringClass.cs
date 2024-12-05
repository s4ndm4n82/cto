namespace cto.Classes;

public class JsonStringClass
{
    public class JsonClassRoot
    {
        public string Token { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string TemplateKey { get; set; } = string.Empty;
        public string Queue { get; set; } = string.Empty;
        public string ProjectId { get; set; } = string.Empty;
        public List<Fields> Fields { get; set; } = [];
        public List<Tables> Tables { get; set; } = [];
        public List<Files> Files { get; set; } = [];
    }

    public class Fields
    {
        public string Name { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }

    public class Tables
    {
        public List<Rows> Rows { get; set; } = [];
    }

    public class Rows
    {
        public List<LineFields> Fields { get; set; } = [];
    }

    public class LineFields
    {
        public string Name { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }

    public class Files
    {
        public string Name { get; set; } = string.Empty;
        public string Data { get; set; } = string.Empty;
    }
}