# dsa-db
Fetch Contacts from DSA DB

# Manual "How use parser"  
```csharp
    Console.WriteLine("Input Searching word");  
    var search = Console.ReadLine();  
    var html = HtmlGetter.GetHtml(search);  
    CourtGovUaParser parser = new CourtGovUaParser(html);  
    var records = parser.ParseToRecords();  
```

1. `CourtGovUaParser.ParseToRecords()` return List<Records>. Now you can do everything with this list, for example add to the database.  
2. `HtmlGetter.GetHtml()` return html code from page including ajax using Selenium
3. If want just test parser, without using Selenium, in the folder 'Test' being two files. One of these files have HTML code from http://email.court.gov.ua/ 
and another file output example
4. For print List<Record> use `PrintConsoleRecords.PrintRecords(List<Record> records)`
5. Example for points 3 and 4:  
```csharp
CourtGovUaParser parser = new CourtGovUaParser(HtmlStringForParser.GetTestString());  
PrintConsoleRecords.PrintRecords(parser.ParseToRecords());
```
6. Also you can write list of records to csv. Example:
```csharp
RecordsCSVReport report = new RecordsCSVReport("test"); // as a constructor parameter set file name
report.GenerateFile(parser.ParseToRecords()); //  File will be created in folder 'Data'
```
   
