# LIS.LIS01A2
This repository has been unmaintained for a few years,
so I have decided to spruce things up. This fork contains
all commits before the GPL license change.
(added in SwatInc/SwatInc.Lis.Lis01A2@ab507a1).

This is an OO implementation of the CLSI LIS01-A2 standard. Specification for Low-Level Protocol to Transfer Messages Between Clinical Laboratory Instruments and 
Computer Systems.

The two libraries in this repo are C# implementations of the same from [Essy.LIS](https://www.nuget.org/packages/Essy.LIS.LIS02A2/).

## Quick Start


### Add GitHub NuGet registry source

> [!WARNING]
> These packages are only available in GitHub packages at the moment
> issue #1
> 
> You will need to generate a personal access token that has `read:packages`

Either add the nuget source to your machine
```sh
dotnet nuget add source \
    --name lis \
    --username USERNAME \
    --password "<your personal access token>" \
    --store-password-in-clear-text \
    https://https://nuget.pkg.github.com/andrewschmidgit/index.json
```

Or add a `nuget.config` file to the root of your repo
```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <!--To inherit the global NuGet package sources remove the <clear/> line below -->
    <clear />
    <add key="nuget" value="https://api.nuget.org/v3/index.json" />
    <add key="nuget" value="https://nuget.pkg.github.com/andrewschmidgit/index.json" />
  </packageSources>
</configuration>
```

> [!NOTE]
> You will need to provide the password in a `nuget.config`
> file located higher up the file tree,
> like in your `$HOME` directory

```xml
<?xml version="1.0" encoding="UTF-8"?>
<configuration>
	<packageSourceCredentials>
		<github>
			<add key="username" value="<your github username>" />
			<add key="cleartextpassword" value="<your personal access token>" />
		</github>
	</packageSourceCredentials>
</configuration>

```

### Add packages
```sh
# LIS01A2
dotnet add package LIS.LIS01A2

# LIS02A2
dotnet add package LIS.LIS02A2
```

### Usage
```cs
// tcp
var listenIP = "127.0.0.1";
UInt16 port = 1111;
var tcpConnection = new Lis01A02TCPConnection(listenIP, port);
var lisConnection = new Lis01A2Connection(tcpConnection);

// serial
var serialPort = new System.IO.Ports.SerialPort("COM1");
var serialConnection = new Lis01A02RS232Connection(serialPort);
var lisConnection = new Lis01A2Connection(serialConnection);

var parser = new LISParser(lisConnection);

// send data progress will trigger this event
parser.OnSendProgress += (object sender, ReceiveRecordEventArgs e) => {};

// incoming LIS frames will trigger this event
parser.OnReceivedRecord += (object sender, ReceiveRecordEventArgs e) => {};

parser.Connection.Connect();

// use the parser to send data
var lisRecordList = new List<AbstractLisRecord>();
var hr = new HeaderRecord();
hr.SenderID = "Some Sender ID Code";
hr.ProcessingID = HeaderProcessingID.Production;
lisRecordList.Add(hr);
var pr = new PatientRecord();
pr.SequenceNumber = 1;
pr.LaboratoryAssignedPatientID = "Sam001";
lisRecordList.Add(pr);
var orderRec = new OrderRecord();
orderRec.SequenceNumber = 1;
orderRec.SpecimenID = "Sam001";
orderRec.TestID = new UniversalTestID();
orderRec.TestID.ManufacturerCode = "T001";
orderRec.ReportType = OrderReportType.Final;
lisRecordList.Add(orderRec);
pr = new PatientRecord();
pr.SequenceNumber = 2;
pr.LaboratoryAssignedPatientID = "Sam002";
lisRecordList.Add(pr);
orderRec = new OrderRecord();
orderRec.SequenceNumber = 1;
orderRec.SpecimenID = "Sam002";
orderRec.TestID = new UniversalTestID();
orderRec.TestID.ManufacturerCode = "T001";
orderRec.ReportType = OrderReportType.Final;
lisRecordList.Add(orderRec);
var tr = new TerminatorRecord();
lisRecordList.Add(tr);
LISParser.SendRecords(lisRecordList);

```
