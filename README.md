The Field Service Toolkit is an idea that was brought to life by two coworkers (Eric Rood and John Coleman).
The program as it is right now is completely done in PowerShell and will return information on a PC that is on the network
and managed by Baylor Scott & White. In addition, it includes automated ways to fix common probems that a technician might
see on the job.

This project will take the original program and revamp it as a C# application.

Goals
  - Include Service Now information along with standard information about the PC
  - Include a way to connect to SCCM in order to run and manage applications that are installed through that platform.
  - Retain all original functionality by using the individual PowerShell scripts as plugins to the UI
