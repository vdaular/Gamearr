using FluentValidation;
using NzbDrone.Core.Annotations;
using NzbDrone.Core.ThingiProvider;
using NzbDrone.Core.Validation;

namespace NzbDrone.Core.Download.Clients.QBittorrent
{
    public class QBittorrentSettingsValidator : AbstractValidator<QBittorrentSettings>
    {
        public QBittorrentSettingsValidator()
        {
            RuleFor(c => c.Host).ValidHost();
            RuleFor(c => c.Port).InclusiveBetween(1, 65535);
        }
    }

    public class QBittorrentSettings : IProviderConfig
    {
        private static readonly QBittorrentSettingsValidator Validator = new QBittorrentSettingsValidator();

        public QBittorrentSettings()
        {
            Host = "localhost";
            Port = 8080;
            MusicCategory = "gamearr";
        }

        [FieldDefinition(0, Label = "Host", Type = FieldType.Textbox)]
        public string Host { get; set; }

        [FieldDefinition(1, Label = "Port", Type = FieldType.Textbox)]
        public int Port { get; set; }

        [FieldDefinition(2, Label = "Username", Type = FieldType.Textbox)]
        public string Username { get; set; }

        [FieldDefinition(3, Label = "Password", Type = FieldType.Password)]
        public string Password { get; set; }

        [FieldDefinition(4, Label = "Category", Type = FieldType.Textbox, HelpText = "Adding a category specific to Gamearr avoids conflicts with unrelated downloads, but it's optional")]
        public string MusicCategory { get; set; }

        [FieldDefinition(5, Label = "Recent Priority", Type = FieldType.Select, SelectOptions = typeof(QBittorrentPriority), HelpText = "Priority to use when grabbing albums released within the last 14 days")]
        public int RecentTvPriority { get; set; }

        [FieldDefinition(6, Label = "Older Priority", Type = FieldType.Select, SelectOptions = typeof(QBittorrentPriority), HelpText = "Priority to use when grabbing albums released over 14 days ago")]
        public int OlderTvPriority { get; set; }

        [FieldDefinition(7, Label = "Initial State", Type = FieldType.Select, SelectOptions = typeof(QBittorrentState), HelpText = "Initial state for torrents added to qBittorrent")]
        public int InitialState { get; set; }

        [FieldDefinition(8, Label = "Use SSL", Type = FieldType.Checkbox, HelpText = "Use a secure connection. See Options -> Web UI -> 'Use HTTPS instead of HTTP' in qBittorrent.")]
        public bool UseSsl { get; set; }

        public NzbDroneValidationResult Validate()
        {
            return new NzbDroneValidationResult(Validator.Validate(this));
        }
    }
}
