namespace Formula.Releases.Domain
{
    public class Release
    {
        public int Id { get; set; }
        public bool IsPreview { get; set; }
        public string Description { get; set; }
        public string VersionName { get; set; }
        public string Url { get; set; }
        public string ReleaseDate { get; set; }
    }
}
