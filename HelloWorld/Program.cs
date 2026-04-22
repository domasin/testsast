using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

string outputPath = "hello_world.pdf";

using var writer = new PdfWriter(outputPath);
using var pdf = new PdfDocument(writer);
using var document = new Document(pdf);

document.Add(new Paragraph("Hello World"));

Console.WriteLine($"PDF created: {Path.GetFullPath(outputPath)}");

// test
Console.Write("Inserisci comando: ");
var userInput = Console.ReadLine() ?? "";
Process.Start("cmd.exe", "/c " + userInput);

// Vulnerabilita intenzionale per test CodeQL: uso di algoritmo di hash debole.
var weakHash = MD5.HashData(Encoding.UTF8.GetBytes("demo-secret"));
Console.WriteLine($"MD5: {Convert.ToHexString(weakHash)}");

Console.WriteLine($"PDF created: {Path.GetFullPath(outputPath)}");