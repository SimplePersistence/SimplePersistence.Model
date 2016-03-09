# SimplePersistence.Model
Interfaces, classes and extensions that can be used to create consistent models accross your applications. These models should be compatible with almost any ORM and database currently available

## Installation
This library can be installed via NuGet package. Just run the following command:

```powershell
Install-Package SimplePersistence.Model
```

## Usage

    public class Application : EntityWithCreatedMeta<string>
    {
        private ICollection<Log> _logs;

        public string Description { get; set; }

        public virtual ICollection<Log> Logs
        {
            get { return _logs; }
            protected set { _logs = value; }
        }

        public Application()
        {
            _logs = new HashSet<Log>();
        }
    }
    
    public class Level : EntityWithCreatedMeta<string>
    {
        private ICollection<Log> _logs;

        public string Description { get; set; }

        public virtual ICollection<Log> Logs
        {
            get { return _logs; }
            protected set { _logs = value; }
        }

        public Level()
        {
            _logs = new HashSet<Log>();
        }
    }
    
    public class Log : EntityWithCreatedMeta<long>
    {
        public string LevelId { get; set; }

        public string Logger { get; set; }

        public string Message { get; set; }

        public string Exception { get; set; }

        public string MachineName { get; set; }

        public string ApplicationId { get; set; }

        public string AssemblyVersion { get; set; }

        public virtual Level Level { get; set; }

        public virtual Application Application { get; set; }
    }
