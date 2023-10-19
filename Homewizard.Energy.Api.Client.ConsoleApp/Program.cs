
using Figgle;
using Homewizard.Energy.Api.Client.Clients;

var client = new WifiEnergySocketClient(new Uri("http://192.168.0.242"));

//5C:2F:AF:0C:CF:04 @ 192.168.0.242

var basicInformation = await client.GetBasicInformation();
Console.WriteLine("Basic Information");
Console.WriteLine($"{nameof(basicInformation.ProductName),-15}: {basicInformation.ProductName}");
Console.WriteLine($"{nameof(basicInformation.ProductType),-15}: {basicInformation.ProductType}");
Console.WriteLine($"{nameof(basicInformation.ApiVersion),-15}: {basicInformation.ApiVersion}");
Console.WriteLine($"{nameof(basicInformation.FirmwareVersion),-15}: {basicInformation.FirmwareVersion}");
Console.WriteLine($"{nameof(basicInformation.Serial),-15}: {basicInformation.Serial}");
Console.WriteLine();


while (true)
{
    var res = await client.GetSocketData();

    if (res is null)
    {
        Console.WriteLine("No result");
    }
    else
    {
        //Console.WriteLine($"{nameof(res.TotalPowerImportT1)}: {res.TotalPowerImportT1}");
        ////Console.WriteLine($"{nameof(res.TotalPowerExportT1)}: {res.TotalPowerExportT1}");
        //Console.WriteLine($"{nameof(res.ActivePower)}: {res.ActivePower}");
        //Console.WriteLine($"{nameof(res.ActivePowerL1)}: {res.ActivePowerL1}");
        //Console.WriteLine();


        //Console.WriteLine(FiggleFonts.Roman.Render($"{res.ActivePower:0.0} W"));
        //Console.WriteLine(FiggleFonts.Banner3.Render($"{res.ActivePower:0.0} W"));
        Console.WriteLine(FiggleFonts.Doh.Render($"{res.ActivePower:0.0} W"));

    }
    await Task.Delay(500);
}
