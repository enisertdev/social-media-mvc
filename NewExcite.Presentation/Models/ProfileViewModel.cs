namespace NewExcite.Presentation.Models
{
    public class ProfileViewModel
    {
        public string UserName { get; set; }
        public int? PostCount { get; set; }
        public int? FollowerCount { get; set; }
        public int? FollowCount { get; set; }
        public bool? UsersFollowingEachOther { get; set; }
        public bool? TargetUserFollowingCurrentAndNotBeenAccepted { get; set; }
        public bool? CurrentUserFollowingButNotBeenAccepted { get; set; }
    }
}
